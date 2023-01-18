
public static class BattleTween
{
    public static void DealDamage(Move move, Pokemon pokemon)
    {
        float newHp = pokemon.battleStats.PS - move.Power;
        float startHp = pokemon.battleStats.PS;
        
        LeanTween.value(pokemon.gameObject, f =>
        {
            pokemon.battleStats.PS = f;
        }, startHp, newHp, .5f);
    }
}

