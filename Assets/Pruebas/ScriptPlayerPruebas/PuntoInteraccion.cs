using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntoInteraccion : MonoBehaviour
{
    public Sprite puntoTextureCambiar;
    public Sprite manoTextureCambiar;
    public Image texturaOriginal;
    public GameObject activarImagen;
    public GameObject interacionConrayPlayer;
    public int numeroInteraccion;
    public int llavePuerta;
    public GameObject objetoSobreElQueActuaPuntoInteracion;
    public GameObject objetoPickup;
    public bool puedeInteractuar;
    public bool selfdestruct;

    Vector3 pos;

    public bool pruebaUnClick;

    public Transform posicionPlayer;

    public void OnTriggerEnter(Collider other)
    {
        activarImagen.SetActive(true);
        texturaOriginal.sprite = puntoTextureCambiar;

        if (other == other.gameObject.CompareTag("interactuarInterior"))
        {
            puedeInteractuar = true;
            texturaOriginal.sprite = manoTextureCambiar;
            texturaOriginal.color = new Color(texturaOriginal.color.r, texturaOriginal.color.g, texturaOriginal.color.b, 100);
            gameObject.transform.GetComponentInChildren<Animator>().enabled = true;
        }
        else if (other == other.gameObject.CompareTag("interactuar"))
        {
            puedeInteractuar = false;
            activarImagen.SetActive(true);
            texturaOriginal.sprite = puntoTextureCambiar;
            texturaOriginal.color = new Color(texturaOriginal.color.r, texturaOriginal.color.g, texturaOriginal.color.b, 100);
            gameObject.transform.GetComponentInChildren<Animator>().enabled = false;
            gameObject.transform.GetComponentInChildren<Animator>().gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1.0599f, 0.908f);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other == other.gameObject.CompareTag("interactuarInterior"))
        {
            
            if (texturaOriginal.sprite != manoTextureCambiar)
            {
                
                texturaOriginal.sprite = manoTextureCambiar;
                texturaOriginal.color = new Color(texturaOriginal.color.r, texturaOriginal.color.g, texturaOriginal.color.b, 100);
            }
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount > 0 && Input.touchCount < 2)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        //checkTouch2(Input.GetTouch(0).position);
                        other.transform.parent.GetComponent<InteracionConObjetosRayCast>().checkTouch2(Input.GetTouch(0).position);

                    }
                }
            }
            else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
            {
                if (Input.GetMouseButtonUp(0) && pruebaUnClick == false)
                {

                    //checkTouch2(Input.mousePosition);
                    other.transform.parent.GetComponent<InteracionConObjetosRayCast>().checkTouch2(Input.mousePosition);
    
                }
            }
            //No entiendo muy bien por que estaba esto aqui lo dejo comentado, ya funciona con dos o mas manos.

            /*if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("hola soy check stay");
                //checkTouch2(Input.mousePosition);
                interacionConrayPlayer.GetComponent<InteracionConObjetosRayCast>().checkTouch2(Input.mousePosition);
              //  FindObjectOfType<InteracionConObjetosRayCast>().itemId = numeroInteraccion;
                FindObjectOfType<InteracionConObjetosRayCast>().ObjetoSobreElQueActua = objetoSobreElQueActuaPuntoInteracion;

            }*/
        }
    }



    public void OnTriggerExit(Collider other)
    {
        if (other == other.gameObject.CompareTag("interactuar"))
        {
            texturaOriginal.color = new Color(texturaOriginal.color.r, texturaOriginal.color.g, texturaOriginal.color.b, 0);
        }
        else if (other == other.gameObject.CompareTag("interactuarInterior"))
        {
            puedeInteractuar = false;
            texturaOriginal.sprite = puntoTextureCambiar;
             gameObject.transform.GetComponentInChildren<Animator>().enabled = false;
             gameObject.transform.GetComponentInChildren<Animator>().gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1.0599f, 0.908f);
        }
    }

}