using Battle.API.Infrastucture.EntityConfiguration;
using Battle.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Battle.API.Infrastucture
{
	public class UserContext : DbContext
	{
        public UserContext(DbContextOptions<UserContext> options, IConfiguration configuration) : base(options)
        {
			Database.EnsureDeleted();
			Database.EnsureCreated();
        }
        public DbSet<UserEntity> UserDbSet { get; set; }
		public DbSet<PokemonEntity> PokemonDbSet { get; set; }
		public DbSet<MoveEntity> MovesDbSet { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new PokemonEntityConfiguration());
			modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
			modelBuilder.ApplyConfiguration(new MoveEntityConfiguration());
		}
	}
}
