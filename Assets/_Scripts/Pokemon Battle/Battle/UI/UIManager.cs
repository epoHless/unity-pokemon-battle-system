﻿using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public CanvasHider ActivePanel { get; private set; }

    [field: SerializeField] public CanvasHider HUDPanel { get; private set; }
    [field: SerializeField] public CanvasHider MovesPanel { get; private set; }
    [field: SerializeField] public CanvasHider ActionsPanel { get; private set; }
    [field: SerializeField] public CanvasHider PokemonsPanel { get; private set; }
    [field: SerializeField] public CanvasHider TeamSelectionPanel { get; private set; }
    [field: SerializeField] public CanvasHider GameOverPanel { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        ActivePanel = TeamSelectionPanel;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete) && ActivePanel.previousPanel && BattleManager.Instance.GetCurrentState().GetType() != new PokemonFaintedBS().GetType())
        {
            TogglePanel(true, ActivePanel.previousPanel);
        }
    }
    
    public void TogglePanel(bool toggle, CanvasHider Panel)
    {
        ActivePanel.ToggleCanvas(!toggle).setOnComplete(() =>
        {
            ActivePanel = Panel;
            ActivePanel.ToggleCanvas(toggle);
        });
    }
    
    public void TogglePanel(bool toggle)
    {
        ActivePanel.ToggleCanvas(toggle);
    }

    public void ToggleMoves(bool toggle)
    {
        TogglePanel(toggle, MovesPanel);
    }
    
    public void ToggleActions(bool toggle)
    {
        TogglePanel(toggle, ActionsPanel);
    }
    
    public void ToggleHUD(bool toggle)
    {
        TogglePanel(toggle, HUDPanel);
    }
    
    public void TogglePokemons(bool toggle)
    {
        TogglePanel(toggle, PokemonsPanel);
    }
    
    public void ToggleTeamSelection(bool toggle)
    {
        TogglePanel(toggle, TeamSelectionPanel);
    }
    
    public void ToggleGameOver(bool toggle)
    {
        TogglePanel(toggle, GameOverPanel);
    }
}