namespace Battle.API.Model
{
    public class Pokemon
    {
		public Guid Id { get; set; }
		public int PokedexId { get; set; }
		public string Name { get; set; }

		public PokemonType PokemonType { get; set; }
		public int Level { get; set; }
		public int MaxHp { get; set; }
		public int CurrentHp { get; set; }
		public int Attack { get; set; }
		public int SpAttack { get; set; }
		public int Defence { get; set; }
		public int SpDefence { get; set; }
		public int Speed { get; set; }
		public List<Move> Moves { get; set; }

		public bool IsAlive => CurrentHp > 0;

		public Pokemon(PokemonEntity pokemonEntity)
        {
			Id = pokemonEntity.Id;
            PokedexId = pokemonEntity.PokedexId;
			Name = pokemonEntity.Name;
			PokemonType = pokemonEntity.PokemonType;
			Level = pokemonEntity.Level;
			MaxHp = pokemonEntity.MaxHp;
			CurrentHp = pokemonEntity.CurrentHp;
			Attack = pokemonEntity.Attack;
			SpAttack = pokemonEntity.SpAttack;
			Defence = pokemonEntity.Defence;
			SpDefence = pokemonEntity.SpDefence;
			Speed = pokemonEntity.Speed;
			Moves = new List<Move>
			{
				new Move(pokemonEntity.Moves[0]),
				new Move(pokemonEntity.Moves[1]),
				new Move(pokemonEntity.Moves[2]),
				new Move(pokemonEntity.Moves[3])
			};
        }
		public Pokemon(Pokemon pokemonModel)
		{
			Id = pokemonModel.Id;
			PokedexId = pokemonModel.PokedexId;
			Name = pokemonModel.Name;
			PokemonType = pokemonModel.PokemonType;
			Level = pokemonModel.Level;
			MaxHp = pokemonModel.MaxHp;
			CurrentHp = pokemonModel.CurrentHp;
			Attack = pokemonModel.Attack;
			SpAttack = pokemonModel.SpAttack;
			Defence = pokemonModel.Defence;
			SpDefence = pokemonModel.SpDefence;
			Speed = pokemonModel.Speed;
			Moves = new List<Move>
			{
				new Move(pokemonModel.Moves[0]),
				new Move(pokemonModel.Moves[1]),
				new Move(pokemonModel.Moves[2]),
				new Move(pokemonModel.Moves[3])
			};
		}
        public Pokemon()
        {
            
        }
        public void TakeAttack(Pokemon enemy, Move enemyMove)
		{
			CurrentHp -= enemyMove.Power;
		}
	}
}
