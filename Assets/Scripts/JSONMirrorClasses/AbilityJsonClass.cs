using System;
using UnityEngine;

[Serializable]
public class AbilityJsonClass
{

    public object[] effect_changes;
    public Effect_Entries[] effect_entries;
    public Flavor_Text_Entries[] flavor_text_entries;
    public Generation generation;
    public int id;
    public bool is_main_series;
    public string name;
    public Name[] names;
    public Pokemon[] pokemon;

    public static AbilityJsonClass CreateFromJSON(string json) {
        return JsonUtility.FromJson<AbilityJsonClass>(json);
    }

    [Serializable]
    public class Generation {
        public string name;
        public string url;
    }

    [Serializable]
    public class Effect_Entries {
        public string effect;
        public Language language;
        public string short_effect;
    }

    [Serializable]
    public class Language {
        public string name;
        public string url;
    }

    [Serializable]
    public class Flavor_Text_Entries {
        public string flavor_text;
        public Language1 language;
        public Version_Group version_group;
    }

    [Serializable]
    public class Language1 {
        public string name;
        public string url;
    }

    [Serializable]
    public class Version_Group {
        public string name;
        public string url;
    }

    [Serializable]
    public class Name {
        public Language2 language;
        public string name;
    }

    [Serializable]
    public class Language2 {
        public string name;
        public string url;
    }

    [Serializable]
    public class Pokemon {
        public bool is_hidden;
        public Pokemon1 pokemon;
        public int slot;
    }

    [Serializable]
    public class Pokemon1 {
        public string name;
        public string url;
    }

}
