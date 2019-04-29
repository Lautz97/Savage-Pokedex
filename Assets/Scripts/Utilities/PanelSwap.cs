using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelSwap : MonoBehaviour
{
    //list of all panels that can be swapped
    public GameObject[] panels;

    void Start()
    {
        GoToPanel("MainPanel");
    }

    //set active the selected panel and hide the others
    public void GoToPanel(string panelName) {
        if (panelName == "Quit") Application.Quit(); else
        foreach (GameObject g in panels) {
            if (g.name != panelName) {
                g.SetActive(false);
            }
            else {
                g.SetActive(true);
            }
        }
    }

    public void ResetScene() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void GoToURL(string url) {
        Application.OpenURL(url);
    }

}
