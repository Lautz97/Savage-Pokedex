using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public PokemonJsonClass pokemonJson;

    public Pokemon pokemon;

    public List<AbilityJsonClass> abilityJsonList;

    public List<MoveJsonClass> moveJsonList;

    public void SetPokemon (PokemonJsonClass pjc) {
        pokemonJson = pjc;
    }

    public void SetPokemon(Pokemon p) {
        pokemon = p;
    }

}
