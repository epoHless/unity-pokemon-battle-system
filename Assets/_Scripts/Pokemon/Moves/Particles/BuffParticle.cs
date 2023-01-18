using System;
using UnityEngine;

public class BuffParticle : MoveParticle
{
    protected override void OnEnable()
    {
        base.OnEnable();
        
        // BattleStat.OnBuff += () => gameObject.SetActive(true);
    }
    
}