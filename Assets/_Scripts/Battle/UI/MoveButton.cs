using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text effectiveness;
    [SerializeField] private TMP_Text PPs;
    [SerializeField] private Image type;
    [SerializeField] private Image background;

    private Button button;

    public UnityEvent<Move> OnActivation;
    private Move buttonMove;
    
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CallMove);
    }

    private void CallMove()
    {
        if (buttonMove)
        {
            buttonMove.ExecuteMove(BattleManager.Instance.enemyPokemon);
        }
    }

    private void OnEnable()
    {
        OnActivation.AddListener(UpdateUI);
        OnActivation.AddListener(SetMove);
    }

    private void OnDisable()
    {
        OnActivation.RemoveListener(UpdateUI);
        OnActivation.RemoveListener(SetMove);
    }

    private void UpdateUI(Move move)
    {
        name.text = move.Name;
        // effectiveness.text = pokemon.Types[0].GetModifier(pokemon.Types[0])
        PPs.text = move.PP.ToString();
        type.sprite = move.Type.Icon;
        background.color = move.Type.Color;
    }
    
    private void SetMove(Move move)
    {
        buttonMove = move;
    }
}