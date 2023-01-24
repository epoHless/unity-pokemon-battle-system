using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeamSelection : Singleton<TeamSelection>
{
    [SerializeField] private List<Pokemon> availablePokemons;
    
    [SerializeField] private PokemonSelectionButton buttonPrefab;
    [SerializeField] private Transform parent;

    public UnityEvent<Pokemon> OnPokemonSelected;

    [SerializeField] private Team playerTeam, opponentTeam; 

    protected override void OnEnable()
    {
        base.OnEnable();
        
        OnPokemonSelected.AddListener(pokemon =>
        {
            playerTeam.pokemons.Add(pokemon);
            pokemon.transform.position = playerTeam.gameObject.transform.position;
            pokemon.transform.rotation = playerTeam.gameObject.transform.rotation;

            availablePokemons.Remove(pokemon);

            if (availablePokemons.Count == 6)
            {
                foreach (var availablePokemon in availablePokemons)
                {
                    opponentTeam.pokemons.Add(availablePokemon);
                    availablePokemon.transform.position = opponentTeam.gameObject.transform.position;
                    availablePokemon.transform.rotation = opponentTeam.gameObject.transform.rotation;
                }

                playerTeam.activePokemon = playerTeam.pokemons[0];
                opponentTeam.activePokemon = opponentTeam.pokemons[0];
                
                BattleManager.Instance.ChangeState(new BattleStartBS());
                UIManager.Instance.TogglePanel(false);
            }
        });
    }

    public void InstantiateButtons()
    {
        foreach (var pokemon in availablePokemons)
        {
            var button = Instantiate(buttonPrefab, parent);
            button.SetData(pokemon);
        }
    }
}

