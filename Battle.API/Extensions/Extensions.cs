using Battle.API.Infrastucture;
using Battle.API.Services.BattleService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

namespace Battle.API.Extensions
{
	public static class Extensions
	{
		public static void AddApplicationServices(this IHostApplicationBuilder builder)
		{
			builder.AddNpgsqlDbContext<UserContext>("UserDb", configureDbContextOptions: dbContextOptionsBuilder =>
			{
				dbContextOptionsBuilder.UseNpgsql(builder =>
				{
					
				});
			});

			builder.Services.AddControllers()
					.AddJsonOptions(options =>
					{
						options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
					});
			builder.Services.AddSingleton(new BattleHandler());
		}
	}
}
