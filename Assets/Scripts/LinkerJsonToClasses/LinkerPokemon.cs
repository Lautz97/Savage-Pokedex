using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkerPokemon : MonoBehaviour
{
    public Pokemon LinkPokemon(PokemonJsonClass pjc, Sprite sprite) {

        Pokemon pokemon = new Pokemon {
            nome = pjc.name,
            url = "https://wiki.pokemoncentral.it/" + pjc.name,
            numero = pjc.id,
            tipo = PickType(pjc),
            image = sprite
        };

        SetBaseStats(pjc, pokemon);

        SetAbilitiesURL(pjc, pokemon);

        SetMosseURL(pjc, pokemon);

        if (!PlayerPrefs.HasKey(pokemon.nome)) {
            //Pokemon.SavePokemon(pokemon);
        }
        
        return pokemon;
    }

    void SetMosseURL(PokemonJsonClass pjc, Pokemon pokemon) {

        pokemon.mosse = new Mossa[pjc.moves.Length];

        for (int i = 0; i < pjc.moves.Length; i++) {
            Mossa mossa = new Mossa {
                url = pjc.moves[i].move.url,
                livello = pjc.moves[i].version_group_details[0].level_learned_at,
                modalitàApprendimento = pjc.moves[i].version_group_details[0].move_learn_method.name,
                nomeOriginale = pjc.moves[i].move.name
            };
            if (mossa.modalitàApprendimento == "egg") mossa.livello = 10997;
            if (mossa.modalitàApprendimento == "machine") mossa.livello = 10998;
            if (mossa.modalitàApprendimento == "tutor") mossa.livello = 10999;
            pokemon.mosse.SetValue(mossa, i);
        }
        OrdinaMossePerLivello(pokemon.mosse);

    }

    void OrdinaMossePerLivello(Mossa[] array) {
        for (int j = 0; j < array.Length - 1; j++) {

            for (int i = array.Length - 2; i >= j; i--) {
                if (array[i].livello > array[i + 1].livello) //cambiare questa condizione per invertire l'ordine
                  {
                    Mossa tmp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = tmp;
                }
            }

        }
    }

    void SetAbilitiesURL(PokemonJsonClass pjc, Pokemon pokemon) {

        pokemon.abilità = new Abilità[pjc.abilities.Length];

        for (int i = 0; i < pjc.abilities.Length; i++) {
            Abilità abilità = new Abilità {
                url = pjc.abilities[i].ability.url,
                nomeOriginale = pjc.abilities[i].ability.name
            };

            pokemon.abilità.SetValue(abilità, i);
        }

    }

    string PickType(PokemonJsonClass pjc) {
        string returnType = "";
        for (int i = 0; i < pjc.types.Length; i++) {
            returnType += SetTitleCase(pjc.types[i].type.name);
            if (i + 1 != pjc.types.Length) returnType += " / ";
        }
        return returnType;
    }

    string SetTitleCase(string s) {
        string ns = s.ToLower();
        char[] ca = ns.ToCharArray();
        ca[0] = ns.ToUpper()[0];
        return new string(ca);
    }

    //recupera le stats contenute nella classe convertita dal JSON 
    //e chiama "SetMaxDice" per capire qual'è il dado massimo dell'attributo
    void SetBaseStats(PokemonJsonClass pkmj, Pokemon pokemon) {
        foreach (PokemonJsonClass.Stat stat in pkmj.stats) {
            switch (stat.stat.name) {
                case "speed":
                    pokemon.agilità = SetMaxDice(stat.base_stat);
                    break;
                case "special-defense":
                    pokemon.spirito = SetMaxDice(stat.base_stat);
                    break;
                case "special-attack":
                    pokemon.intelligenza = SetMaxDice(stat.base_stat);
                    break;
                case "defense":
                    pokemon.vigore = SetMaxDice(stat.base_stat);
                    break;
                case "attack":
                    pokemon.forza = SetMaxDice(stat.base_stat);
                    break;
                default:
                    break;
            }
        }
    }

    //SOLO PER LE STAT/ATTRIBUTI
    //converte la stat numerica in tipo di dado massimo
    string SetMaxDice(int bs) {
        string dice = "d4";

        if (bs > 100) dice = "d12";
        else if (bs <= 100 && bs >= 86) {
            dice = "d10";
        }
        else if (bs <= 85 && bs >= 81) {
            dice = "d10 - 1";
        }
        else if (bs <= 80 && bs >= 66) {
            dice = "d8";
        }
        else if (bs <= 65 && bs >= 61) {
            dice = "d8 - 1";
        }
        else if (bs <= 60 && bs >= 46) {
            dice = "d6";
        }
        else if (bs <= 45 && bs >= 41) {
            dice = "d6 - 1";
        }
        return dice;
    }

}
