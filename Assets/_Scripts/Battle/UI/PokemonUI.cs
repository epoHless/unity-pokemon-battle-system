using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokemonUI : MonoBehaviour
{
    [SerializeField] private TMP_Text Name;
    [SerializeField] private TMP_Text level;
    [SerializeField] private Image sex;
    [SerializeField] private Image state;
    [SerializeField] private Image hp;

    [SerializeField] private Pokemon pokemon;

    [SerializeField] private List<Sprite> genders;

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        Name.text = pokemon.PokemonData.Name;
        level.text = $"LV.{pokemon.PokemonData.Level}";
        sex.sprite = pokemon.PokemonData.gender == PokemonData.Gender.MALE ? genders[1] : genders[0];
    }

    private void Update()
    {
        hp.fillAmount = (pokemon.battleStats.CurrentPS / pokemon.battleStats.MaxPS);
    }

    public void SetStateIcon(Sprite icon)
    {
        state.color = Color.white;
        state.sprite = icon;
    }

    public void RemoveStateIcon()
    {
        state.color = Color.clear;
    }
}
