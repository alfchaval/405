using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleCortina : MonoBehaviour {

    public GameObject animacionagua;
    public Animator bisagraDePuerta;
    public Animator animSangreTrig;
    public GameObject puntoInteracionRecogerLlave;
    public Animator animCortina;
    public AudioSource SonidoCaida;
    public Animator animSangreError;
    public bool sangreYaMostrada;
    // Use this for initialization
	void Start () {
        Invoke("AuxiliarMute", 2);

	}
	
	// Update is called once per frame
	void Update () {
        if (!sangreYaMostrada)
        {

            if (animSangreTrig.GetBool("EnciendeSangre"))
            {
                sangreYaMostrada = true;
                Invoke("InvokeAparecerPuntoInteracion", 4);
            }
        }
	}
    public void HaAbiertoCortina()
    {
        print("entra en se ha abierto cortina");
        print("AHORA ESTO PASA SIEMRPEEEEEEE ");
           //animSangreTrig.transform.parent.gameObject.SetActive(true);
        //if (bisagraDePuerta.GetBool("AbrirPuerta"))
        //{
        //    print("abre cortina con puerta abierta asi que apaga el objeto " + animSangreTrig.transform.parent.gameObject.name + " y enciende el objeto " + animSangreError.transform.parent.gameObject.name);
        //    animSangreTrig.transform.parent.gameObject.SetActive(false);
        //    animSangreError.transform.parent.gameObject.SetActive(true);
        //}
        //else
        //{
            print("abre cortina con puerta cerrada asi que enciende el objeto " + animSangreTrig.transform.parent.gameObject.name + " y apaga el objeto " + animSangreError.transform.parent.gameObject.name);
            animSangreTrig.transform.parent.gameObject.SetActive(true);
            animSangreError.transform.parent.gameObject.SetActive(false);
        //}
    }

    public void InvokeAparecerPuntoInteracion()
    {
        puntoInteracionRecogerLlave.SetActive(true);//hay que hacerla hija del cubo
       // GameObject.Find("PuntoInteraccion InterCortina").SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && animCortina.GetBool("CortinaAbierta"))
        {
            animCortina.SetBool("CortinaAbierta", false);
            FindObjectOfType<GameManager>().PuntoInterCortina.SetActive(true);
            FindObjectOfType<GameManager>().sangreCompletado.SetActive(false);
            animSangreTrig.transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && animCortina.GetBool("CortinaAbierta"))
        {
            animCortina.SetBool("CortinaAbierta", false);
            FindObjectOfType<GameManager>().PuntoInterCortina.SetActive(true);
            animSangreTrig.transform.parent.gameObject.SetActive(false);
        }
    }

    public void AuxiliarMute()
    {
        animCortina.gameObject.GetComponent<AudioSource>().mute = false;
    }
}
