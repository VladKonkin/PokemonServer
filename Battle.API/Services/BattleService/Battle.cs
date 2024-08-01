using Battle.API.Services.BattleService.Models.BattleMembers;
using System.Text;

namespace Battle.API.Services.BattleService
{
	public class Battle
	{
		public Guid BattleId; 
		public BattleMember _firstBattleMember;
		public BattleMember _secondBattleMember;

		private int _turnNumber;
		private StringBuilder _battleLog;
		private List<TurnCalculator> _turnCalculatorList;
		public StringBuilder BattleLog => _battleLog;
		public int TurnNumber => _turnNumber;
		public Action BattleEndAction;
		public Battle(BattleMember first, BattleMember second)
		{
			_firstBattleMember = first;
			_secondBattleMember = second;

			_turnNumber = 0;

			_battleLog = new StringBuilder("Battle Start");
			_turnCalculatorList = new List<TurnCalculator>();

			BattleId = new Guid();

			BattleMemberActionSubscribe();
			_firstBattleMember.SetBattle(this);
			_secondBattleMember.SetBattle(this);
		}

		public TurnCalculator TryGetTurnByIndex(int turnNumber)
		{
			Console.WriteLine("test3 : " +_turnNumber  + " " + turnNumber);
                Console.WriteLine(_turnCalculatorList.Count + " - test3.01 Count");
			if (turnNumber >= 0 & turnNumber <= _turnNumber)
			{
                Console.WriteLine(_turnCalculatorList.Count + " - test3.1 Count");
                return _turnCalculatorList[turnNumber];
			}
			Console.WriteLine("test4");
			return null;
		}

		private void BattleMemberActionSubscribe()
		{
			_firstBattleMember.BattleTurnSetAction += CalculateIfReady;
			_secondBattleMember.BattleTurnSetAction += CalculateIfReady;
		}
		private void BattleMemberActionUnsubscribe()
		{
			_firstBattleMember.BattleTurnSetAction -= CalculateIfReady;
			_secondBattleMember.BattleTurnSetAction -= CalculateIfReady;
		}
		private void CalculateIfReady()
		{
			if (_firstBattleMember.IsReady() & _secondBattleMember.IsReady())
			{
				CalculateTurn();
			}
		}
		private void CalculateTurn()
		{
			TurnCalculator turnCalculator = new TurnCalculator(_firstBattleMember.ActiveTurnModel, _secondBattleMember.ActiveTurnModel, _turnNumber);
			turnCalculator.Calculate();

			string log = turnCalculator.GetTurnLog();
			Console.WriteLine(log);
			_battleLog.AppendLine(log);

			_turnCalculatorList.Add(turnCalculator);

			if (_firstBattleMember.CanСontinueBattle() & _secondBattleMember.CanСontinueBattle())
			{
				_firstBattleMember.NexTurnStart();
				_secondBattleMember.NexTurnStart();
			}
			else
			{
				BattleEnd();
			}

			_turnNumber++;

		}
		private void BattleEnd()
		{
			BattleMemberActionUnsubscribe();
			_battleLog.AppendLine("Battle End");
			BattleEndAction?.Invoke();
			Console.WriteLine(_battleLog);
		}
	}
}
