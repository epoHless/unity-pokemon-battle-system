using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    public List<Pokemon> pokemons;

    public Pokemon GetTarget(Pokemon self)
    {
        return pokemons.Find(pokemon => pokemon != self);
    }
}

