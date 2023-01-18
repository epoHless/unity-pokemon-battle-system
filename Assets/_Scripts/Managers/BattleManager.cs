using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BattleManager : Singleton<BattleManager>
{
    public List<Pokemon> pokemons;

    public int round = 1;
    public List<Move> turnMoves;
    
    public UnityEvent<Move> OnSelectionMade;

    protected override void OnEnable()
    {
        base.OnEnable();
        
        OnSelectionMade.AddListener(StartMovePhase);
    }

    private void StartMovePhase(Move move)
    {
        turnMoves.Add(move);
    }

    public Pokemon GetTarget(Pokemon self)
    {
        return pokemons.Find(pokemon => pokemon != self);
    }
}

