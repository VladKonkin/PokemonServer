using Battle.API.Infrastucture;
using Battle.API.Model;
using Battle.API.Services.BattleService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace Battle.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BattleController : ControllerBase
	{
		private UserContext _userContext;
		private BattleHandler _battleHandler;
		private UserRegisterContext _userRegisterContext;
		

		public BattleController(UserContext userContext,BattleHandler battleHandler, UserRegisterContext userRegisterContext)
        {
			_userContext = userContext;
			_battleHandler = battleHandler;
			_userRegisterContext = userRegisterContext;

		}
        
		[HttpPost(Name = "CreateBattle")]
		public async Task<IActionResult> CreateBattle(string telegramId)
		{
			var user = await _userContext.UserDbSet
				.Include(u => u.UserPokemons)
				.ThenInclude(up => up.Moves)
				.AsSplitQuery()
				.FirstOrDefaultAsync(u => u.TelegramId == telegramId);

			if(user == null)
			{
				return NoContent();
			}
			_battleHandler.GetActiveBattle(user);

			return Ok(user);
		}

		//[HttpPatch(Name = ("SetMoveIndex"))]
		//public async Task<IActionResult> SetMoveIndex(string telegramId,int moveIndex)
		//{
  //          Console.WriteLine("IndexTest");
  //          var turnCalculator = _battleHandler.SetMoveIndexByTelegramId(telegramId, moveIndex);
  //          Console.WriteLine("IndexTest1");

		//	var jsonTurnEndData = JsonConvert.SerializeObject(turnCalculator.TurnEndData, Formatting.Indented);

  //          return Ok(jsonTurnEndData);
		//}
		[HttpGet(Name =("GetRegisterData"))]
		public async Task<IActionResult> GetRegisterData(string telegramId)
		{
			var user = await _userRegisterContext.UserRegisterDbSet.FirstOrDefaultAsync(u => u.TelegramId == telegramId);
            Console.WriteLine(user);
            if (user is null)
			{
				return NoContent();
			}

			return Ok(user);
		}
		[HttpDelete(Name = "TestBattleCreate")]
		public async Task<IActionResult> TestBattleCreate(string firstPlayerId, string secondPlayerId)
		{
			var firstPlayer = await _userContext.UserDbSet
				.Include(u => u.UserPokemons)
				.ThenInclude(up => up.Moves)
				.AsSplitQuery()
				.FirstOrDefaultAsync(u => u.TelegramId == firstPlayerId);
			var secondPlayer = await _userContext.UserDbSet
				.Include(u => u.UserPokemons)
				.ThenInclude(up => up.Moves)
				.AsSplitQuery()
				.FirstOrDefaultAsync(u => u.TelegramId == secondPlayerId);

			if (firstPlayer is null || secondPlayer is null)
			{
				return NoContent();
			}

			_battleHandler.CreateBattle(firstPlayer,secondPlayer);
			return Ok(NoContent());
		}
	}
}
