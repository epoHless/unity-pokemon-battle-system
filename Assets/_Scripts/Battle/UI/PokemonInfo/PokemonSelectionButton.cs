using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokemonSelectionButton : MonoBehaviour
{
    [SerializeField] private TMP_Text Name;
    [SerializeField] private Image Sprite;

    private Button button;
    private Pokemon pokemon;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(AddPokemonToList);
    }

    private void AddPokemonToList()
    {
        TeamSelection.Instance.OnPokemonSelected?.Invoke(pokemon);
        button.enabled = false;
    }

    public void SetData(Pokemon pokemon)
    {
        Name.text = pokemon.PokemonData.Name;
        Sprite.sprite = pokemon.PokemonData.Sprite;
        this.pokemon = pokemon;
    }
}

