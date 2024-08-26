using Battle.API.Model;
using Newtonsoft.Json;

namespace Battle.API.Services.BattleService.Models
{
	
	public class TurnEndData
	{
		[JsonProperty] private Pokemon FirstPlayerPokemonOnEnd { get; set; }
		[JsonProperty] private Pokemon SecondPlayerPokemonOnEnd { get; set; }
		[JsonProperty] private TurnData FirstPlayerTurnData { get; set; }
		[JsonProperty] private TurnData SecondPlayerTurnData { get; set; }
		[JsonProperty] private string TurnLog { get; set; }

		public void SetTurnData(TurnData firstPlayerData, TurnData secondPlayerData)
		{
			FirstPlayerTurnData = firstPlayerData;
			SecondPlayerTurnData = secondPlayerData;
		}
		public void SetEndData(Pokemon firstPlayerPokemon, Pokemon secondPlayerPokemon,string turnLog)
		{
			TurnLog = turnLog;
			var firstPlayerPokemonOnEnd = new Pokemon(firstPlayerPokemon);
			var secondPlayerPokemonOnEnd = new Pokemon(secondPlayerPokemon);

			FirstPlayerPokemonOnEnd = firstPlayerPokemonOnEnd;
			SecondPlayerPokemonOnEnd = secondPlayerPokemonOnEnd;
		}
	}
}
