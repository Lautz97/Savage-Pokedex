using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwap : MonoBehaviour
{
    public GameObject[] panels;

    // Start is called before the first frame update
    void Start()
    {
        GoToPanel("MainPanel");
    }

    public void GoToPanel(string panelName) {
        foreach (GameObject g in panels) {
            if (g.name != panelName) {
                g.SetActive(false);
            }
            else {
                g.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
