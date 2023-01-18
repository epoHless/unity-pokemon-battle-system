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
        if (buttonMove.moveSO)
        {
            // buttonMove.ExecuteMove(BattleManager.Instance.pokemons[0]);
            BattleManager.Instance.OnSelectionMade?.Invoke(new TurnMove(BattleManager.Instance.pokemons[0], buttonMove));
            BattleManager.Instance.ChangeState(new ExecuteMoves());
            PPs.text = $"{buttonMove.currentPP}-{buttonMove.moveSO.PP.ToString()}";
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
        name.text = move.moveSO.Name;
        PPs.text = $"{move.currentPP}-{move.moveSO.PP.ToString()}";
        type.sprite = move.moveSO.Type.Icon;
        background.color = move.moveSO.Type.Color;

        if (move.moveSO.moveType != MoveSO.MoveType.STATUS)
        {
            if (move.moveSO.Type.GetModifier(BattleManager.Instance.pokemons[1].Types[0]) == 0)
            {
                effectiveness.text = "No effect";
            }else if (move.moveSO.Type.GetModifier(BattleManager.Instance.pokemons[1].Types[0]) == 1)
            {
                effectiveness.text = "Effective";
            } else if (move.moveSO.Type.GetModifier(BattleManager.Instance.pokemons[1].Types[0]) == .5f)
            {
                effectiveness.text = "Not very effective";
            }else if (move.moveSO.Type.GetModifier(BattleManager.Instance.pokemons[1].Types[0]) == 2)
            {
                effectiveness.text = "Super effective";
            }
        }
        else effectiveness.text = "";
    }
    
    private void SetMove(Move move)
    {
        buttonMove = move;
    }
}