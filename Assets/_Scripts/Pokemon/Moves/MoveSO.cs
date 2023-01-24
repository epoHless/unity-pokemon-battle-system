﻿using System;
using System.Collections;
using System.Collections.Generic;
using MobileFramework.Subclass;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Move_", menuName = "Pokemon/New Move", order = 0)]
public class MoveSO : ScriptableObject
{
    public enum MoveType
    {
        PHYSICAL,
        SPECIAL,
        STATUS
    }
    
    public enum MoveTarget
    {
        SELF,
        ENEMY
    }
    
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public MoveType moveType { get; private set; }
    [field: SerializeField] public MoveTarget moveTarget { get; private set; }
    [field: SerializeField] public ElementType Type { get; private set; }
    [field: SerializeField] public int PP { get; private set; }
    [field: SerializeField] public float Power { get; private set; }
    [field: SerializeField] public int Accuracy { get; private set; }

    [SerializeReference] public List<MoveBlock> moveBlocks;
    
    public IEnumerator ExecuteMove(Pokemon owner)
    {
        if (owner.IsFainted) yield return null;

        if (moveTarget == MoveTarget.ENEMY)
        {
            bool hit = Accuracy * 1 > Random.Range(1, 101);

            if (!hit)
            {
                yield return NotificationManager.Instance.ShowNotificationCOR($"{owner.opponent.PokemonData.Name} dodged the attack!",1.5f);
                yield break;
            }

            if (moveType != MoveType.STATUS)
            {
                foreach (var elementType in owner.opponent.PokemonData.Types)
                {
                    if (elementType.GetModifier(Type).Modifier == 0)
                    {
                        yield return NotificationManager.Instance.ShowNotificationCOR($"{Name} doesn't affect {owner.opponent.PokemonData.Name}",1);
                        yield break;
                    }
                }
            }
        }

        Pokemon afflictedPokemon = null;

        switch (moveTarget)
        {
            case MoveTarget.SELF:
                afflictedPokemon = owner;
                break;
            case MoveTarget.ENEMY:
                afflictedPokemon = owner.opponent;
                break;
        }
        
        CameraManager.Instance.UseMoveCamera(afflictedPokemon.transform);

        foreach (var block in moveBlocks)
        {
            yield return block.Execute(this, owner, afflictedPokemon);
        }
    }

    public IEnumerator ExecuteMove(Pokemon owner, bool value = true)
    {
        foreach (var block in moveBlocks)
        {
            yield return block.Execute(this, owner, owner);
        }
    }

    public void MultiplyPower(float multiplier)
    {
        Power *= multiplier;
    }

    #region BLOCK BUILDERS

    [ContextMenu("Add Particle")]
    public void AddParticle()
    {
        moveBlocks.Add(new ParticleBlock());
    }
    
    [ContextMenu("Damage/Add Damage")]
    public void AddDamage()
    {
        moveBlocks.Add(new DamageBlock());
    }
    
    [ContextMenu("Damage/Add Damage with Heal")]
    public void AddDamageNHeal()
    {
        moveBlocks.Add(new DamageAndHealBlock());
    }
    
    [ContextMenu("Damage/Add Damage with Recoil")]
    public void AddDamageNRecoil()
    {
        moveBlocks.Add(new DamageAndRecoilBlock());
    }
    
    [ContextMenu("Damage/Add Damage with Multiplier")]
    public void AddDamageMultiplied()
    {
        moveBlocks.Add(new DamageMultipliedBlock());
    }
    
    [ContextMenu("Add Stat Modifier")]
    public void AddModifyStat()
    {
        moveBlocks.Add(new ChangeStatBlock());
    }
    
    [ContextMenu("Status/Add Non Volatile Status")]
    public void AddNVStatus()
    {
        moveBlocks.Add(new ApplyNonVolatileStatus());
    }
    
    [ContextMenu("Status/Add Volatile Status")]
    public void AddVStatus()
    {
        moveBlocks.Add(new ApplyVolatileStatus());
    }
    
    [ContextMenu("Add Pokemon Change")]
    public void AddPKMNChange()
    {
        moveBlocks.Add(new PokemonSwapBlock());
    }

    #endregion
}