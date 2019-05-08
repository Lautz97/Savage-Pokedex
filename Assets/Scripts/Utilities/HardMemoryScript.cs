using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

public static class HardMemoryScript 
{
    public static void SavePokemon(Pokemon pokemon) {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Pokemon));
        using (StringWriter sw = new StringWriter()) {
            xmlSerializer.Serialize(sw, pokemon);

            PlayerPrefs.SetString(pokemon.nome.ToLower(), sw.ToString());

        }
    }

    public static Pokemon LoadPokemon(string nome) {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Pokemon));
        string pokeXml = PlayerPrefs.GetString(nome);
        if (pokeXml.Length == 0) {
            return new Pokemon();
        }
        else {
            using (StringReader reader = new StringReader(pokeXml)) {
                return xmlSerializer.Deserialize(reader) as Pokemon;
            }
        }
    }
}
