namespace Battle.API.Model
{
	public class PokemonEntity
	{
		public Guid Id { get; set; }
		public int PokedexId { get; set; }
		public string Name { get; set; }
		public string UserTelegramId { get; set; } // Foreign key
		public UserEntity User { get; set; }

		public PokemonType PokemonType { get; set; }
		public int Level { get; set; }
		public int MaxHp { get; set; }
		public int CurrentHp { get; set; }
		public int Attack { get; set; }
		public int SpAttack { get; set; }
		public int Defence { get; set; }
		public int SpDefence { get; set; }
		public int Speed { get; set; }
		public List<MoveEntity> Moves { get; set; }
	}
	public enum PokemonType
	{
		Fire,
		Water,
		Grass,
		Electric
	}
}
