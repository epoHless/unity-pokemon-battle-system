using System.Collections;
using UnityEngine;

[System.Serializable]
public class MoveBlock
{
    #if UNITY_EDITOR
    [HideInInspector] public string name;

    public MoveBlock()
    {
        name = ToString();
    }
    #endif

    public virtual IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        yield return null;
    }
}

