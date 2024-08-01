namespace Battle.API.Model
{
	public class Move
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public MoveType MoveType { get; set; }
		public int Power { get; set; }
		public int Accuracy { get; set; }
		public int MaxPP { get; set; }
		public int CurrentPP { get; set; }

		public Move(MoveEntity moveEntity)
        {
            Id = moveEntity.Id;
			Name = moveEntity.Name;
			Description = moveEntity.Description;
			MoveType = moveEntity.MoveType;
			Power = moveEntity.Power;
			Accuracy = moveEntity.Accuracy;
			MaxPP = moveEntity.MaxPP;
			CurrentPP = moveEntity.CurrentPP;
        }
		public Move(Move moveModel)
		{
			Id = moveModel.Id;
			Name = moveModel.Name;
			Description = moveModel.Description;
			MoveType = moveModel.MoveType;
			Power = moveModel.Power;
			Accuracy = moveModel.Accuracy;
			MaxPP = moveModel.MaxPP;
			CurrentPP = moveModel.CurrentPP;
		}
		public Move()
        {
            
        }
    }
}
