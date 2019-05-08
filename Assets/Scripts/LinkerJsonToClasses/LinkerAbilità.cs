using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkerAbilità : MonoBehaviour
{
    public void Link(AbilityJsonClass abilityJson, Abilità abilità) {

        abilità.name = abilityJson.names[3].name;

    }
}
