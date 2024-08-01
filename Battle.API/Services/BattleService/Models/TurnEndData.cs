using Battle.API.Model;
using Newtonsoft.Json;

namespace Battle.API.Services.BattleService.Models
{
	
	public class TurnEndData
	{
		[JsonProperty] private TurnData FirstPlayerTurnData { get; set; }
		[JsonProperty] private TurnData SecondPlayerTurnData { get; set; }
		[JsonProperty] private Pokemon FirstPlayerPokemonOnEnd { get; set; }
		[JsonProperty] private Pokemon SecondPlayerPokemonOnEnd { get; set; }
		[JsonProperty] private string TurnLog { get; set; }

		public void SetStartData(TurnData firstPlayerTurnData,TurnData secondPlayerTurnData)
		{
			var firstPlayerDataClone = new TurnData(new Pokemon(firstPlayerTurnData.Pokemon), new Move(firstPlayerTurnData.Move));
			var secondPlayerDataClone = new TurnData(new Pokemon(secondPlayerTurnData.Pokemon), new Move(secondPlayerTurnData.Move));

			FirstPlayerTurnData = firstPlayerDataClone;
			SecondPlayerTurnData = secondPlayerDataClone;
		}
		public void SetEndData(Pokemon firstPlayerPokemon, Pokemon secondPlayerPokemon,string turnLog)
		{
			var firstPlayerPokemonOnEnd = new Pokemon(firstPlayerPokemon);
			var secondPlayerPokemonOnEnd = new Pokemon(secondPlayerPokemon);

			FirstPlayerPokemonOnEnd = firstPlayerPokemonOnEnd;
			SecondPlayerPokemonOnEnd = secondPlayerPokemonOnEnd;
			TurnLog = turnLog;
		}
	}
}
