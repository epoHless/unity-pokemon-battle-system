﻿using System.Collections;
using UnityEngine;

public class WaterGun : MoveEffect
{
    public override IEnumerator Execute(MoveSO moveSo,Pokemon caster, Pokemon afflictedPokemon)
    {
        yield return moveSo.spawnedParticle.PlayParticle(afflictedPokemon.transform.position + Vector3.up * 0.5f);
        yield return BattleTween.DealDamage(moveSo, caster,afflictedPokemon);
    }
}