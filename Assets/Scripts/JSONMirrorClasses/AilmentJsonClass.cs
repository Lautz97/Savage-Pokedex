
using UnityEngine;
using System;

[Serializable]
public class AilmentJsonClass {

    public int id;
    public Move[] moves;
    public string name;
    public Name[] names;

    public static AilmentJsonClass CreateFromJSON(string json) {
        return JsonUtility.FromJson<AilmentJsonClass>(json);
    }

    [Serializable]
    public class Move {
        public string name;
        public string url;
    }

    [Serializable]
    public class Name {
        public Language language;
        public string name;
    }

    [Serializable]
    public class Language {
        public string name;
        public string url;
    }


}
