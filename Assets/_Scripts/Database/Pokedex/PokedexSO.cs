using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokedex", menuName = "Database/Create Pokedex", order = 0)]
public class PokedexSO : ScriptableObject
{
    public List<PokedexEntry> pokedexEntries;

    [ContextMenu("Create Entries")]
    public void SetEntries()
    {
        pokedexEntries = new List<PokedexEntry>();
        pokedexEntries = PokedexReader.GetPokedexEntries();
    }
}

