using UnityEngine;


public class DeBuffParticle : MoveParticle
{
    protected override void OnEnable()
    {
        base.OnEnable();
        
        // BattleStat.OnDeBuff += () => gameObject.SetActive(true);
    }
}

