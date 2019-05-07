using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanelScript : MonoBehaviour
{
    public Downloader downloader;
    public Text text;

    public void Called()
    {
        text.text = "";
        for (int i = -1; i < 21; i++) {
            downloader.Search(Downloader.OggettoRicerca.MoveAilment, i.ToString(), Downloader.MotivoRicerca.Debug);
        }
    }

    public void AddAilment(string s) {
        text.text += s+", ";
    }

    public void DeletePP() {
        PlayerPrefs.DeleteAll();
        Debug.Log("playerPrefs Deleted");
    }

}
