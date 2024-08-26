

using Battle.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Battle.API.Infrastucture.Repositories
{
	public class UserRepository
	{
        private UserContext _userContext;
        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<UserEntity> GetUserByIdAsync(string id)
        {
            var user = await _userContext.UserDbSet.FirstOrDefaultAsync(u => u.TelegramId == id);
            return user;
		}
        public async Task<UserEntity> GetUserByIdWithPokemonsAsync(string id)
        {
            var user = await _userContext.UserDbSet
				.Include(u => u.UserPokemons)
				.ThenInclude(up => up.Moves)
				.AsSplitQuery()
				.FirstOrDefaultAsync(u => u.TelegramId == id);
            return user;
		}

    }
}
