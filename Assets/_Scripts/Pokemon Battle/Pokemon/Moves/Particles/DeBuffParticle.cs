using System.Collections;
using UnityEngine;

public class DeBuffParticle : MoveParticle
{
    protected override void OnEnable()
    {
        base.OnEnable();

        BattleStat.OnDeBuff += pokemon =>
        {
            transform.position = pokemon.transform.position;
            gameObject.SetActive(true);
        };
    }
}

