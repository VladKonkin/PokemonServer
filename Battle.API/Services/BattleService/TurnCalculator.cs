using Battle.API.Services.BattleService.Models;
using System.Text;

namespace Battle.API.Services.BattleService
{
	public class TurnCalculator
	{
		private TurnData _firstMemberData;
		private TurnData _secondMemberData;

		bool firstAttackFirst;
		int _turnNumber;
		private StringBuilder turnLog;
		private TurnEndData _endData;
		public TurnCalculator(TurnData firstMember, TurnData secondMember, int turnNumber)
		{
			_firstMemberData = firstMember;
			_secondMemberData = secondMember;
			_turnNumber = turnNumber;

			turnLog = new StringBuilder();

			_endData = new TurnEndData();
			_endData.SetStartData(_firstMemberData, _secondMemberData);
		}
		public void Calculate()
		{
			CalculateSpeed();
			StartTurn();
			TurnEnd();
		}
		public string GetTurnLog()
		{
			return turnLog.ToString();
		}
		public TurnEndData GetTurnEndData()
		{
			return _endData;
		}
		private void CalculateSpeed()
		{
			firstAttackFirst = _firstMemberData.Pokemon.Speed >= _secondMemberData.Pokemon.Speed;
		}
		private void StartTurn()
		{
			turnLog.AppendLine($"Turn {_turnNumber} Start");
			if (firstAttackFirst)
			{
				Attack(_firstMemberData, _secondMemberData);
				if (_secondMemberData.Pokemon.IsAlive)
				{
					Attack(_secondMemberData, _firstMemberData);
				}
			}
			else
			{

				Attack(_secondMemberData, _firstMemberData);
				if (_firstMemberData.Pokemon.IsAlive)
				{
					Attack(_firstMemberData, _secondMemberData);
				}
			}
		}
		private void Attack(TurnData attacker, TurnData target)
		{
			target.Pokemon.TakeAttack(attacker.Pokemon, attacker.Move);
			turnLog.AppendLine($"{attacker.Pokemon.Name} Attack {target.Pokemon.Name} With {attacker.Move.Name} and deal {attacker.Move.Power} damage");
		}
		private void TurnEnd()
		{
			turnLog.AppendLine($"Turn {_turnNumber} Ended");
			_endData.SetEndData(_firstMemberData.Pokemon, _secondMemberData.Pokemon, turnLog.ToString());
		}

	}
}
