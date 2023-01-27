[System.Serializable]
public class TurnEndBS : BattleState
{
    public override void OnEnter(BattleManager manager)
    {
        base.OnEnter(manager);
        
        CameraManager.Instance.UseSelectionCamera();
        BattleManager.Instance.ApplyPostTurnStatuses();
    }

    public override void OnUpdate(BattleManager manager)
    {
        base.OnUpdate(manager);
    }

    public override void OnExit(BattleManager manager)
    {
        base.OnExit(manager);
        BattleManager.Instance.round++;
        
        UIManager.Instance.ToggleMoves(false);
    }
}