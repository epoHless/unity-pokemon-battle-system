using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleDamageBlock : MoveBlock
{
    public int min,max;
    
    [SerializeReference] public List<MoveBlock> moveBlocks;

    public override IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        var rand = Random.Range(min, max + 1);

        for (int i = 0; i < rand; i++)
        {
            if(afflictedPokemon.IsFainted) break;
            
            foreach (var block in moveBlocks)
            {
                yield return block.Execute(moveData, caster, afflictedPokemon);
            }
        }

        yield return NotificationManager.Instance.ShowNotificationCOR($"{moveData.Name} hit for {rand} times!", 1.5f);
    }
}