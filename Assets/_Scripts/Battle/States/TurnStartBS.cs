[System.Serializable]
public class TurnStartBS : BattleState
{
    public override void OnEnter(BattleManager manager)
    {
        base.OnEnter(manager);
        
        UIManager.Instance.ToggleHUD(true);
        UIManager.Instance.ToggleActions(true);
    }

    public override void OnUpdate(BattleManager manager)
    {
        base.OnUpdate(manager);
    }

    public override void OnExit(BattleManager manager)
    {
        base.OnExit(manager);
        
        UIManager.Instance.ToggleHUD(false);
    }
}