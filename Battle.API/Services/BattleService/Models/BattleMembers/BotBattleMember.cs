using Battle.API.Model;

namespace Battle.API.Services.BattleService.Models.BattleMembers
{
	public class BotBattleMember : BattleMember
	{
		public BotBattleMember(List<Pokemon> pokemonModelList)
		{
			_pokemonList = pokemonModelList;
		}

		public override string GetId()
		{
			return "BotId";
		}

		public override void NexTurnStart()
		{
			throw new NotImplementedException();
		}

		public override void SetTurnData(TurnData turnData)
		{
			throw new NotImplementedException();
		}

	}
}
