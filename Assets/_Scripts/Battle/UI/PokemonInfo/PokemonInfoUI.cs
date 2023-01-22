using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PokemonInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text Name;
    [SerializeField] private List<TypeImage> elementImages;
    [SerializeField] private List<MoveImage> moveImages;
    private void OnEnable()
    {
        PokemonSelectionUI.OnSelection += data =>
        {
            Name.text = data.pokemon.PokemonData.Name;

            foreach (var image in elementImages)
            {
                image.SetNone();
            }
            
            foreach (var image in moveImages)
            {
                image.SetNone();
            }
            
            for (int i = 0; i < data.pokemon.PokemonData.Types.Count; i++)
            {
                if(data.pokemon.PokemonData.Types[i]) elementImages[i].SetData(data.pokemon.PokemonData.Types[i]);
            }
            
            for (int i = 0; i < data.pokemon.Moves.Count; i++)
            {
                moveImages[i].SetData(data.pokemon.Moves[i]);
            }
        };
    }
}