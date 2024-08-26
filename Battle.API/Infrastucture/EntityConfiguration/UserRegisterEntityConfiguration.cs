using Battle.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Battle.API.Infrastucture.EntityConfiguration
{
	public class UserRegisterEntityConfiguration : IEntityTypeConfiguration<UserRegisterEntity>
	{

		public void Configure(EntityTypeBuilder<UserRegisterEntity> builder)
		{
			builder.HasKey(k => k.TelegramId);
		}
	}
}
