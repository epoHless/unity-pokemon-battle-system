﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [field: SerializeField] public List<Pokemon> pokemons { get; private set; }
    [field: SerializeField] public Pokemon activePokemon { get; private set; }

    private void Awake()
    {
        DisableTeam();
        activePokemon = pokemons[0];
    }

    private void DisableTeam()
    {
        foreach (var pokemon in pokemons)
        {
            pokemon.transform.localScale = Vector3.zero;
        }
    }
}