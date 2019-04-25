using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    public string razza;

    public string tipo;

    public string agilità;
    public string forza;
    public string intelligenza;
    public string spirito;
    public string vigore;

    public string carisma;
    public string parata;
    public string passoCorsa;
    public string robustezza;

    public Mossa[] mosse;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Convert(PokemonJSONClass pkmj) {

        razza = pkmj.name;

        SetType(pkmj);

        SetBaseStats(pkmj);

        SetMosse(pkmj);
        

    }

    void SetType(PokemonJSONClass pkmj) {
        for (int i = 0; i < pkmj.types.Length; i++) {
            tipo += pkmj.types[i].type.name;
            if (i + 1 != pkmj.types.Length) tipo += " / ";
        }
    }

    void SetBaseStats(PokemonJSONClass pkmj)
    {
        foreach (Stat stat in pkmj.stats) {
            switch (stat.stat.name) {
                case "speed":
                    agilità = SetMaxDice(stat.base_stat);
                    break;
                case "special-defense":
                    spirito = SetMaxDice(stat.base_stat);
                    break;
                case "special-attack":
                    intelligenza = SetMaxDice(stat.base_stat);
                    break;
                case "defense":
                    vigore = SetMaxDice(stat.base_stat);
                    break;
                case "attack":
                    forza = SetMaxDice(stat.base_stat);
                    break;
                default:
                    break;
            }
        }
    }

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

    void SetMosse(PokemonJSONClass pkmj) {
        for (int i = 0; i < pkmj.moves.Length; i++) {
            mosse[i].nome = pkmj.moves[i].move.name;
            mosse[i].url = pkmj.moves[i].move.url;
        }
    }


}


public struct Mossa {
    public string nome;
    public string url;
    public string lvl;
    public string attributo;
    public string danno;
    public string penetrazine;
    public string PP;
}
