using Battle.API.Model;

namespace Battle.API.Services.BattleService.Models.BattleMembers
{
	public class BotBattleMember : BattleMember
	{
		public BotBattleMember(List<Pokemon> pokemonModelList)
		{
			_pokemonList = pokemonModelList;
		}

		public override Guid GetId()
		{
			return Guid.Empty;
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
