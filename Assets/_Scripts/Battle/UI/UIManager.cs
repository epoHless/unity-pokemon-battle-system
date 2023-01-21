using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [field: SerializeField] public CanvasHider MovesPanel { get; private set; }
    [field: SerializeField] public CanvasHider ActionsPanel { get; private set; }

    public void ToggleMoves(bool toggle)
    {
        MovesPanel.ToggleCanvas(toggle);
    }
}