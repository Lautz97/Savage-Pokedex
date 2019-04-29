using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SearchHandler : MonoBehaviour
{
    public Downloader downloader;
    public Downloader.OggettoRicerca oggettoRicerca;
    public InputField inputField;
    public Downloader.MotivoRicerca motivoRicerca;

    public void SearchForThis() {
        downloader.Search(oggettoRicerca, inputField.text, motivoRicerca);
    }

    public void SearchForThis(Downloader.OggettoRicerca oggetto, Downloader.MotivoRicerca motivo, Pokemon pokemon) {
        downloader.Search(oggetto, null, motivo, pokemon);
    }

    public void SearchForThis(Downloader.OggettoRicerca oggetto, string s, Downloader.MotivoRicerca motivo) {
        downloader.Search(oggetto, s, motivo);
    }
}
