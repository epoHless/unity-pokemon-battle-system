using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasHider : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    [field: SerializeField] public CanvasHider previousPanel { get; private set; }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        ToggleCanvas(false);
    }

    public LTDescr ToggleCanvas(bool toggle)
    {
        canvasGroup.interactable = toggle;
        canvasGroup.blocksRaycasts = toggle;
        
        var to = toggle ? 1 : 0;

        return LeanTween.value(gameObject, f =>
        {
            canvasGroup.alpha = f;
        }, canvasGroup.alpha, to, .25f);
    }
}