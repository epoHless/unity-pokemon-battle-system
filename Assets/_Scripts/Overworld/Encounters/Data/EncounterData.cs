using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EncounterData_", menuName = "Encounters/New Encounter Data", order = 0)]
public class EncounterData : ScriptableObject
{
    [Header("Encounter Settings")]
    [SerializeField, Range(0, 100)] private float encounterProbability;
    [SerializeField] private List<EncounterEntry> possibleEncounters;

    public string RollEncounter()
    {
        bool HasEncouteres = Random.Range(0, 100) < encounterProbability;

        if (HasEncouteres)
        {
            return possibleEncounters[Random.Range(0, possibleEncounters.Count)].PokemonName;
        }
        else
        {
            return "No encounter";
        }
    }
}
