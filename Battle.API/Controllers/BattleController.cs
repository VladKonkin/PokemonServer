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
        public BattleController(UserContext userContext,BattleHandler battleHandler)
        {
			_userContext = userContext;
			_battleHandler = battleHandler;
        }
        [HttpGet(Name = "GetAllUsers")]
		public async Task<IActionResult> Index()
		{
			return Ok(await _userContext.UserDbSet.
				Include(u => u.UserPokemons)
				.ThenInclude(up => up.Moves)
				.AsSplitQuery()
				.ToListAsync());
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

		[HttpPatch(Name = ("SetMoveIndex"))]
		public async Task<IActionResult> SetMoveIndex(string telegramId,int moveIndex)
		{
			var turnCalculator = _battleHandler.SetMoveIndexByTelegramId(telegramId, moveIndex);

			var jsonTurnEndData = JsonConvert.SerializeObject(turnCalculator.GetTurnEndData(), Formatting.Indented);

            Console.WriteLine("Pre json: " + turnCalculator);
            Console.WriteLine("Json serialized: " + jsonTurnEndData );
            Console.WriteLine("Json serialize: " + JsonConvert.SerializeObject(turnCalculator, Formatting.Indented));
            

            return Ok(jsonTurnEndData);
		}

	}
}
