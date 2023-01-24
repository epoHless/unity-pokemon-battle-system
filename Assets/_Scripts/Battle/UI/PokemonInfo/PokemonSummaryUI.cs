using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokemonSummaryUI : MonoBehaviour
{
    [SerializeField] private TMP_Text Name;
    [SerializeField] private Image Sprite;
    [SerializeField] private Image Health;
    [SerializeField] private Image Fainted;

    public void SetData(Pokemon pokemon)
    {
        Name.text = pokemon.PokemonData.Name;
        Sprite.sprite = pokemon.PokemonData.Sprite;
        Health.fillAmount = pokemon.battleStats.CurrentPS / pokemon.battleStats.MaxPS; 
        
        Fainted.gameObject.SetActive(pokemon.IsFainted);
    }
}

