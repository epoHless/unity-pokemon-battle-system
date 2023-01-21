using System;
using MobileFramework.Subclass;
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

    private Button button;

    private Pokemon pokemon;
    
    public MoveEffect moveEffect;

    public TurnMove turnMove;
    
    private void Awake()
    {
        button = GetComponent<Button>();
        moveEffect = new ChangePokemon();

        turnMove.pokemon = pokemon;
    }

    private void OnEnable()
    {
        button.onClick.AddListener(ChangePokemon);
    }

    private void ChangePokemon()
    {
        BattleManager.Instance.OnSelectionMade?.Invoke(turnMove);
    }

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
            gender.sprite = pokemon.PokemonData.gender == PokemonData.Gender.MALE ? PokemonBagManager.Instance.genders[0] : PokemonBagManager.Instance.genders[1];
        }
    }

    public void SetPokemon(Pokemon pokemon)
    {
        this.pokemon = pokemon;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}