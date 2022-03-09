using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tvmanager : MonoBehaviour
{
    public Vector3 ruedaCanalVector;
    public Vector3 ruedaSintonizarVector;

    public Transform ruedaCanal;
    public Transform ruedaSintonizar;

    public int rotacionRuedaCanal;
    public int rotacionSintonizar;

    public SpriteRenderer inter;
    public SpriteRenderer[] sprites;

    void Start ()
    {
        StartPuzleTV();
    }


    public void StartPuzleTV()
    {
      
        ruedaCanal.transform.Rotate(0, 0, -1);
        ruedaCanalVector = ruedaCanal.rotation.eulerAngles;

        ruedaSintonizar.transform.Rotate(0, 0, -0.5f);
        ruedaSintonizarVector = ruedaCanal.rotation.eulerAngles;

        //interferencia.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 60);
        inter = inter.transform.GetComponent<SpriteRenderer>();
        Color col = inter.color;
        col.a = 0.5f;
        inter.color = col;
        StartCoroutine(pruebaAnimacion());


        int x = 3;
        int i;
        for (i = 0; i < x; i++)
        {
            inter = sprites[i];
            col.a = 0.5f;
            inter.color = col;
        }
        if (i == x)
        {
            i = 0;
        }
    }

    IEnumerator pruebaAnimacion()
    {
        //inter = gameObject.GetComponent<SpriteRenderer>();
        //sprites = Resources.LoadAll<Sprite>("nieve-spriteMesa de trabajo 1_0");
        inter = sprites[0];
        inter = inter.transform.GetComponent<SpriteRenderer>();
        Color col = inter.color;
        col.a = 0.5f;
        inter.color = col;
        yield return new WaitForSeconds(0.2f);
        inter = sprites[1];
        col.a = 0.5f;
        inter.color = col;
        yield return new WaitForSeconds(0.2f);
        inter = sprites[2];
        col.a = 0.5f;
        inter.color = col;
        yield return new WaitForSeconds(0.2f);
        inter = sprites[3];
        col.a = 0.5f;
        inter.color = col;
        yield return new WaitForSeconds(0.2f);

    }
}
