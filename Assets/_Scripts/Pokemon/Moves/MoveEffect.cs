using System.Collections;
using UnityEngine;

[System.Serializable]
public class MoveEffect
{
    public virtual IEnumerator Execute(MoveSO moveSo, Pokemon caster, Pokemon target)
    {
        yield return null;
        MobileFramework.Analytics.Logging.Message($"Move {GetType()} has been used on {target.name}", Color.green, true);
        moveSo.spawnedParticle.PlayParticle(target.transform.position);
    }
}