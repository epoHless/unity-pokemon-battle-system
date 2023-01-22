using System;
using MobileFramework.Subclass;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PokemonSelectionUI : MonoBehaviour, ISelectHandler
{
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text level;
    [SerializeField] private Image sprite;
    [SerializeField] private Image gender;
    [SerializeField] private Image fainted;
    [SerializeField] private Image health;

    private Button button;

    private Pokemon pokemon;

    public TurnMove turnMove;

    public static event Action<SelectionData> OnSelection; 

    private void Awake()
    {
        button = GetComponent<Button>();

        turnMove.pokemon = pokemon;
    }

    private void OnEnable()
    {
        button.onClick.AddListener(ChangePokemon);
    }

    private void ChangePokemon()
    {
        if (pokemon == BattleManager.Instance.GetActivePlayerPokemon()) return;
        
        BattleManager.Instance.OnSelectionMade?.Invoke(turnMove);
        UIManager.Instance.TogglePanel(false, UIManager.Instance.PokemonsPanel);
    }

    public void SetData(Pokemon pokemon)
    {
        name.text = pokemon.PokemonData.Name;
        level.text = $"Lv.{ pokemon.PokemonData.Level}";
        sprite.sprite = pokemon.PokemonData.Sprite;
        health.fillAmount = pokemon.battleStats.CurrentPS / pokemon.battleStats.MaxPS;
        gender.sprite = pokemon.PokemonData.gender == PokemonData.Gender.MALE ? PokemonBagManager.Instance.genders[0] : PokemonBagManager.Instance.genders[1];
        
        if (pokemon.IsFainted)
        {
            fainted.gameObject.SetActive(true);
            button.enabled = false;
        }
    }

    public void SetPokemon(Pokemon pokemon)
    {
        this.pokemon = pokemon;
        turnMove.pokemon = pokemon;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (OnSelection != null) OnSelection(new SelectionData(pokemon));
    }
    
    public struct SelectionData
    {
        public Pokemon pokemon;

        public SelectionData(Pokemon pokemon)
        {
            this.pokemon = pokemon;
        }
    }
}