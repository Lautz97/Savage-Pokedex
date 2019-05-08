using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokeSheetGUIHandler : MonoBehaviour
{
    public Text pokemonId, pokemonName, pokemonType;
    public Image pokemonSprite;
    public Button pokemonWikiLink;

    public PannelloMossaGUIHandler pannelloMossa;


    public GameObject containerAttributi, containerAbilità, containerMossa;
    public GameObject attributoBase, abilitàBase, mossaBase;


    public void PopulateSheet(Pokemon pokemon) {

        pokemonId.text = pokemon.numero.ToString();
        pokemonName.text = SetTitleCase(pokemon.name);
        pokemonType.text = pokemon.tipo;

        pokemonSprite.sprite = pokemon.image;

        pokemonWikiLink.onClick.AddListener(CustomListener_RazzaLinkWiki);

        ImpostaAttributi(pokemon);

    }
    public void PopulateSheetAbilità(Pokemon pokemon) {
        ImpostaAbilità(pokemon);
    }
    public void PopulateSheetMosse(Pokemon pokemon) {
        ImpostaMosse(pokemon);
    }

    void ImpostaAttributi(Pokemon pokemon) {
        GameObject na = Instantiate(attributoBase, containerAttributi.transform);
        na.name = "Agilità";
        na.GetComponent<Text>().text = na.name + " : " + pokemon.agilità;

        na = Instantiate(attributoBase, containerAttributi.transform);
        na.name = "Forza";
        na.GetComponent<Text>().text = na.name + " : " + pokemon.forza;

        na = Instantiate(attributoBase, containerAttributi.transform);
        na.name = "Intelligenza";
        na.GetComponent<Text>().text = na.name + " : " + pokemon.intelligenza;

        na = Instantiate(attributoBase, containerAttributi.transform);
        na.name = "Spirito";
        na.GetComponent<Text>().text = na.name + " : " + pokemon.spirito;

        na = Instantiate(attributoBase, containerAttributi.transform);
        na.name = "Vigore";
        na.GetComponent<Text>().text = na.name+ " : "+ pokemon.vigore;
    }

    void ImpostaAbilità(Pokemon pokemon) {
        foreach (Abilità abi in pokemon.abilità) {
            GameObject na = Instantiate(abilitàBase, containerAbilità.transform);
            na.name = abi.name;
            na.GetComponent<Text>().text = abi.name;
            na.GetComponent<Button>().onClick.AddListener(() => CustomListener_AbilitàLinkWiki(abi.name));
        }
    }

    void ImpostaMosse(Pokemon pokemon) {
        foreach (Mossa mossa in pokemon.mosse) {
            {
                GameObject na = Instantiate(mossaBase, containerMossa.transform);
                na.SetActive(true);
                na.name = mossa.name;
                na.transform.Find("NomeMossa").GetComponent<Text>().text = mossa.name;
                if (mossa.modalitàApprendimento == "level-up")
                    na.transform.Find("Livello").GetComponent<Text>().text = mossa.livello.ToString();
                else
                    na.transform.Find("Livello").GetComponent<Text>().text = "";
                na.transform.Find("Modalità").GetComponent<Text>().text = mossa.modalitàApprendimento;
                na.transform.Find("Info").GetComponent<Button>().onClick.AddListener(() => CustomListener_AbilitàLinkWiki(mossa.name));
                na.transform.Find("PannelloMossa").GetComponent<Button>().onClick.AddListener(() => CustomListener_PannelloMossa(mossa));
            }
        }
    }

    void CustomListener_AbilitàLinkWiki(string s) {
        Application.OpenURL("https://wiki.pokemoncentral.it/" + s);
    }

    void CustomListener_PannelloMossa(Mossa mossa) {
        pannelloMossa.PopolaScheda(mossa);
    }

    void CustomListener_RazzaLinkWiki() {
        Application.OpenURL("https://wiki.pokemoncentral.it/" + pokemonName.text);
    }

    string SetTitleCase(string s) {
        string ns = s.ToLower();
        char[] ca = ns.ToCharArray();
        ca[0] = ns.ToUpper()[0];
        return new string(ca);
    }



}
