using UnityEngine;

[System.Serializable]
public class BattleState
{
    public virtual void OnEnter(BattleManager manager)
    { MobileFramework.Analytics.Logging.Message($"Current state: {ToString()}", Color.cyan); }
    public virtual void OnUpdate(BattleManager manager)
    {}
    public virtual void OnExit(BattleManager manager)
    {}
}