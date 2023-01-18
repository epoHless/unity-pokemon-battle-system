[System.Serializable]
public class BattleStart : BattleState
{
    public override void OnEnter(BattleManager manager)
    {
        base.OnEnter(manager);

        LeanTween.delayedCall(2f, () =>
        {
            manager.ChangeState(new TurnStart());
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

