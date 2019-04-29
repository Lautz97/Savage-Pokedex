using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PannelloMossaGUIHandler : MonoBehaviour
{
    public Text nomeMossa, tipoMossa, precisioneMossa,
        dannoMossa, pa, pp, tipologiaMossa,
        effetto;

    public GameObject alterazioneBase, alterazioni;

    public void PopolaScheda(Mossa mossa) {
        nomeMossa.text = mossa.nome;
        tipoMossa.text = mossa.tipo;

        precisioneMossa.text = mossa.precisione + " T.C.";

        if (mossa.tipologia != "stato") dannoMossa.text = mossa.attributoCorrelato + " + " + mossa.danno;
        else dannoMossa.text = "----";

        pa.text = mossa.penetrazineArmatura + " PA";
        pp.text = mossa.PP + " PP";
        tipologiaMossa.text = mossa.tipologia;

        if (mossa.alterazioni != null) {
            foreach (Mossa.AlterazioneStato alt in mossa.alterazioni) {
                /*if(alt.attributo != "")*/ {
                    GameObject na = Instantiate(alterazioneBase, alterazioni.transform);
                    na.SetActive(true);
                    na.transform.Find("Attributo").GetComponent<Text>().text = ConvertiStA(alt.attributo);
                    na.transform.Find("Malus").GetComponent<Text>().text = alt.valore + " T.d.D.";
                    string prob;
                    if (alt.probabilità == 0) prob = "Auto Cast";
                    else prob = alt.probabilità + " %";
                    na.transform.Find("Possibilità").GetComponent<Text>().text = prob;
                }/*
                else {
                    GameObject na = Instantiate(alterazioneBase, alterazioni.transform);
                    string prob;
                    if (alt.probabilità != 0) prob = "";
                    else {
                        na.transform.Find("Attributo").GetComponent<Text>().text = "";
                        na.transform.Find("Malus").GetComponent<Text>().text = "";
                        prob = alt.probabilità + " %";
                        na.transform.Find("Possibilità").GetComponent<Text>().text = prob;
                        na.SetActive(true);
                    }
                }*/
            }
        }

        effetto.text = mossa.descrizione;

    }

    string ConvertiStA(string s) {
        switch (s) {
            case "speed":
                return "agilità";
            case "special-defense":
                return "spirito";
            case "special-attack":
                return "intelligenza";
            case "defense":
                return "vigore";
            case "attack":
                return "forza";
            default:
                return "";
        }
    }

}
