using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MobileFramework.Subclass;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class BattleManager : Singleton<BattleManager>
{
    [SubclassOf(typeof(BattleState))]
    public int battleState;
    private BattleState currentState;
    
    public List<Pokemon> pokemons;

    public int round = 1;
    public List<TurnMove> turnMoves;
    
    public UnityEvent<TurnMove> OnSelectionMade;

    protected override void OnEnable()
    {
        base.OnEnable();
        OnSelectionMade.AddListener(AddMoveToTurn);
    }

    private void Start()
    {
        currentState = SubclassUtility.GetSubclassFromIndex<BattleState>(battleState);
        currentState.OnEnter(this);
    }

    private void Update()
    {
        currentState.OnUpdate(this);
    }

    private void AddMoveToTurn(TurnMove move)
    {
        turnMoves.Add(move);
        turnMoves.Add(new TurnMove(pokemons[1], pokemons[1].Moves[Random.Range(0, pokemons[1].Moves.Count)]));
    }

    public Pokemon GetTarget(Pokemon self)
    {
        return pokemons.Find(pokemon => pokemon != self);
    }

    public void ChangeState(BattleState newState)
    {
        currentState.OnExit(this);
        currentState = newState;
        currentState.OnEnter(this);
    }

    public void ResetTurnMoves()
    {
        turnMoves.Clear();
    }

    public void ExecuteMoves()
    {
        // turnMoves = turnMoves.OrderBy(move => move.pokemon.battleStats.SPD).ToList();
        StartCoroutine(nameof(UseMoves));
    }

    IEnumerator UseMoves()
    {
        turnMoves[0].Move.ExecuteMove(turnMoves[0].pokemon);
        yield return new WaitUntil(() => turnMoves[0].Move.moveSO.spawnedParticle.IsDone == true);
        turnMoves.RemoveAt(0);
        turnMoves[0].Move.ExecuteMove(turnMoves[0].pokemon);
        yield return new WaitUntil(() => turnMoves[0].Move.moveSO.spawnedParticle.IsDone == true);
        ChangeState(new TurnStart());
    }
}

