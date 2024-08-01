using Battle.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Battle.API.Infrastucture.EntityConfiguration
{
	public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
	{
		public void Configure(EntityTypeBuilder<UserEntity> builder)
		{
			builder.HasKey(k => k.TelegramId);

			builder.HasMany(u => u.UserPokemons)
			   .WithOne(p => p.User)
			   .HasForeignKey(p => p.UserTelegramId);

			builder.HasData(
				new UserEntity
				{
					TelegramId = "user1",
					UserName = "User One",
				},
				new UserEntity
				{
					TelegramId = "user2",
					UserName = "User Two",
				}
			);
		}
	}
}
