using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;



public class Pokedex : MonoBehaviour
{
    Pokemon pokemon;
    public GameObject result;
    public InputField inputField;
    public UnityWebRequest www;
    public DownloadHandler handler;
    public Text dbgt;
    // Start is called before the first frame update
    void Start()
    {
        pokemon = Camera.main.GetComponent<Pokemon>();
        result.SetActive(false);
    }

    public void Search() {

        pokemon.pokemon.razza = inputField.text;
        string url = "https://pokeapi.co/api/v2/pokemon/" + inputField.text + "/";

        StartCoroutine(Get(url));
        /*if (UseApi()) {
            result.SetActive(true);
        }*/
    }

    bool UseApi() {

        string url = "https://pokeapi.co/api/v2/pokemon/" + inputField.text + "/";

        www = UnityWebRequest.Get(url);
        handler = www.downloadHandler;
        dbgt.text = JsonUtility.FromJson<string>(handler.text);

        return true;
    }

    public IEnumerator Get(string url/*, System.Action<Pokemon.Monster> callback*/) {
        using(UnityWebRequest www = UnityWebRequest.Get(url)) {
            yield return www.SendWebRequest();

            if (www.isNetworkError) {
                Debug.Log(www.error);
            }
            else {
                if (www.isDone) {
                    string jsonRes = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(jsonRes);

                    pokemon.pokemon = JsonUtility.FromJson<Pokemon.Monster>(jsonRes);
                    inputField.text = pokemon.pokemon.razza;
                    result.SetActive(true);

                    //callback(pokemon.pokemon);

                }
            }

        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
