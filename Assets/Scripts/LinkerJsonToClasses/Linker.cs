using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linker : MonoBehaviour
{
    
    public PokedexGUIHandler pokedexGUI;
    public SearchHandler searchHandler;

    public void Link(PokemonJsonClass pokemonJson, Sprite sprite, Downloader.MotivoRicerca motivoRicerca) {

        Pokemon pokemon = GetComponent<LinkerPokemon>().LinkPokemon(pokemonJson, sprite);
        
        if (motivoRicerca == Downloader.MotivoRicerca.Pokedex) {
            pokedexGUI.AssociateSearchResult(pokemon);
            searchHandler.SearchForThis(Downloader.OggettoRicerca.Ability, Downloader.MotivoRicerca.Pokedex, pokemon);
            searchHandler.SearchForThis(Downloader.OggettoRicerca.Move, Downloader.MotivoRicerca.Pokedex, pokemon);
        }
    }

    public void Link(AbilityJsonClass[] abilityJson, Pokemon pokemon) {
        foreach (AbilityJsonClass ajc in abilityJson) {
            foreach (Abilità abilità in pokemon.abilità) {
                if (ajc.name == abilità.nomeOriginale) {
                    GetComponent<LinkerAbilità>().Link(ajc, abilità);
                    break;
                }
            }
        }
        pokedexGUI.AssociateAbilitiesSearchResult();
    }

    public void Link(MoveJsonClass[] moveJson, Pokemon pokemon) {
        foreach (MoveJsonClass mjc in moveJson) {
            foreach(Mossa mossa in pokemon.mosse) {
                if(mjc.name == mossa.nomeOriginale) {
                    GetComponent<LinkerMossa>().Link(mjc, mossa);
                    break;
                }
            }
        }
        pokedexGUI.AssociateMovesSearchResult();
    }

    public void Link(MoveJsonClass moveJson) {

    }

}
