using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Pokedex : MonoBehaviour
{
    public Pokemon pokemon;
    public PokemonJSONClass pjc;

    public GameObject result;

    public InputField inputField;

    public Text nome, numero;
    public Image pic, picsheet;


    public UnityWebRequest www;

    public Text dbgt;

    // Start is called before the first frame update
    void Start()
    {
        pokemon = Camera.main.GetComponent<Pokemon>();
        result.SetActive(false);

        Destroy(dbgt);
    }

    public void Search() {

        string url = "https://pokeapi.co/api/v2/pokemon/" + inputField.text + "/";

        StartCoroutine(Get(url));
        
    }


    public IEnumerator Get(string url/*, System.Action<Pokemon.Monster> callback*/) {

        using (UnityWebRequest www = UnityWebRequest.Get(url)) {

            yield return www.SendWebRequest();

            if (www.isNetworkError) {
                Debug.Log(www.error);
            }
            else {
                if (www.isDone) {

                    string jsonRes = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(jsonRes);
                    pjc = PokemonJSONClass.CreateFromJSON(jsonRes);

                    nome.text = pjc.name;
                    numero.text = pjc.id.ToString();

                    WWW picwww = new WWW(pjc.sprites.front_default);
                    yield return picwww;
                    pic.sprite = Sprite.Create(picwww.texture, new Rect(0, 0, picwww.texture.width, picwww.texture.height), new Vector2(0, 0));
                    picsheet.sprite = pic.sprite;

                    pokemon.Convert(pjc);

                    result.SetActive(true);
                    
                }
            }

        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
