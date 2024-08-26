namespace Battle.API.Model
{
	public class UserEntity
	{
		public string TelegramId {  get; set; }
		public string UserName { get; set; }
		public List<PokemonEntity> UserPokemons { get; set; }
		
	}
}
