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
            BattleManager.Instance.OnSelectionMade?.Invoke(new TurnMove(BattleManager.Instance.ActivePokemons[0], buttonMove));
            BattleManager.Instance.ChangeState(new ExecuteMovesBS());
            PPs.text = $"{buttonMove.currentPP}/{buttonMove.moveSO.PP.ToString()}";
        }
    }

    private void OnEnable()
    {
        OnActivation.AddListener(SetMove);
    }

    private void OnDisable()
    {
        OnActivation.RemoveListener(SetMove);
    }

    public void UpdateUI(Pokemon pokemon, Move move)
    {
        name.text = move.moveSO.Name;
        PPs.text = $"{move.currentPP}/{move.moveSO.PP.ToString()}";
        type.sprite = move.moveSO.Type.Icon;
        background.color = move.moveSO.Type.Color;

        buttonMove = move;
        
        if (move.moveSO.moveType != MoveSO.MoveType.STATUS)
        {
            foreach (var elementType in pokemon.opponent.Types)
            {
                if (elementType.GetModifier(move.moveSO.Type).Modifier == 0)
                {
                    effectiveness.text = "No effect";
                }else if (elementType.GetModifier(move.moveSO.Type).Modifier == 1f)
                {
                    effectiveness.text = "Effective";
                } else if (elementType.GetModifier(move.moveSO.Type).Modifier == .5f)
                {
                    effectiveness.text = "Not very effective";
                }else if (elementType.GetModifier(move.moveSO.Type).Modifier == 2)
                {
                    effectiveness.text = "Super effective";
                }
            }
        }
        else effectiveness.text = "";
    }
    
    private void SetMove(Move move)
    {
        buttonMove = move;
    }
}