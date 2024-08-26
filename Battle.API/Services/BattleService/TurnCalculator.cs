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
		private StringBuilder _turnLog;
		private TurnEndData _endData;

		public TurnEndData TurnEndData => _endData;
		public string TurnLog => _turnLog.ToString();
		public TurnCalculator(TurnData firstMember, TurnData secondMember, int turnNumber)
		{
			_firstMemberData = firstMember;
			_secondMemberData = secondMember;
			_turnNumber = turnNumber;

			_turnLog = new StringBuilder();

			_endData = new TurnEndData();
		}
		public void Calculate()
		{
			CalculateSpeed();
			StartTurn();
			TurnEnd();
		}
	
		private void CalculateSpeed()
		{
			firstAttackFirst = _firstMemberData.Pokemon.Speed >= _secondMemberData.Pokemon.Speed;
		}
		private void StartTurn()
		{
			_turnLog.AppendLine($"Turn {_turnNumber} Start");
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
			_turnLog.AppendLine($"{attacker.Pokemon.Name} Attack {target.Pokemon.Name} With {attacker.Move.Name} and deal {attacker.Move.Power} damage");
		}
		private void TurnEnd()
		{
			Console.WriteLine("TurnEnd Calculator");
			_turnLog.AppendLine($"Turn {_turnNumber} Ended");
			_endData.SetEndData(_firstMemberData.Pokemon, _secondMemberData.Pokemon, _turnLog.ToString());
		}

	}
}
