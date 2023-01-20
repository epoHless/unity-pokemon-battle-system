using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : Singleton<BattleUI>
{
    [SerializeField] List<MoveButton> moveButtons;
    public Pokemon pokemon { get; private set; }

    public void SetUI()
    {
        pokemon = BattleManager.Instance.GetActivePlayerPokemon();
        
        for (int i = 0; i < pokemon.Moves.Count; i++)
        {
            if (pokemon.Moves[i].moveSO)
            {
                moveButtons[i].gameObject.SetActive(true);
                moveButtons[i].UpdateUI(pokemon, pokemon.Moves[i]);
            }
        }
    }
}
