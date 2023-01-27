using TMPro;
using UnityEngine;

public class MoveImage : TypeImage
{
    [SerializeField] private TMP_Text PPs;
    
    public void SetData(Move move)
    {
        Icon.color = Color.white;
        Icon.sprite = move.moveSO.Type.Icon;
        Background.color = move.moveSO.Type.Color;
        Name.text = move.moveSO.Name;
        PPs.text = $"{move.currentPP}/{move.moveSO.PP}";
    }

    public override void SetNone()
    {
        base.SetNone();
    }
}

