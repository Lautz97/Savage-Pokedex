using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{

    public struct Monster {
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
    }
    
    public struct Mossa {
        public string nome;
        public string lvl;
        public string attributo;
        public string danno;
        public string penetrazine;
        public string PP;
    }

    public Monster pokemon;

    // Start is called before the first frame update
    void Start()
    {
        pokemon = new Monster();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
