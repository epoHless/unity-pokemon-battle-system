using System.Collections.Generic;
using UnityEngine;

public class PokemonBagManager : Singleton<PokemonBagManager>
{
    [SerializeField] private List<PokemonSelectionUI> pokemonSelectionUIs;
    [SerializeField] private Team team;
    
    public void SetUI()
    {
        for (int i = 0; i < team.pokemons.Count; i++)
        {
            if (team.pokemons[i])
            {
                pokemonSelectionUIs[i].SetData(team.pokemons[i]);
            }
            else
            {
                pokemonSelectionUIs[i].Deactivate();
            }
        }
    }
}

