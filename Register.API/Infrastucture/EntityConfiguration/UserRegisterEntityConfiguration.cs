using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Register.API.Entity;

namespace Register.API.Infrastucture.EntityConfiguration
{
	public class UserRegisterEntityConfiguration : IEntityTypeConfiguration<UserRegisterEntity>
	{
		public void Configure(EntityTypeBuilder<UserRegisterEntity> builder)
		{
			builder.HasKey(k => k.TelegramId);


			builder.HasData(
				new UserRegisterEntity
				{
					TelegramId = "user1",
					UserName = "User One",
				},
				new UserRegisterEntity
				{
					TelegramId = "user2",
					UserName = "User Two",
				}
			);
		}
	}
}
