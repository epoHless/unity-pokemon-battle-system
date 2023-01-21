using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokemonSelectionUI : MonoBehaviour
{
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text level;
    [SerializeField] private Image sprite;
    [SerializeField] private Image gender;
    [SerializeField] private Image fainted;
    [SerializeField] private Image health;

    public void SetData(Pokemon pokemon)
    {
        if (pokemon.IsFainted)
        {
            fainted.gameObject.SetActive(true);
        }
        else
        {
            name.text = pokemon.PokemonData.Name;
            level.text = $"Lv.{ pokemon.PokemonData.Level}";

            sprite.sprite = pokemon.PokemonData.Sprite;
            health.fillAmount = pokemon.battleStats.CurrentPS / pokemon.battleStats.MaxPS;
            // gender.sprite = pokemon.PokemonData.gender;
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}