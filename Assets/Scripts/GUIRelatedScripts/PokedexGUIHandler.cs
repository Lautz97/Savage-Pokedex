using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokedexGUIHandler : MonoBehaviour
{
    public Pokemon pokemon;
    public Image image;
    public Text pokemonCode;
    public Text pokemonName;
    public Button pokeSheetBtn;

    public PokeSheetGUIHandler pokeSheet;

    public void AssociateSearchResult(Pokemon pokemon) {

        this.pokemon = pokemon;
        image.sprite = pokemon.image;
        pokemonName.text = pokemon.name;
        pokemonCode.text = pokemon.numero.ToString();

        pokeSheetBtn.interactable = true;

        pokeSheet.PopulateSheet(pokemon);

    }

    public void AssociateAbilitiesSearchResult() {
        pokeSheet.PopulateSheetAbilità(pokemon);
    }
    public void AssociateMovesSearchResult() {
        pokeSheet.PopulateSheetMosse(pokemon);
    }



}
