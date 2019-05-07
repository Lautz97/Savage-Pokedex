using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Downloader : MonoBehaviour
{
    public Linker linker;

    public class ParametroCoroutine {
        public string indirizzo;
        public PokemonJsonClass pokemonJson = null;
        public MoveJsonClass moveJson = null;
        public AbilityJsonClass abilityJson = null;
        public Pokemon pokemon = null;
        public MotivoRicerca motivo;
        public string nome;
    }

    public void Search(OggettoRicerca oggettoRicerca, string name, MotivoRicerca motivoRicerca, Pokemon pkm = null) {

        string url = "https://pokeapi.co/api/v2/"+ oggettoRicerca.ToString().ToLower() + "/";
        if (name!=null) url += name.ToLower() + "/";

        string ienumName = "Get" + oggettoRicerca + "Json";

        ParametroCoroutine parametro = new ParametroCoroutine {
            indirizzo = url,
            motivo = motivoRicerca,
            nome = name,
        };

        if(oggettoRicerca == OggettoRicerca.MoveAilment) {
            parametro.indirizzo = name;
        }

        if (pkm != null) parametro.pokemon = pkm;

        StartCoroutine(ienumName, parametro);



    }

    public IEnumerator GetMoveAilmentJson(ParametroCoroutine parametro) {
        string uri = "https://pokeapi.co/api/v2/move-ailment/" + parametro.indirizzo + "/";
        using (UnityWebRequest www = UnityWebRequest.Get(uri)) {
            Debug.Log(uri);            
            yield return www.SendWebRequest();

            if (www.isNetworkError) { Debug.Log(www.error); }
            else {
                if (www.isDone) {

                    string jsonRes = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(jsonRes);
                    AilmentJsonClass mjc = AilmentJsonClass.CreateFromJSON(jsonRes);

                    linker.Link(mjc.name);

                }
            }
        }
    }

    public IEnumerator GetPokemonJson(ParametroCoroutine parametro) {
        
        if (PlayerPrefs.HasKey(parametro.nome)) {
            linker.Link(Pokemon.LoadPokemon(parametro.nome), parametro.motivo);
        }
        else {
            using (UnityWebRequest www = UnityWebRequest.Get(parametro.indirizzo)) {

                yield return www.SendWebRequest();

                if (www.isNetworkError) { Debug.Log(www.error); }
                else {
                    if (www.isDone) {

                        string jsonRes = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                        PokemonJsonClass pjc = PokemonJsonClass.CreateFromJSON(jsonRes);

                        parametro = new ParametroCoroutine {
                            pokemonJson = pjc,
                            motivo = parametro.motivo,
                        };

                        yield return StartCoroutine(GetPokemonSprite(parametro));

                    }
                }

            }
        }
    }

    public IEnumerator GetPokemonSprite(ParametroCoroutine parametro) {

        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(parametro.pokemonJson.sprites.front_default)) {

            yield return www.SendWebRequest();

            if (www.isNetworkError) { Debug.Log(www.error); }
            else {
                if (www.isDone) {

                    Texture2D t = ((DownloadHandlerTexture)www.downloadHandler).texture;

                    Sprite sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));

                    linker.Link(parametro.pokemonJson, sprite, parametro.motivo);
                }
            }
        }
    }


    public IEnumerator GetMoveJson(ParametroCoroutine parametro) {

        if (parametro.pokemon == null) {
            using (UnityWebRequest www = UnityWebRequest.Get(parametro.indirizzo)) {

                yield return www.SendWebRequest();

                if (www.isNetworkError) { Debug.Log(www.error); }
                else {
                    if (www.isDone) {

                        string jsonRes = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                        MoveJsonClass mjc = MoveJsonClass.CreateFromJSON(jsonRes);

                        //DoSomething(mjc);

                    }
                }
            }
        }
        else {

            MoveJsonClass[] moveJsons = new MoveJsonClass[parametro.pokemon.mosse.Length];
            for (int i = 0; i < parametro.pokemon.mosse.Length; i++) {
                using (UnityWebRequest www = UnityWebRequest.Get(parametro.pokemon.mosse[i].url)) {

                    yield return www.SendWebRequest();

                    if (www.isNetworkError) { Debug.Log(www.error); }
                    else {
                        if (www.isDone) {

                            string jsonRes = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                            MoveJsonClass mjc = MoveJsonClass.CreateFromJSON(jsonRes);

                            moveJsons.SetValue(mjc, i);

                        }
                    }
                }
            }
            linker.Link(moveJsons, parametro.pokemon);
        }
    }

    public IEnumerator GetAbilityJson(ParametroCoroutine parametro) {
        if (parametro.pokemon == null) {
            using (UnityWebRequest www = UnityWebRequest.Get(parametro.indirizzo)) {

                yield return www.SendWebRequest();

                if (www.isNetworkError) { Debug.Log(www.error); }
                else {
                    if (www.isDone) {

                        string jsonRes = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                        AbilityJsonClass ajc = AbilityJsonClass.CreateFromJSON(jsonRes);

                        //DoSomething(ajc);

                    }
                }

            }
        } else {

            AbilityJsonClass[] abilityJsons = new AbilityJsonClass[parametro.pokemon.abilità.Length];
            for (int i = 0; i < parametro.pokemon.abilità.Length; i++) {
                using (UnityWebRequest www = UnityWebRequest.Get(parametro.pokemon.abilità[i].url)) {

                    yield return www.SendWebRequest();

                    if (www.isNetworkError) { Debug.Log(www.error); }
                    else {
                        if (www.isDone) {

                            string jsonRes = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                            AbilityJsonClass mjc = AbilityJsonClass.CreateFromJSON(jsonRes);

                            abilityJsons.SetValue(mjc, i);

                        }
                    }
                }
            }
            linker.Link(abilityJsons, parametro.pokemon);
        }
        
    }

    public enum OggettoRicerca {
        Pokemon,
        Ability,
        Move,
        MoveAilment,
    };
    public enum MotivoRicerca {
        Pokedex,
        MoveDex,
        Debug,
    };
}


