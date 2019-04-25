using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class MapperForPS : MonoBehaviour
{
    public Image pic;
    public Text
        nome, tipo,
        agilità, forza, intelligenza, spirito, vigore;
    public GameObject abilità;
    public GameObject mosse;
    public GameObject abiBase, mossaBase;


    public IEnumerator GetImg(string url) {
        WWW picwww = new WWW(url);

        yield return picwww;

        pic.sprite = Sprite.Create(picwww.texture, new Rect(0, 0, picwww.texture.width, picwww.texture.height), new Vector2(0, 0));
    }


    // Start is called before the first frame update
    public void Populate(Pokemon pkm)
    {
        //GetImage(pkm);

        nome.text = pkm.razza;
        tipo.text = pkm.tipo;

        agilità.text += pkm.agilità;
        forza.text += pkm.forza;
        intelligenza.text += pkm.intelligenza;
        spirito.text += pkm.spirito;
        vigore.text += pkm.vigore;


    }

    public void GetImage(Pokemon pkm) {
        GetImg(pkm.pkmjson.sprites.front_default);
    }



}
