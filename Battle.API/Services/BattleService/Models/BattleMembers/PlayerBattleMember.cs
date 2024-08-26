using Battle.API.Model;

namespace Battle.API.Services.BattleService.Models.BattleMembers
{
	public class PlayerBattleMember : BattleMember
	{
		private UserEntity _userEntity;
		private int _activePokemonIndex;
		public PlayerBattleMember(UserEntity playerEntity)
		{
			_userEntity = playerEntity;
			_pokemonList = new List<Pokemon>();
            
            for (int i = 0; i < _userEntity.UserPokemons.Count; i++)
			{
				_pokemonList.Add(new Pokemon(_userEntity.UserPokemons[i]));
			}
			_activePokemonIndex = 0;
		}
		public override Pokemon GetActivePokemon() => _pokemonList[_activePokemonIndex];

		public void SetActivePokemon(int index)
		{
			if (index >= 0 & index <= _pokemonList.Count)
			{
				if (_pokemonList[index].IsAlive)
				{
					_activePokemonIndex = index;
				}
			}
		}
		public override void NexTurnStart()
		{
			base.NexTurnStart();
			Console.WriteLine("New Player Turn");
		}

		public override string GetId()
		{
			return _userEntity.TelegramId;
		}

		public override void SetTurnData(TurnData turnData)
		{
			Console.WriteLine("ModelSet");
			_activeTurnData = turnData;

			BattleTurnSetAction?.Invoke();
		}
	}
}
