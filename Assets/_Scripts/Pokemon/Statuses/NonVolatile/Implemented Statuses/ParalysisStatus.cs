using System.Collections;
using UnityEngine;

public class ParalysisStatus : PreTurnNonVolatileStatus
{
    public override IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        bool IsParalysed = Random.Range(0, 100) <= 25;

        if (IsParalysed)
        {
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.Name} is paralysed and unable to move!",1.5f);
            yield return manager.GetStatusParticle(manager.ParalyseStatus).PlayParticle(pokemon.transform.position);
            pokemon.CanAttack = false;
        }
        else pokemon.CanAttack = true;
    }
}