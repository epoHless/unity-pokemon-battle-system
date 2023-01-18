[System.Serializable]
public class BattleState
{
    public virtual void OnEnter(BattleManager manager)
    {}
    public virtual void OnUpdate(BattleManager manager)
    {}
    public virtual void OnExit(BattleManager manager)
    {}
}