using Microsoft.AspNetCore.Mvc;
using Register.API.Entity;
using Register.API.Infrastucture;

namespace Register.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RegisterController : ControllerBase
	{
        private UserRegisterContext _userRegisterContext;
        public RegisterController(UserRegisterContext userRegisterContext)
        {
            _userRegisterContext = userRegisterContext;
        }
        [HttpPut(Name = "RegisterNewUser")]
        public async Task<IActionResult> RegisterNewUser(string userId, string userName)
        {
            await _userRegisterContext.UserRegisterDbSet.AddAsync(new UserRegisterEntity()
            {
                TelegramId = userId,
                UserName = userName,
            });
            await _userRegisterContext.SaveChangesAsync();
            return Ok();
        }
    }
}
