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
    public string name = null;

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

    public string descrizione = null, descrizioneIta;

    public Category categoria;

    [Serializable]
    public enum Category {
        damage,
        ailment,
        netgoodstats,
        heal,
        damageailment,
        swagger,
        damagelower,
        damageraise,
        damageheal,
        ohko,
        wholefieldeffect,
        fieldeffect,
        forceswitch,
        unique
    }

    [Serializable]
    public enum Ailment {
        unknown,
        none,
        paralysis,
        sleep,
        freeze,
        burn,
        poison,
        confusion,
        infatuation,
        trap,
        nightmare,
        torment,
        disable,
        yawn,
        healblock,
        notypeimmunity,
        leechseed,
        embargo,
        perishsong,
    }

}
