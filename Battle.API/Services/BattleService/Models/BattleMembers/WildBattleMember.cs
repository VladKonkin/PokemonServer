using Battle.API.Model;

namespace Battle.API.Services.BattleService.Models.BattleMembers
{
	public class WildBattleMember : BattleMember
	{
		public WildBattleMember(Pokemon wildPokemon)
		{
			_pokemonList = new List<Pokemon>()
			{
				wildPokemon
			};
		}
		public override Pokemon GetActivePokemon()
		{
			return _pokemonList[0];
		}
		public override void SetBattle(Battle battle)
		{
			base.SetBattle(battle);
			SetDefaultTurn();
		}
		public override void NexTurnStart()
		{
			base.NexTurnStart();
			SetDefaultTurn();
		}
		private void SetDefaultTurn()
		{
			var pokemon = GetActivePokemon();
			var move = pokemon.Moves[0];
			Console.WriteLine("defaul turn");
			_activeTurnData = new TurnData(pokemon, move);

			SetTurnData(_activeTurnData);
		}
		public override void SetTurnData(TurnData turnData)
		{
			BattleTurnSetAction?.Invoke();
		}

		public override string GetId()
		{
			return "WildId";
		}

	}
}
