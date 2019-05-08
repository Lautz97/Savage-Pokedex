using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MoveListJsonClass : MonoBehaviour {

    public int count;
    public string next;
    public object previous;
    public Result[] results;

    [Serializable]
    public class Result {
        public string name;
        public string url;
    }

}
