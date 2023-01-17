using System;
using MobileFramework.Subclass;
using UnityEngine;

[CreateAssetMenu(fileName = "Move_", menuName = "Pokemon/New Move", order = 0)]
public class Move : ScriptableObject
{
    public enum MoveType
    {
        PHYSICAL,
        SPECIAL,
        STATUS
    }
    
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public MoveType moveType { get; private set; }
    [field: SerializeField] public ElementType Type { get; private set; }
    [field: SerializeField] public int PP { get; private set; }
    [field: SerializeField] public int Power { get; private set; }
    [field: SerializeField] public int Accuracy { get; private set; }

    [SerializeField] private bool IsTargetSelf = false;
    
    [SubclassOf(typeof(MoveEffect))] [SerializeField]
    private int MoveEffect;
    private MoveEffect _MoveEffect;

    public void ExecuteMove(Pokemon afflictedPokemon)
    {
        // var afflictedPokemon = IsTargetSelf ? BattleManager.Instance.playerPokemon : BattleManager.Instance.enemyPokemon;
        
        _MoveEffect = SubclassUtility.GetSubclassFromIndex<MoveEffect>(MoveEffect);
        _MoveEffect.Execute(this, afflictedPokemon);
    }
}