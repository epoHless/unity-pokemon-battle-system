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
    
    public List<Pokemon> ActivePokemons;
    
    public Team PlayerTeam;
    public Team OpponentTeam;

    public int round = 1;
    public List<TurnMove> turnMoves;
    
    public UnityEvent<TurnMove> OnSelectionMade;
    public UnityEvent<Pokemon> OnPokemonFaint; 
    
    #region UNITY FUNCTIONS
    
    protected override void OnEnable()
    {
        base.OnEnable();
        
        OnSelectionMade.AddListener(AddMoveToTurn);
        OnPokemonFaint.AddListener(FaintPokemon);
    }

    private IEnumerator Start()
    {
        yield return InitialisePokemons();
        
        currentState = SubclassUtility.GetSubclassFromIndex<BattleState>(battleState);
        currentState.OnEnter(this);
    }

    private void Update()
    {
        currentState?.OnUpdate(this);
    }

    #endregion

    #region INITIALISATION

    private IEnumerator InitialisePokemons()
    {
        bool IsDone = false;
        
        ActivePokemons.Add(PlayerTeam.activePokemon);
        ActivePokemons.Add(OpponentTeam.activePokemon);

        foreach (var pokemon in ActivePokemons)
        {
            pokemon.SetOpponent();
            CameraManager.Instance.UseMoveCamera(pokemon.transform);
            yield return NotificationManager.Instance.ShowNotificationCOR($"Trainer sent out {pokemon.PokemonData.Name}!", 1f);
            LeanTween.scale(pokemon.gameObject, Vector3.one, .3f).setOnComplete((() => IsDone = true));
            yield return new WaitUntil((() => IsDone));
            IsDone = false;
        }
    }

    public IEnumerator ChangePokemon(Pokemon pokemon, Team team, bool player = true)
    {
        Pokemon calledOutPokemon = player ? GetActivePlayerPokemon() : GetActiveOpponentPokemon();
        
        yield return NotificationManager.Instance.ShowNotificationCOR($"{calledOutPokemon.PokemonData.Name} was called out!");

        bool IsDone = false;
        LeanTween.scale(calledOutPokemon.gameObject, Vector3.zero, .25f).setOnComplete((() => IsDone = true));
        yield return new WaitUntil((() => IsDone));

        ActivePokemons.Remove(calledOutPokemon);
        ActivePokemons.Add(pokemon);
        
        pokemon.ui.UpdateUI();
        BattleUI.Instance.SetUI();
        
        yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.PokemonData.Name} was sent in!");
        
        IsDone = false;
        LeanTween.scale(pokemon.gameObject, Vector3.zero, .25f).setOnComplete((() => IsDone = true));
        yield return new WaitUntil((() => IsDone));

        foreach (var activePokemon in ActivePokemons)
        {
            pokemon.SetOpponent();
        }
    }

    #endregion
    
    #region GET POKEMONS

    public Pokemon GetActivePlayerPokemon()
    {
        foreach (var pokemon in PlayerTeam.pokemons)
        {
            if (ActivePokemons.Contains(pokemon))
            {
                return pokemon;
            }
        }

        return null;
    }
    
    public Pokemon GetActiveOpponentPokemon()
    {
        foreach (var pokemon in OpponentTeam.pokemons)
        {
            if (ActivePokemons.Contains(pokemon))
            {
                return pokemon;
            }
        }

        return null;
    }
    
    private bool IsPlayerPokemon(Pokemon pokemon) { return PlayerTeam.pokemons.Contains(pokemon); }
    private bool IsOpponentPokemon(Pokemon pokemon) { return OpponentTeam.pokemons.Contains(pokemon); }

    private void FaintPokemon(Pokemon pokemon)
    {
        pokemon.IsFainted = true;
        StopCoroutine(nameof(UseMoves));
        
        LeanTween.scale(pokemon.gameObject, Vector3.zero, 1f).setOnComplete((() =>
        {
            NotificationManager.Instance.ShowNotification(IsPlayerPokemon(pokemon) ? "You lost!" : "You won!");

            ChangeState(new PokemonFaintedBS());
        }));
    }
    
    public Pokemon GetOpponent(Pokemon self)
    {
        return ActivePokemons.Find(pokemon => pokemon != self);
    }
    
    #endregion

    #region TURNS

    private void AddMoveToTurn(TurnMove move)
    {
        turnMoves.Add(move);
        turnMoves.Add(new TurnMove(GetActiveOpponentPokemon(), GetActiveOpponentPokemon().Moves[Random.Range(0, ActivePokemons[1].Moves.Count)]));
    }

    public void ResetTurnMoves()
    {
        turnMoves.Clear();
    }

    public void ExecuteMoves()
    {
        StartCoroutine(nameof(UseMoves));
    }
    
    IEnumerator UseMoves()
    {
        var order = turnMoves.OrderByDescending(move => move.pokemon.battleStats.SPD.Value).ToList();
        
        for (int i = 0; i < order.Count; i++)
        {
            yield return ApplyPreTurnStatusesCOR(order[i].pokemon);

            if (order[i].pokemon.CanAttack && !order[i].pokemon.IsFainted)
            {
                yield return order[i].Move.ExecuteMove(order[i].pokemon);
            }
        }

        ChangeState(new TurnEndBS());
    }

    #endregion

    #region STATE MANAGEMENT

    public void ChangeState(BattleState newState)
    {
        currentState.OnExit(this);
        currentState = newState;
        currentState.OnEnter(this);
    }

    #endregion

    #region STATUS APPLY

    public void ApplyPostTurnStatuses()
    {
        StartCoroutine(nameof(ApplyPostTurnStatusesCOR));
    }
    
    private IEnumerator ApplyPreTurnStatusesCOR(Pokemon pokemon)
    {
        for (int i = 0; i < pokemon.statuses.Count; i++)
        {
            if (pokemon.statuses[i] is PreTurnNonVolatileStatus)
            {
                yield return pokemon.statuses[i].Execute(StatusManager.Instance, pokemon);
            }
        }
    }
    
    private IEnumerator ApplyPostTurnStatusesCOR()
    {
        // yield return CheckForCameraBlending.Instance.WaitForBlend();
        
        foreach (var pokemon in ActivePokemons)
        {
            foreach (var status in pokemon.statuses)
            {
                if (status is PostTurnNonVolatileStatus)
                {
                    yield return status.Execute(StatusManager.Instance, pokemon);
                }
            }
        }
        
        foreach (var pokemon in ActivePokemons)
        {
            foreach (var status in pokemon.statuses)
            {
                if (status is PostTurnVolatileStatus)
                {
                    yield return status.Execute(StatusManager.Instance, pokemon);
                }
            }
        }
        
        ChangeState(new TurnStartBS());
    }

    #endregion
}