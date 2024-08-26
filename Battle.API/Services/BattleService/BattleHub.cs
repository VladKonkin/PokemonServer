using Battle.API.Model;
using Battle.API.Services.BattleService.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Numerics;
using System.Text.Json;

namespace Battle.API.Services.BattleService
{
	public class BattleHub : Hub
	{
		private readonly BattleHandler _battleHandler;
        public BattleHub(BattleHandler battleHandler)
        {
            _battleHandler = battleHandler;
			_battleHandler.BattleEndAction += OnBattleEnd;
			_battleHandler.BattleTurnEndAction += OnBattleTurnEnd;

		}
        public async Task SendMessage(string user, string message)
		{
            Console.WriteLine($"SendMessage user: {user} with message : {message}");
			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}
		public async Task JoinBattle(string playerId)
		{
			BattleRoom battleRoom = await _battleHandler.PlayerConnectAsync(playerId);

			string battleId = battleRoom.Id.ToString();
			var connectionId = Context.ConnectionId;

			Console.WriteLine($"JoinBattle withId: {battleId} with Player Id: {playerId}");
			await Groups.AddToGroupAsync(connectionId, battleId);
			await Clients.Group(battleId).SendAsync("PlayerJoined", playerId);
			

		}

		public async Task MakeMove(string playerId,int moveIndex)
		{
			var battleId = _battleHandler.MakeMove(playerId, moveIndex);
            Console.WriteLine($"MakeMove in battle Id: {battleId} with Player Id: {playerId}");
            await Clients.Group(battleId).SendAsync("MoveMade", playerId, moveIndex);
		}
		
		private async void OnBattleEnd(Battle battle)
		{
			//TODO PlayerDisConnect

			
		}
		private async Task OnBattleTurnEnd(string battleId, TurnEndData turnEndData)
		{
			var jsonData = JsonConvert.SerializeObject(turnEndData);
			await Clients.Group(battleId).SendAsync("TurnEnd", jsonData);
			Console.WriteLine("TurnEnded BattleHub");
            Console.WriteLine($"TurnEnd Data {jsonData} with id {battleId}");
            //await Clients.Group(battleId).SendAsync("TurnEnd", turnEndData);
		}
	}
}
