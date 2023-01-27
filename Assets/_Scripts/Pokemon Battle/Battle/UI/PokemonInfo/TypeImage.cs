using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeImage : MonoBehaviour
{
    public Image Icon;
    public TMP_Text Name;
    public Image Background;

    public virtual void SetData(ElementType type)
    {
        Icon.sprite = type.Icon;
        Icon.color = Color.white;
        Name.text = type.Name;
        Background.color = type.Color;
    }

    public virtual void SetNone()
    {
        Icon.color = Color.clear;
        Name.text = "";
        Background.color = Color.clear;
    }
}