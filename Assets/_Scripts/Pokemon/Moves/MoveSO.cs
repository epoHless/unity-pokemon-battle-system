using System;
using System.Collections;
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
    [field: SerializeField] public int Power { get; private set; }
    [field: SerializeField] public int Accuracy { get; private set; }
    
    [SubclassOf(typeof(MoveEffect))] [SerializeField]
    private int MoveEffect;
    private MoveEffect _MoveEffect;

    [SerializeField] public MoveParticle particlePrefab;
    public MoveParticle spawnedParticle { get; private set; }
    
    public IEnumerator ExecuteMove(Pokemon owner)
    {
        if (owner.IsFainted) return null;

        if (moveTarget == MoveTarget.ENEMY)
        {
            float modifiedLevel = owner.battleStats.ACC.GetModifierValue() - owner.opponent.battleStats.EVS.GetModifierValue();
            bool hit = Accuracy * 1 > Random.Range(1, 101);

            if (!hit)
            {
                return NotificationManager.Instance.ShowNotification($"{owner.opponent.Name} dodged the attack!");
            }
            
            foreach (var elementType in owner.opponent.Types)
            {
                if (elementType.GetModifier(Type).Modifier == 0)
                {
                    return NotificationManager.Instance.ShowNotification($"{Name} doesn't affect {owner.opponent.Name}");
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
        
        if(!spawnedParticle)
        {
            spawnedParticle = Instantiate(particlePrefab, afflictedPokemon.transform);
        }
        
        spawnedParticle.transform.position = afflictedPokemon.transform.position;

        _MoveEffect = SubclassUtility.GetSubclassFromIndex<MoveEffect>(MoveEffect);
        return _MoveEffect.Execute(this,owner, afflictedPokemon);
    }
}