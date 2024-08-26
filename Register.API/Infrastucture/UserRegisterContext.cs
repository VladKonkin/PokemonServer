using Microsoft.EntityFrameworkCore;
using Register.API.Entity;
using Register.API.Infrastucture.EntityConfiguration;

namespace Register.API.Infrastucture
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
