[System.Serializable]
public class PokemonFaintedBS : BattleState
{
    public override void OnEnter(BattleManager manager)
    {
        base.OnEnter(manager);
        
        
        PokemonBagManager.Instance.SetUI();
        
        UIManager.Instance.ToggleHUD(true);
        UIManager.Instance.TogglePokemons(true);
    }

    public override void OnUpdate(BattleManager manager)
    {
        base.OnUpdate(manager);
    }

    public override void OnExit(BattleManager manager)
    {
        base.OnExit(manager);
        
        UIManager.Instance.TogglePokemons(false);
    }
}