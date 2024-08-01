namespace Battle.API.Model
{
	public class MoveEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public MoveType MoveType { get; set; }
		public int Power { get; set; }
		public int Accuracy { get; set; }
		public int MaxPP { get; set; }
		public int CurrentPP { get; set; }
		public Guid PokemonEntityId { get; set; }
		public PokemonEntity PokemonEntity { get; set; }
	}
	public enum MoveType
	{
		Attack,
		Status,
		Idle
	}
}

