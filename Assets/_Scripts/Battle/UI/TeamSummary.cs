using System;
using System.Collections.Generic;
using UnityEngine;

public class TeamSummary : MonoBehaviour
{
    [SerializeField] private List<PokemonSummaryUI> summaryUis;
    [SerializeField] private Team team;

    private void Start()
    {
        BattleManager.Instance.OnBattleEnd?.AddListener(SetSummary);
    }

    public void SetSummary()
    {
        for (int i = 0; i < team.pokemons.Count; i++)
        {
            summaryUis[i].SetData(team.pokemons[i]);
        }
    }
}

