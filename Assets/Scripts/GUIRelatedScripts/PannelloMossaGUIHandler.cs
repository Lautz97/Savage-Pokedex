using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PannelloMossaGUIHandler : MonoBehaviour
{
    public VerticalLayoutGroup group;

    public Text nomeMossa, tipoMossa, precisioneMossa,
        dannoMossa, pa, pp, tipologiaMossa,
        effetto,effettoIta;

    public GameObject alterazioneBase, alterazioni;

    public void PopolaScheda(Mossa mossa) {

        for (int i = 0; i < alterazioni.transform.childCount; i++) {
            group.enabled = false;
            if (alterazioni.transform.GetChild(i).gameObject.activeInHierarchy) {
                Destroy(alterazioni.transform.GetChild(i).gameObject);
            }
            group.enabled = true;
        }
        

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
                group.enabled = false;
                GameObject na = Instantiate(alterazioneBase, alterazioni.transform);
                na.SetActive(true);
                na.transform.Find("Attributo").GetComponent<Text>().text = ConvertiStA(alt.attributo);
                na.transform.Find("Malus").GetComponent<Text>().text = alt.valore + " T.d.D.";
                string prob;
                if (alt.probabilità == 0) prob = "Colpo Garantito";
                else prob = alt.probabilità + " %";
                na.transform.Find("Possibilità").GetComponent<Text>().text = prob;
                group.enabled = true;
            }
        }

        effetto.text = mossa.descrizione;
        effettoIta.text = mossa.descrizioneIta;

    }

    public void ClearPanel() {
        gameObject.GetComponentInChildren<Text>().text = "";
        for (int i = 0; i < alterazioni.transform.childCount; i++) {
            group.enabled = false;
            if (alterazioni.transform.GetChild(i).gameObject.activeInHierarchy) {
                Destroy(alterazioni.transform.GetChild(i).gameObject);
            }
            group.enabled = true;
        }
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
