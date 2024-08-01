using Battle.API.Model;

namespace Battle.API.Services.BattleService.Models
{
	public class TurnData
	{
		public Pokemon Pokemon { get; set; }
		public Move Move { get; set; }
        public TurnData(Pokemon pokemon, Move move)
        {
            Pokemon = pokemon;
            Move = move;
        }
    }
}
