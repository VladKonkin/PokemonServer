using Battle.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Battle.API.Infrastucture.EntityConfiguration
{
	public class PokemonEntityConfiguration : IEntityTypeConfiguration<PokemonEntity>
	{
		public void Configure(EntityTypeBuilder<PokemonEntity> builder)
		{
			builder.HasKey(p => p.Id);

			builder.HasMany(p => p.Moves)
				.WithOne(m => m.PokemonEntity)
				.HasForeignKey(m => m.PokemonEntityId);

			builder.HasData(
			new PokemonEntity
			{
				Id = new Guid("00000000-0000-0000-0000-000000000001"),
				PokedexId = 1,
				Name = "Pikachu",
				UserTelegramId = "user1",
				PokemonType = PokemonType.Electric,
				Level = 5,
				MaxHp = 35,
				CurrentHp = 35,
				Attack = 55,
				SpAttack = 50,
				Defence = 40,
				SpDefence = 50,
				Speed = 90
			},
			new PokemonEntity
			{
				Id = new Guid("00000000-0000-0000-0000-000000000002"),
				PokedexId = 2,
				Name = "Charmander",
				UserTelegramId = "user1",
				PokemonType = PokemonType.Fire,
				Level = 5,
				MaxHp = 39,
				CurrentHp = 39,
				Attack = 52,
				SpAttack = 60,
				Defence = 43,
				SpDefence = 50,
				Speed = 65
			},
			new PokemonEntity
			{
				Id = new Guid("00000000-0000-0000-0000-000000000003"),
				PokedexId = 3,
				Name = "Bulbasaur",
				UserTelegramId = "user2",
				PokemonType = PokemonType.Grass,
				Level = 5,
				MaxHp = 45,
				CurrentHp = 45,
				Attack = 49,
				SpAttack = 65,
				Defence = 49,
				SpDefence = 65,
				Speed = 45
			},
			new PokemonEntity
			{
				Id = new Guid("00000000-0000-0000-0000-000000000004"),
				PokedexId = 4,
				Name = "Squirtle",
				UserTelegramId = "user2",
				PokemonType = PokemonType.Water,
				Level = 5,
				MaxHp = 44,
				CurrentHp = 44,
				Attack = 48,
				SpAttack = 50,
				Defence = 65,
				SpDefence = 64,
				Speed = 43
			}
		);
		}
	}
}
