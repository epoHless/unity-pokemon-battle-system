using System.Collections;
using UnityEngine;

[System.Serializable]
public class MoveEffect
{
    public virtual IEnumerator Execute(MoveSO moveSo, Pokemon caster, Pokemon target)
    {
        yield return null;
    }
}