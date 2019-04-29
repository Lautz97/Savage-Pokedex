using System;
using UnityEngine;

[Serializable]
public class PokemonJsonClass 
{

    public Ability[] abilities;
    public int base_experience;
    public Form[] forms;
    public Game_Indices[] game_indices;
    public int height;
    public Held_Items[] held_items;
    public int id;
    public bool is_default;
    public string location_area_encounters;
    public Move[] moves;
    public string name;
    public int order;
    public Species species;
    public Sprites sprites;
    public Stat[] stats;
    public Type[] types;
    public int weight;

    public static PokemonJsonClass CreateFromJSON(string json) {
        return JsonUtility.FromJson<PokemonJsonClass>(json);
    }

    [Serializable]
    public class Species {
        public string name;
        public string url;
    }

    [Serializable]
    public class Sprites {
        public string back_default;
        public string back_female;
        public string back_shiny;
        public string back_shiny_female;
        public string front_default;
        public string front_female;
        public string front_shiny;
        public string front_shiny_female;
    }

    [Serializable]
    public class Ability {
        public Ability1 ability;
        public bool is_hidden;
        public int slot;
    }

    [Serializable]
    public class Ability1 {
        public string name;
        public string url;
    }

    [Serializable]
    public class Form {
        public string name;
        public string url;
    }

    [Serializable]
    public class Game_Indices {
        public int game_index;
        public Version version;
    }

    [Serializable]
    public class Version {
        public string name;
        public string url;
    }

    [Serializable]
    public class Held_Items {
        public Item item;
        public Version_Details[] version_details;
    }

    [Serializable]
    public class Item {
        public string name;
        public string url;
    }

    [Serializable]
    public class Version_Details {
        public int rarity;
        public Version1 version;
    }

    [Serializable]
    public class Version1 {
        public string name;
        public string url;
    }

    [Serializable]
    public class Move {
        public Move1 move;
        public Version_Group_Details[] version_group_details;
    }

    [Serializable]
    public class Move1 {
        public string name;
        public string url;
    }

    [Serializable]
    public class Version_Group_Details {
        public int level_learned_at;
        public Move_Learn_Method move_learn_method;
        public Version_Group version_group;
    }

    [Serializable]
    public class Move_Learn_Method {
        public string name;
        public string url;
    }

    [Serializable]
    public class Version_Group {
        public string name;
        public string url;
    }

    [Serializable]
    public class Stat {
        public int base_stat;
        public int effort;
        public Stat1 stat;
    }

    [Serializable]
    public class Stat1 {
        public string name;
        public string url;
    }

    [Serializable]
    public class Type {
        public int slot;
        public Type1 type;
    }

    [Serializable]
    public class Type1 {
        public string name;
        public string url;
    }

}
