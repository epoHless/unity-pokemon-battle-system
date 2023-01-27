using System;
using UnityEngine;

public class BuffParticle : MoveParticle
{
    protected override void OnEnable()
    {
        base.OnEnable();
        
        BattleStat.OnBuff += pokemon =>
        {
            transform.position = pokemon.transform.position;
            gameObject.SetActive(true);
        };
    }
}