﻿public class BattleEndBS : BattleState
{
    public override void OnEnter(BattleManager manager)
    {
        base.OnEnter(manager);
        
        UIManager.Instance.TogglePanel(false, UIManager.Instance.HUDPanel);
        UIManager.Instance.ToggleGameOver(true);
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
