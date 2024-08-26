using Register.API.Infrastucture;
using Microsoft.EntityFrameworkCore;

namespace Register.API.Extensions
{
	public static class Extensions
	{
		public static void AddApplicationServices(this IHostApplicationBuilder builder)
		{
			builder.AddNpgsqlDbContext<UserRegisterContext>("UserRegisterDb", configureDbContextOptions: dbContextOptionsBuilder =>
			{
				dbContextOptionsBuilder.UseNpgsql(builder =>
				{

				});
			});
		}

	}
}
