using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [field: SerializeField] public CanvasHider PlayerPanel { get; private set; }

    public void ToggleMoves(bool toggle)
    {
        PlayerPanel.ToggleCanvas(toggle);
    }
}