[System.Serializable]
public class TeamPickBS : BattleState
{
    public override void OnEnter(BattleManager manager)
    {
        TeamSelection.Instance.InstantiateButtons();
        UIManager.Instance.ToggleTeamSelection(true);
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