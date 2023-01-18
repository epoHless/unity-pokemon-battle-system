using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class ExecuteMoves : BattleState
{
    public override void OnEnter(BattleManager manager)
    {
        base.OnEnter(manager);

        BattleManager.Instance.ExecuteMoves();
    }

    public override void OnUpdate(BattleManager manager)
    {
        base.OnUpdate(manager);
    }

    public override void OnExit(BattleManager manager)
    {
        base.OnExit(manager);
        
        BattleManager.Instance.ResetTurnMoves();
    }
}