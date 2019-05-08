using System;
using UnityEngine;
using System.Xml.Serialization;


[Serializable]
public class Pokemon
{
    //composizione del pokemon
    public string url = null;

    public string name = null;
    public int numero;

    [XmlIgnore]
    public Sprite image = null;

    public string imageUrl = "";

    public string tipo = null;

    public Abilità[] abilità = null;

    public string agilità = null;
    public string forza = null;
    public string intelligenza = null;
    public string spirito = null;
    public string vigore = null;

    public Mossa[] mosse = null;

}
