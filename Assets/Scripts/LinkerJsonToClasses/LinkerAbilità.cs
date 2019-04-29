using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkerAbilità : MonoBehaviour
{
    public void Link(AbilityJsonClass abilityJson, Abilità abilità) {
        foreach (AbilityJsonClass.Name nome in abilityJson.names) {
            if (nome.language.name == "it") {
                abilità.nome = nome.name;
                break;
            }
        }
    }
}
