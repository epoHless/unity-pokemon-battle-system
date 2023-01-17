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

    private float GetModifier(ElementType type)
    {
        if (IsNull(type)) return 0;
        if (IsResistant(type)) return 0.5f;
        if (IsWeak(type)) return 2f;

        return 1;
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
}