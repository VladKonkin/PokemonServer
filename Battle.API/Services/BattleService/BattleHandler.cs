using Battle.API.Model;
using Battle.API.Services.BattleService.Models;
using Battle.API.Services.BattleService.Models.BattleMembers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Battle.API.Services.BattleService
{
	public class BattleHandler
	{
		private List<Battle> _activeBattleList;
		private List<PlayerBattleMember> _activeMemberList;
		private Battle _activeTestBattle;
		public BattleHandler()
		{
			_activeBattleList = new List<Battle>();
			_activeMemberList = new List<PlayerBattleMember>();
		}
		public Battle GetActiveBattle(UserEntity userEntity)
		{
			if (_activeTestBattle == null)
			{
				_activeTestBattle = CreateBattle(userEntity);
			}
			return _activeTestBattle;
		}
		private Battle CreateBattle(UserEntity userEntity)
		{
			var player = new PlayerBattleMember(userEntity);
			_activeMemberList.Add(player);

			var battle = new Battle(player, GetTestWildMember());
			_activeTestBattle = battle;
			return battle;
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
		public TurnCalculator SetMoveIndexByTelegramId(string telegramId,int moveIndex)
		{
			if(_activeTestBattle == null)
			{
				throw new InvalidOperationException("Active test battle is not initialized.");
			}
			var player = _activeMemberList[0];

			var pokemon = player.GetActivePokemon();
			var move = pokemon.Moves[moveIndex];
            Console.WriteLine("test1");
            var turnData = new TurnData(pokemon, move);

			player.SetTurnData(turnData);
            Console.WriteLine("test2");

			return _activeTestBattle.TryGetTurnByIndex(_activeTestBattle.TurnNumber -1);
		}
	}
}
