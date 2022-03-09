using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pasos : MonoBehaviour {

    public AudioSource pasos;
    public AudioClip pasosSuelo;
    public AudioClip pasosAlfombra;
    public AudioClip pasosAzulejo;
    public GameObject Player;
    Vector2 input;
    public Animator animPasos;
    public bool enAlfombra;

    // Use this for initialization
    void Start () {
  
    }

    public void CallStep()
    {
        pasos.pitch = (Random.Range(0.8f, 1.2f));
        pasos.PlayOneShot(pasos.clip);

    }
    // Update is called once per frame
    void Update () {

        if (Player.GetComponent<MyPlayer>().joy.sqrMagnitude > 0)
        {
            animPasos.SetBool("mover",true);
        }
        else
        {
            animPasos.SetBool("mover", false);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (Player.GetComponent<MyPlayer>().joy.sqrMagnitude > 0)
        {
            if (other.gameObject.tag == "alfombra")
            {
                enAlfombra = false;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "alfombra")
        {
            enAlfombra = true;
            pasos.clip = pasosAlfombra;
   

            
        }
        else
        {
            if (!enAlfombra)
            {
                if (Player.GetComponent<MyPlayer>().joy.sqrMagnitude > 0)
                {
                    if (other.gameObject.tag == "suelo")
                    {
                        pasos.clip = pasosSuelo;
                      
                        enAlfombra = false;
                    }
                    else if (other.gameObject.tag == "azulejo")
                    {
                        pasos.clip = pasosAzulejo;

                        enAlfombra = false;
                    }


                    // pasos.Play();
                }
            }
            
        }
        

    





    /*if (Player.GetComponent<MyPlayer>().joy.sqrMagnitude > 0 && other.gameObject.tag == "suelo")
    {
        pasos.clip = pasosSuelo;
        print("Pasos suelo activated");
        // pasos.Play();
    }
    else if(Player.GetComponent<MyPlayer>().joy.sqrMagnitude > 0 && other.gameObject.tag == "suelo" || other.gameObject.tag == "azulejo" && other.gameObject.tag == "alfrombra")
    {
        pasos.clip = pasosAlfombra;
        print("Pasos alfombra activated");
    //    pasos.Play();
    }
    else if (Player.GetComponent<MyPlayer>().joy.sqrMagnitude > 0 && other.gameObject.tag == "suelo" && other.gameObject.tag == "azulejo")
    {
        pasos.clip = pasosAzulejo;
        print("Pasos azulejo activated");
        //    pasos.Play();
    }*/
    //else
    //{
    //    pasos.Stop();
    //}
}
}
