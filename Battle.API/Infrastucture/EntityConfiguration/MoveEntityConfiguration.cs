using Battle.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Battle.API.Infrastucture.EntityConfiguration
{
	public class MoveEntityConfiguration : IEntityTypeConfiguration<MoveEntity>
	{
		public void Configure(EntityTypeBuilder<MoveEntity> builder)
		{
			builder.HasKey(m => m.Id);

			builder.HasData(
				new MoveEntity
				{
					Id = 1,
					Name = "Thunderbolt",
					Description = "A strong electric blast crashes down on the target.",
					MoveType = MoveType.Attack,
					Power = 90,
					Accuracy = 100,
					MaxPP = 15,
					CurrentPP = 15,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000001")
				},
				new MoveEntity
				{
					Id = 2,
					Name = "Quick Attack",
					Description = "The user lunges at the target at a speed that makes it almost invisible.",
					MoveType = MoveType.Attack,
					Power = 40,
					Accuracy = 100,
					MaxPP = 30,
					CurrentPP = 30,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000001")
				},
				new MoveEntity
				{
					Id = 3,
					Name = "Iron Tail",
					Description = "The target is slammed with a steel-hard tail.",
					MoveType = MoveType.Attack,
					Power = 100,
					Accuracy = 75,
					MaxPP = 15,
					CurrentPP = 15,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000001")
				},
				new MoveEntity
				{
					Id = 4,
					Name = "Electro Ball",
					Description = "The user hurls an electric orb at the target.",
					MoveType = MoveType.Attack,
					Power = 60,
					Accuracy = 100,
					MaxPP = 10,
					CurrentPP = 10,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000001")
				},
				// Charmander moves
				new MoveEntity
				{
					Id = 5,
					Name = "Flamethrower",
					Description = "The user attacks by exhaling hot flames.",
					MoveType = MoveType.Attack,
					Power = 90,
					Accuracy = 100,
					MaxPP = 15,
					CurrentPP = 15,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000002")
				},
				new MoveEntity
				{
					Id = 6,
					Name = "Scratch",
					Description = "Hard, pointed, sharp claws rake the target.",
					MoveType = MoveType.Attack,
					Power = 40,
					Accuracy = 100,
					MaxPP = 35,
					CurrentPP = 35,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000002")
				},
				new MoveEntity
				{
					Id = 7,
					Name = "Ember",
					Description = "The target is attacked with small flames.",
					MoveType = MoveType.Attack,
					Power = 40,
					Accuracy = 100,
					MaxPP = 25,
					CurrentPP = 25,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000002")
				},
				new MoveEntity
				{
					Id = 8,
					Name = "Dragon Breath",
					Description = "The user exhales a mighty gust that inflicts damage.",
					MoveType = MoveType.Attack,
					Power = 60,
					Accuracy = 100,
					MaxPP = 20,
					CurrentPP = 20,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000002")
				},
				// Bulbasaur moves
				new MoveEntity
				{
					Id = 9,
					Name = "Vine Whip",
					Description = "The target is struck with slender, whiplike vines.",
					MoveType = MoveType.Attack,
					Power = 45,
					Accuracy = 100,
					MaxPP = 25,
					CurrentPP = 25,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000003")
				},
				new MoveEntity
				{
					Id = 10,
					Name = "Razor Leaf",
					Description = "Sharp-edged leaves are launched to slash at the target.",
					MoveType = MoveType.Attack,
					Power = 55,
					Accuracy = 95,
					MaxPP = 25,
					CurrentPP = 25,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000003")
				},
				new MoveEntity
				{
					Id = 11,
					Name = "Seed Bomb",
					Description = "The user slams a barrage of hard seeds down on the target.",
					MoveType = MoveType.Attack,
					Power = 80,
					Accuracy = 100,
					MaxPP = 15,
					CurrentPP = 15,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000003")
				},
				new MoveEntity
				{
					Id = 12,
					Name = "Take Down",
					Description = "A reckless, full-body charge attack.",
					MoveType = MoveType.Attack,
					Power = 90,
					Accuracy = 85,
					MaxPP = 20,
					CurrentPP = 20,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000003")
				},
				// Squirtle moves
				new MoveEntity
				{
					Id = 13,
					Name = "Water Gun",
					Description = "The target is blasted with a forceful shot of water.",
					MoveType = MoveType.Attack,
					Power = 40,
					Accuracy = 100,
					MaxPP = 25,
					CurrentPP = 25,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000004")
				},
				new MoveEntity
				{
					Id = 14,
					Name = "Bubble",
					Description = "A spray of countless bubbles is jetted at the opposing team.",
					MoveType = MoveType.Attack,
					Power = 40,
					Accuracy = 100,
					MaxPP = 30,
					CurrentPP = 30,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000004")
				},
				new MoveEntity
				{
					Id = 15,
					Name = "Bite",
					Description = "The target is bitten with viciously sharp fangs.",
					MoveType = MoveType.Attack,
					Power = 60,
					Accuracy = 100,
					MaxPP = 25,
					CurrentPP = 25,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000004")
				},
				new MoveEntity
				{
					Id = 16,
					Name = "Hydro Pump",
					Description = "The target is blasted by a huge volume of water.",
					MoveType = MoveType.Attack,
					Power = 110,
					Accuracy = 80,
					MaxPP = 5,
					CurrentPP = 5,
					PokemonEntityId = new Guid("00000000-0000-0000-0000-000000000004")
				}
			);
		}
	}
}
