[System.Serializable]
public class BattleStartBS : BattleState
{
    public override void OnEnter(BattleManager manager)
    {
        base.OnEnter(manager);
        
        CameraManager.Instance.UseSelectionCamera();
        
        LeanTween.delayedCall(2f, () =>
        {
            BattleUI.Instance.SetUI();
            manager.ChangeState(new TurnStartBS());
        });
    }

    public override void OnUpdate(BattleManager manager)
    {
        base.OnUpdate(manager);
    }

    public override void OnExit(BattleManager manager)
    {
        base.OnExit(manager);
    }
}

