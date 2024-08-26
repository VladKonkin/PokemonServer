using Battle.API.Model;

namespace Battle.API.Services.BattleService.Models.BattleMembers
{
    public abstract class BattleMember
    {
        protected Battle _battle;
        protected TurnData _activeTurnData;
        protected List<Pokemon> _pokemonList;
        public TurnData ActiveTurnModel => _activeTurnData;
        public Action BattleTurnSetAction;
        public virtual Pokemon GetActivePokemon()
        {
            int pokemonIndex = 0;
            for (int i = 0; i < _pokemonList.Count; i++)
            {
                if (_pokemonList[i].IsAlive)
                {
                    pokemonIndex = i;
                    break;
                }
            }
            return _pokemonList[pokemonIndex];
        }
        public bool CanСontinueBattle()
        {
            Pokemon pokemonModel = _pokemonList.FirstOrDefault(p => p.IsAlive);
            return pokemonModel != null;
        }
        public virtual void SetBattle(Battle battle)
        {
            _battle = battle;
        }
        public bool IsReady()
        {
            return _activeTurnData != null;
        }
        public virtual void NexTurnStart()
        {
            _activeTurnData = null;
        }
        public abstract void SetTurnData(TurnData turnData);
        public abstract string GetId();

    }
}
