using System;
using MobileFramework.Subclass;
using UnityEngine;

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
    
    public void ExecuteMove(Pokemon owner)
    {
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
        _MoveEffect.Execute(this, afflictedPokemon);
    }
}