using Battle.API.Infrastucture;
using Battle.API.Infrastucture.Repositories;
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
			//builder.AddNpgsqlDbContext<UserContext>("UserDb", configureDbContextOptions: dbContextOptionsBuilder =>
			//{
			//	dbContextOptionsBuilder.UseNpgsql(builder =>
			//	{

			//	});
			//});
			builder.Services.AddDbContext<UserContext>(options =>
			{
				options.UseNpgsql(builder.Configuration.GetConnectionString("UserDb"),
					npgsqlOptions =>
					{
						// Здесь можно добавить дополнительные настройки Npgsql, если необходимо
					});
			});

			builder.AddNpgsqlDbContext<UserRegisterContext>("UserRegisterDb", configureDbContextOptions: dbContextOptionsBuilder =>
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
			builder.Services.AddSingleton<BattleHandler>();

			//builder.Services.AddCors);

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				{
					builder
						.AllowAnyOrigin()   // Разрешаем любые источники
						.AllowAnyMethod()
						.AllowAnyHeader();
					// Учетные данные отключены
				});
			});
			builder.Services.AddScoped<UserRepository>();
			builder.Services.AddSignalR();


		}
	}
}
