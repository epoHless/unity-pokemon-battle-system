using System;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [field: SerializeField] public List<Pokemon> pokemons { get; private set; }
    [field: SerializeField] public Pokemon activePokemon { get; set; }
}