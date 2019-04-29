using System;
using UnityEngine;

[Serializable]
public class MoveJsonClass {

    public int accuracy;
    public Contest_Combos contest_combos;
    public Contest_Effect contest_effect;
    public Contest_Type contest_type;
    public Damage_Class damage_class;
    public int effect_chance;
    public object[] effect_changes;
    public Effect_Entries[] effect_entries;
    public Flavor_Text_Entries[] flavor_text_entries;
    public Generation generation;
    public int id;
    public object[] machines;
    public Meta meta;
    public string name;
    public Name[] names;
    public object[] past_values;

    public string power;

    public int pp;
    public int priority;
    public Stat_Changes[] stat_changes;
    public Super_Contest_Effect super_contest_effect;
    public Target target;
    public Type type;

    public static MoveJsonClass CreateFromJSON(string json) {
        return JsonUtility.FromJson<MoveJsonClass>(json);
    }

    [Serializable]
    public class Contest_Combos {
        public Normal normal;
        public Super super;
    }

    [Serializable]
    public class Normal {
        public Use_After[] use_after;
        public Use_Before[] use_before;
    }

    [Serializable]
    public class Use_After {
        public string name;
        public string url;
    }

    [Serializable]
    public class Use_Before {
        public string name;
        public string url;
    }

    [Serializable]
    public class Super {
        public object use_after;
        public object use_before;
    }

    [Serializable]
    public class Contest_Effect {
        public string url;
    }

    [Serializable]
    public class Contest_Type {
        public string name;
        public string url;
    }

    [Serializable]
    public class Damage_Class {
        public string name;
        public string url;
    }

    [Serializable]
    public class Generation {
        public string name;
        public string url;
    }

    [Serializable]
    public class Meta {
        public Ailment ailment;
        public int ailment_chance;
        public Category category;
        public int crit_rate;
        public int drain;
        public int flinch_chance;
        public int healing;
        public object max_hits;
        public object max_turns;
        public object min_hits;
        public object min_turns;
        public int stat_chance;
    }

    [Serializable]
    public class Ailment {
        public string name;
        public string url;
    }

    [Serializable]
    public class Category {
        public string name;
        public string url;
    }

    [Serializable]
    public class Super_Contest_Effect {
        public string url;
    }

    [Serializable]
    public class Target {
        public string name;
        public string url;
    }

    [Serializable]
    public class Type {
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
    public class Stat_Changes {
        public int change;
        public Stat stat;
    }

    [Serializable]
    public class Stat {
        public string name;
        public string url;
    }

}
