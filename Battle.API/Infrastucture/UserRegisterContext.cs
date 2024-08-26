using Battle.API.Entity;
using Battle.API.Infrastucture.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Battle.API.Infrastucture
{
	public class UserRegisterContext : DbContext
	{
		public DbSet<UserRegisterEntity> UserRegisterDbSet { get; set; }
		public UserRegisterContext(DbContextOptions<UserRegisterContext> options)
			: base(options)
		{
			
			Database.EnsureCreated();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new UserRegisterEntityConfiguration());
		}
	}
}
