[System.Serializable]
public class TurnStartBS : BattleState
{
    public override void OnEnter(BattleManager manager)
    {
        base.OnEnter(manager);
        
        UIManager.Instance.ToggleMoves(true);
    }

    public override void OnUpdate(BattleManager manager)
    {
        base.OnUpdate(manager);
    }

    public override void OnExit(BattleManager manager)
    {
        base.OnExit(manager);
        
        UIManager.Instance.ToggleMoves(false);
    }
}