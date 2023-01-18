using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    [SerializeField] List<MoveButton> moveButtons;
    private Pokemon pokemon;

    private void Start()
    {
        pokemon = BattleManager.Instance.playerPokemon;
        
        for (int i = 0; i < pokemon.Moves.Count; i++)
        {
            if (pokemon.Moves[i])
            {
                moveButtons[i].gameObject.SetActive(true);
                moveButtons[i].OnActivation?.Invoke(pokemon.Moves[i]);
            }
        }
    }
}
