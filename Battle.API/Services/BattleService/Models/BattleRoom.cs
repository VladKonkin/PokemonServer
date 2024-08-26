using Battle.API.Services.BattleService.Models.BattleMembers;

namespace Battle.API.Services.BattleService.Models
{
	public class BattleRoom
	{
		public Guid Id { get; set; }
		public PlayerBattleMember FirstPlayer {  get; private set; }
		public PlayerBattleMember SecondPlayer {  get; private set; }


		
        public BattleRoom(PlayerBattleMember firstPlayer)
        {
            FirstPlayer = firstPlayer;
			Id = Guid.NewGuid();
        }
        public BattleRoom AddPlayer(PlayerBattleMember secondPlayer)
		{
			SecondPlayer = secondPlayer;
			return this;
		}
	}
}
