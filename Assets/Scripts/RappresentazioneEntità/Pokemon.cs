using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

[Serializable]
public class Pokemon
{
    //composizione del pokemon
    public string url = null;

    public string nome = null;
    public int numero;

    public Sprite image = null;

    public string tipo = null;

    public Abilità[] abilità = null;

    public string agilità = null;
    public string forza = null;
    public string intelligenza = null;
    public string spirito = null;
    public string vigore = null;

    public Mossa[] mosse = null;

    public static void SavePokemon(Pokemon pokemon) {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Pokemon));
        using (StringWriter sw = new StringWriter()) {
            xmlSerializer.Serialize(sw, pokemon);
            PlayerPrefs.SetString(pokemon.nome.ToLower(), sw.ToString());
        }
    }

    public static Pokemon LoadPokemon(string nome) {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Pokemon));
        String pokeXml = PlayerPrefs.GetString(nome);
        if(pokeXml.Length == 0) { 
            return new Pokemon();
        }
        else {
            using (StringReader reader = new StringReader(pokeXml)) {
                return xmlSerializer.Deserialize(reader) as Pokemon;
            }
        }
    }

}
