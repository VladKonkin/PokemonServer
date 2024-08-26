using Battle.API.Infrastucture;
using Battle.API.Infrastucture.Repositories;
using Battle.API.Model;
using Battle.API.Services.BattleService.Models;
using Battle.API.Services.BattleService.Models.BattleMembers;
using k8s.KubeConfigModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Battle.API.Services.BattleService
{
	public class BattleHandler
	{
		private readonly IServiceProvider _serviceProvider;

		private List<Battle> _activeBattleList;
		private List<PlayerBattleMember> _activeMemberList;
		private List<BattleRoom> _activeBattleRoom;
		public Action<Battle> BattleEndAction { get; set; }
		public Func<string, TurnEndData, Task> BattleTurnEndAction { get; set; }
		public BattleHandler(IServiceProvider serviceProvider)
		{
			_activeBattleList = new List<Battle>();
			_activeMemberList = new List<PlayerBattleMember>();
			_activeBattleRoom= new List<BattleRoom>();

			_serviceProvider = serviceProvider;
		}
		public void GetActiveBattle(UserEntity userEntity)
		{
			var user = _activeMemberList.Find(u => u.GetId() == userEntity.TelegramId);
			if(user is null)
			{
				CreateBattle(userEntity);
			}
			
		}
	
	
		private Battle CreateBattle(UserEntity userEntity)
		{
			var player = new PlayerBattleMember(userEntity);
			var battle = new Battle(player, GetTestWildMember());
			OnBattleCreate(battle);
			_activeMemberList.Add(player);

			_activeBattleList.Add(battle);
			return battle;
		}
		public void CreateBattle(UserEntity firstUser, UserEntity secondUser)
		{
			var firstPlayer = new PlayerBattleMember(firstUser);
			var secondPlayer = new PlayerBattleMember(secondUser);

			_activeMemberList.Add(firstPlayer);
			_activeMemberList.Add(secondPlayer);
			var battle = new Battle(firstPlayer, secondPlayer);
			OnBattleCreate(battle);
			_activeBattleList.Add(battle);
		}
		public void CreateBattle(BattleRoom room)
		{
			var firstPlayer = room.FirstPlayer;
			var secondPlayer = room.SecondPlayer;

			_activeMemberList.Add(firstPlayer);
			_activeMemberList.Add(secondPlayer);
			var battle = new Battle(firstPlayer, secondPlayer, room.Id);
			OnBattleCreate(battle);
			_activeBattleList.Add(battle);
		}
		public async Task<BattleRoom> PlayerConnectAsync(string telegramId)
		{
			UserEntity user;
			using (var scope = _serviceProvider.CreateScope())
			{
				var userRepository = scope.ServiceProvider.GetRequiredService<UserRepository>();
				user = await userRepository.GetUserByIdWithPokemonsAsync(telegramId);

			}
			if (user == null)
			{
				throw new InvalidOperationException("Cant get user data");
			}

			var player = new PlayerBattleMember(user);
			BattleRoom battleRoom = null;
            Console.WriteLine("PreIf");
			if (_activeMemberList.Contains(player))
			{
				throw new InvalidOperationException("User already in Battle");
			}
            if (_activeBattleRoom.Count > 0)
			{
				Console.WriteLine("If");
				battleRoom = _activeBattleRoom[0].AddPlayer(player);
				BattleRoomClose(battleRoom);
			}
			else
			{
				Console.WriteLine("If2");
				battleRoom = new BattleRoom(player);
				BattleRoomCreate(battleRoom);
			}
			return battleRoom;
		}
		public string MakeMove(string telegramId, int moveIndex)
		{

			var player = _activeMemberList.Find(p => p.GetId() == telegramId);
			var battle = _activeBattleList.FirstOrDefault(b => b.FirstBattleMemberId == telegramId || b.SecondBattleMemberId == telegramId);
            Console.WriteLine($"Player is: {player} Battle is: {battle }");
            if (battle is null || player is null)
			{
				throw new InvalidOperationException("Active test battle is not initialized.");
			}

			var pokemon = player.GetActivePokemon();
			var move = pokemon.Moves[moveIndex];

			var turnData = new TurnData(pokemon, move);

			player.SetTurnData(turnData);
			return battle.BattleId.ToString();
		}

		private void OnBattleCreate(Battle battle)
		{
			battle.BattleEndAction += OnBattleEnd;
			battle.TurnEndAction += OnTurnEnd;
		}
		private void OnBattleEnd(Battle battle)
		{
			battle.TurnEndAction -= OnTurnEnd;
			battle.BattleEndAction -= OnBattleEnd;
			BattleEndAction?.Invoke(battle);
			//TODO db save
		}
		private void OnTurnEnd(string battleId,TurnEndData turnEndData)
		{
            Console.WriteLine("BattleHander TurnEnd");
            BattleTurnEndAction?.Invoke(battleId,turnEndData);
		}
		private void BattleRoomCreate(BattleRoom battleRoom)
		{
            Console.WriteLine("Battle Room Created");
			_activeBattleRoom.Add(battleRoom);
			_activeMemberList.Add(battleRoom.FirstPlayer);

		}
		private void BattleRoomClose(BattleRoom battleRoom)
		{
			_activeBattleRoom.Remove(battleRoom);
            Console.WriteLine("Battle Room Closed");
			CreateBattle(battleRoom);
		}
		private WildBattleMember GetTestWildMember()
		{
			var testPok = new Pokemon()
			{
				Id = new Guid(),
				PokedexId = 2,
				Name = "Char3",
				Level = 1,
				MaxHp = 1000,
				CurrentHp = 1000,
				Attack = 2,
				SpAttack = 2,
				Defence = 1,
				SpDefence = 1,
				Speed = 11,
				Moves = new List<Move>
				{
					new Move
					{
						Id = 1,
						Name = "Thunderbolt",
						Description = "A strong electric blast crashes down on the target.",
						MoveType = MoveType.Attack,
						Power = 90,
						Accuracy = 100,
						MaxPP = 15,
						CurrentPP = 15
					},
					new Move
					{
						Id = 2,
						Name = "Quick Attack",
						Description = "The user lunges at the target at a speed that makes it almost invisible.",
						MoveType = MoveType.Attack,
						Power = 40,
						Accuracy = 100,
						MaxPP = 30,
						CurrentPP = 30
					},
					new Move
					{
						Id = 3,
						Name = "Iron Tail",
						Description = "The target is slammed with a steel-hard tail.",
						MoveType = MoveType.Attack,
						Power = 100,
						Accuracy = 75,
						MaxPP = 15,
						CurrentPP = 15
					},
					new Move
					{
						Id = 4,
						Name = "Electro Ball",
						Description = "The user hurls an electric orb at the target.",
						MoveType = MoveType.Attack,
						Power = 60,
						Accuracy = 100,
						MaxPP = 10,
						CurrentPP = 10
					}
				}
			};
			WildBattleMember wildBattleMember = new WildBattleMember(testPok);

			return wildBattleMember;
		}
		
	}
}
