using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private CanvasHider ActivePanel;

    [field: SerializeField] public CanvasHider HUDPanel { get; private set; }
    [field: SerializeField] public CanvasHider MovesPanel { get; private set; }
    [field: SerializeField] public CanvasHider ActionsPanel { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        ActivePanel = ActionsPanel;
    }

    public void TogglePanel(bool toggle, CanvasHider Panel)
    {
        ActivePanel.ToggleCanvas(toggle).setOnComplete(() =>
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
}