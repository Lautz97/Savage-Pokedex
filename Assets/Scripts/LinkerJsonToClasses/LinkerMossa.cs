using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LinkerMossa : MonoBehaviour
{
    public void Link(MoveJsonClass moveJson, Mossa mossa) {
        
        mossa.nome = moveJson.names[3].name;
        mossa.PP = GetPP(moveJson.pp);
        mossa.tipo = moveJson.type.name;

        GetTipologiaDanniPA(moveJson, mossa);
        AggiungiPAExtra(mossa);

        //LE ALTERAZIONI SONO SBAGLIATE
        CercaAlterazioniStato(moveJson, mossa);

        mossa.descrizione = moveJson.effect_entries[0].effect.Replace("$effect_chance",moveJson.effect_chance.ToString());

        mossa.descrizioneIta = moveJson.flavor_text_entries[3].flavor_text.Replace("\n", " ");

        mossa.precisione = GetPrecisione(moveJson);


        mossa.categoria = (Mossa.Category)Enum.Parse(typeof(Mossa.Category), moveJson.meta.category.name.Replace("-", "").Replace("+", ""));


    }

    int GetPrecisione(MoveJsonClass mjc) {
        int ret = ((95 - mjc.accuracy) / 10)*-1;
        if (ret == -9) ret = 0;
        return ret;
    }

    int GetPP(int pp) {
        if (pp <= 40 && pp >= 35) {
            return 1;
        }
        else if (pp <= 30 && pp >= 20) {
            return 2;
        }
        else if (pp <= 15 && pp >= 10) {
            return 4;
        }
        else return 6;
    }

    void GetTipologiaDanniPA(MoveJsonClass mjc, Mossa mossa) {
        switch (mjc.damage_class.name) {
            case "special":
                mossa.tipologia = "speciale";
                mossa.attributoCorrelato = "Intelligenza";
                GetDanni(mjc, mossa);
                break;
            case "status":
                mossa.tipologia = "stato";
                break;
            case "physical":
                mossa.tipologia = "fisico";
                mossa.attributoCorrelato = "Forza";
                GetDanni(mjc, mossa);
                break;
            default:
                mossa.tipologia = "errore";
                break;
        }
    }

    void GetDanni(MoveJsonClass mjc,Mossa mossa) {
        if (mjc.power == "") { mossa.danno = "variabile"; }
        else {
            int damage = int.Parse(mjc.power);
            if (damage > 0) {
                mossa.danno = "d4-4";
            }
            if (damage > 18)  {
                mossa.danno = "d4-2";
            }
            if (damage > 25) {
                mossa.danno = "d4";
            }
            if (damage > 35) {
                mossa.danno = "d6-2";
            }
            if (damage > 40) {
                mossa.danno = "d6";
                mossa.penetrazineArmatura = 1;
            }
            if (damage > 50) {
                mossa.danno = "d8-2";
                mossa.penetrazineArmatura = 1;
            }
            if (damage > 60) {
                mossa.danno = "d10-2";
                mossa.penetrazineArmatura = 1;
            }
            if (damage > 75) {
                mossa.danno = "d8";
                mossa.penetrazineArmatura = 1;
            }
            if (damage > 85) {
                mossa.danno = "d6+2";
                mossa.penetrazineArmatura = 2;
            }
            if (damage > 90) {
                mossa.danno = "d10";
                mossa.penetrazineArmatura = 2;
            }
            if (damage > 95) {
                mossa.danno = "d12-2";
                mossa.penetrazineArmatura = 2;
            }
            if (damage > 100) {
                mossa.danno = "d8+2";
                mossa.penetrazineArmatura = 2;
            }
            if (damage > 110) {
                mossa.danno = "d12";
                mossa.penetrazineArmatura = 3;
            }
            if (damage > 120) {
                mossa.danno = "d10+2";
                mossa.penetrazineArmatura = 3;
            }
            if (damage > 130) {
                mossa.danno = "d12+2";
                mossa.penetrazineArmatura = 5;
            }
            if (damage > 150) {
                mossa.danno = "2d10";
                mossa.penetrazineArmatura = 6;
            }
            if (damage > 160) {
                mossa.danno = "d12+4";
                mossa.penetrazineArmatura = 8;
            }
            if (damage > 180) {
                mossa.danno = "2d10+2";
                mossa.penetrazineArmatura = 8;
            }
            if (damage > 200) {
                mossa.danno = "2d12+2";
                mossa.penetrazineArmatura = 10;
            }
        }
    }
    
    void AggiungiPAExtra(Mossa mossa) {
        if (mossa.tipologia == "speciale") mossa.penetrazineArmatura++;
        if (mossa.nome.Contains("raggio")) mossa.penetrazineArmatura++;
    }

    void CercaAlterazioniStato(MoveJsonClass mjc, Mossa mossa) {
        if (mjc.stat_changes.Length > 0) {
            Mossa.AlterazioneStato[] altStati = new Mossa.AlterazioneStato[mjc.stat_changes.Length];
            for (int i = 0; i < altStati.Length; i++) {
                altStati[i] = new Mossa.AlterazioneStato {
                    attributo = mjc.stat_changes[i].stat.name,
                    valore = mjc.stat_changes[i].change,
                    probabilità = mjc.effect_chance
                };
            }
            mossa.alterazioni = altStati;
        }
    }

}
