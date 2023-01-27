using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Type_", menuName = "Pokemon/New Type", order = 0)]
public class ElementType : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public Color Color { get; private set; }

    [SerializeField] private List<ElementType> WeakAgainst;
    [SerializeField] private List<ElementType> ResistAgainst;
    [SerializeField] private List<ElementType> NullAgainst;

    public ModifierInfo GetModifier(ElementType type)
    {
        if (IsNull(type)) return new ModifierInfo(0, "It doesn't affect the pokemon...");
        if (IsResistant(type)) return new ModifierInfo(0.5f, "Not very effective...");
        if (IsWeak(type)) return new ModifierInfo(2, "Super effective");;
        
        return new ModifierInfo(1, null);;
    }
    
    private bool IsWeak(ElementType type)
    {
        return WeakAgainst.Contains(type);
    }

    private bool IsResistant(ElementType type)
    {
        return ResistAgainst.Contains(type);
    }

    private bool IsNull(ElementType type)
    {
        return NullAgainst.Contains(type);
    }

    public struct ModifierInfo
    {
        public float Modifier;
        public string ModifierMessage;

        public ModifierInfo(float modifier, string modifierMessage)
        {
            Modifier = modifier;
            ModifierMessage = modifierMessage;
        }
    }
}