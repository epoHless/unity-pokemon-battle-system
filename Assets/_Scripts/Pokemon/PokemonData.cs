using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "PokemonData_", menuName = "Pokemon/New Pokemon Data", order = 0)]
    public class PokemonData : ScriptableObject
    {
        public enum Gender
        {
            MALE,
            FEMALE
        }
        
        [field: SerializeField] public string Name { get; private set; }
        
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public int Level { get; private set; }
        [field: SerializeField] public Gender gender { get; private set; }
        [field: SerializeField] public List<ElementType> Types { get; private set; }
    }

