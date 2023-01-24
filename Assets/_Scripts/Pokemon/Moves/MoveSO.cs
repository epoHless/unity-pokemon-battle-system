using System;
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
    
    [SubclassOf(typeof(MoveEffect))] [SerializeField]
    private int MoveEffect;
    private MoveEffect _MoveEffect;

    [SerializeReference] public List<MoveBlock> moveBlocks;

    // [SerializeField] public MoveParticle particlePrefab;
    public MoveParticle spawnedParticle { get; private set; }
    
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
            
            foreach (var elementType in owner.opponent.PokemonData.Types)
            {
                if (elementType.GetModifier(Type).Modifier == 0)
                {
                    yield return NotificationManager.Instance.ShowNotificationCOR($"{Name} doesn't affect {owner.opponent.PokemonData.Name}",1);
                    yield break;
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
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        CameraManager.Instance.UseMoveCamera(afflictedPokemon.transform);

        foreach (var block in moveBlocks)
        {
            yield return block.Execute(this, owner, afflictedPokemon);
        }
    }

    public IEnumerator ExecuteMove(Pokemon owner, bool value = true)
    {
        _MoveEffect = SubclassUtility.GetSubclassFromIndex<MoveEffect>(MoveEffect);
        yield return _MoveEffect.Execute(this, owner, owner);
    }

    public void MultiplyPower(float multiplier)
    {
        Power *= multiplier;
    }

    [ContextMenu("Add Particle")]
    public void AddParticle()
    {
        moveBlocks.Add(new ParticleBlock());
    }
    
    [ContextMenu("Add Damage")]
    public void AddDamage()
    {
        moveBlocks.Add(new DamageBlock());
    }
    
    [ContextMenu("Add Stat Modifier")]
    public void AddModifyStat()
    {
        moveBlocks.Add(new ChangeStatBlock());
    }
    
    [ContextMenu("Add Status")]
    public void AddStatus()
    {
        moveBlocks.Add(new ApplyStatus());
    }
}