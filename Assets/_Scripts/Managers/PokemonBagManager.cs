using System.Collections.Generic;
using UnityEngine;

public class PokemonBagManager : Singleton<PokemonBagManager>
{
    [SerializeField] private List<PokemonSelectionUI> pokemonSelectionUIs;
    [field: SerializeField] public Team team { get; private set; }

    [field: SerializeField] public List<Sprite> genders;

    public void SetUI()
    {
        for (int i = 0; i < team.pokemons.Count; i++)
        {
            if (team.pokemons[i])
            {
                pokemonSelectionUIs[i].SetData(team.pokemons[i]);
                pokemonSelectionUIs[i].SetPokemon(team.pokemons[i]);
            }
            else
            {
                pokemonSelectionUIs[i].Deactivate();
            }
        }
    }
}

