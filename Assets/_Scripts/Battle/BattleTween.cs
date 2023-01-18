
public static class BattleTween
{
    public static void DealDamage(MoveSO moveSo, Pokemon pokemon)
    {
        float newHp = pokemon.battleStats.CurrentPS - moveSo.Power;
        float startHp = pokemon.battleStats.CurrentPS;
        
        LeanTween.value(pokemon.gameObject, f =>
        {
            pokemon.battleStats.CurrentPS = f;
        }, startHp, newHp, .35f);
    }
}

