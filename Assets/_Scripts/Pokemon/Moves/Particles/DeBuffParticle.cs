using System.Collections;
using UnityEngine;

public class DeBuffParticle : MoveParticle
{
    protected override void OnEnable()
    {
        base.OnEnable();
        
        // BattleStat.OnDeBuff += () => gameObject.SetActive(true);
    }

    public IEnumerator ShowDecrease(Pokemon pokemon)
    {
        gameObject.transform.position = pokemon.transform.position;
        gameObject.SetActive(true);
        yield return new WaitUntil(() => IsDone);
    }
}

