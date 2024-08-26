using Battle.API.Services.BattleService.Models;
using Battle.API.Services.BattleService.Models.BattleMembers;
using Microsoft.AspNetCore.SignalR;
using System.Text;

namespace Battle.API.Services.BattleService
{
	public class Battle : Hub
	{
		private BattleMember _firstBattleMember;
		private BattleMember _secondBattleMember;

		private int _turnNumber;
		private StringBuilder _battleLog;
		private List<TurnCalculator> _turnCalculatorList;
		private Guid _battleId;
		public StringBuilder BattleLog => _battleLog;
		public int TurnNumber => _turnNumber;
		public Guid BattleId => _battleId;
		public string FirstBattleMemberId => _firstBattleMember.GetId();
		public string SecondBattleMemberId => _secondBattleMember.GetId();
		public Action<Battle> BattleEndAction;
		public Action<string, TurnEndData> TurnEndAction { get; set; }
		public Battle(BattleMember first, BattleMember second)
		{
			_firstBattleMember = first;
			_secondBattleMember = second;

			_turnNumber = 0;

			_battleLog = new StringBuilder("Battle Start");
			_turnCalculatorList = new List<TurnCalculator>();

			_battleId = new Guid();

			BattleMemberActionSubscribe();
			_firstBattleMember.SetBattle(this);
			_secondBattleMember.SetBattle(this);
		}
        public Battle(BattleMember first, BattleMember second,Guid battleId)
        {
			_firstBattleMember = first;
			_secondBattleMember = second;

			_turnNumber = 0;

			_battleLog = new StringBuilder("Battle Start");
			_turnCalculatorList = new List<TurnCalculator>();

			_battleId = battleId;

			BattleMemberActionSubscribe();
			_firstBattleMember.SetBattle(this);
			_secondBattleMember.SetBattle(this);
		}

        public TurnCalculator GetLastTurn()
		{
			return _turnCalculatorList.Last();
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

			string log = turnCalculator.TurnLog;
			Console.WriteLine(log);
			_battleLog.AppendLine(log);

			_turnCalculatorList.Add(turnCalculator);
			TurnEndAction?.Invoke(BattleId.ToString(),turnCalculator.TurnEndData);
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
			BattleEndAction?.Invoke(this);
			Console.WriteLine(_battleLog);
		}
	}
}
