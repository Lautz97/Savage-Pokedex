using System;
using UnityEngine;

[Serializable]
public class Mossa 
{
    //
    public string url = null;
    //
    public string nomeOriginale;
    //
    public string nome = null;

    public int precisione;

    //
    public int livello;
    //
    public string attributoCorrelato = null;
    //
    public string danno = null;
    //
    public int penetrazineArmatura;
    //
    public int PP;
    //
    public string modalitàApprendimento = null;
    //
    public string tipo = null;
    
    //
    public AlterazioneStato[] alterazioni;

    [Serializable]
    public class AlterazioneStato {
        public string attributo = null;
        public int valore;
        public float probabilità;
    }

    //                              fisico,speciale,stato
    public string tipologia = null;

    public int[] raggio = null;

    public string descrizione = null;


}
