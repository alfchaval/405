using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderAux : MonoBehaviour {

    public GameObject puntoInterCasParanoia;
    public AudioSource thisSource;
    public AudioClip[] clip;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            if (gameObject.name.Contains("ColliderTriggerCassette"))
            {
                print("Aquí estamos");
                puntoInterCasParanoia.SetActive(true);
                GameObject.Find("Audio Source CassetteCayendo").GetComponent<AudioSource>().Play();
                switch (FindObjectOfType<LanguageManager>().currentLanguage)
                {
                    case LanguageManager.Language.English:
                        FindObjectOfType<managersubtitulos>().escribirDurante(2, "What was that?");
                        break;
                    case LanguageManager.Language.Spanish:
                        FindObjectOfType<managersubtitulos>().escribirDurante(2, "¿Qué ha sido eso?");
                        break;
                }

            }
            else if (gameObject.name.Contains("ColliderTriggerKnife in table"))
            {
                GameObject.Find("Kitchen_knifeDestruir").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.Find("Kitchen_knifeDestruir").transform.GetChild(0).gameObject.SetActive(true);
                print("MIGUE AQUI FALTA SONIDO migue Migue MIGUE CUCHILLO CLAVADO EN TABLA");
            }
            else if (gameObject.name.Contains("ColliderWhattheHell"))
            {
                FindObjectOfType<AuxiliarSonidos>().VozWhatTheHell();
            }
            this.gameObject.SetActive(false);
        }
    }

    public void changeSoundtrackAfterFirstTape()
    {
        FindObjectOfType<AuxiliarSonidos>().FadeOut();
    }

    public void LlamarFinalUsarGrabadoraOficina()
    {
        FindObjectOfType<InteracionConObjetosRayCast>().UsarGrabadoraOficina();
    }

    public void SonidoAbrirCajon() 
     {
        FindObjectOfType<AuxiliarSonidos>().sonidoCajonAbrir();
        GameObject.Find("Abrible").GetComponent<Animator>().Play("AbrirCajon");
    }

    public void SonidoCerrarCajon()
    {
        FindObjectOfType<AuxiliarSonidos>().sonidoCajonCerrar();
        GameObject.Find("Abrible").GetComponent<Animator>().Play("CerrarCajon");
    }

    public void WatchCajonOpenTrigger()
    {
        GameObject.Find("CamaraCine").GetComponent<Animator>().Play("WatchCajonOpen");

    }

    public void playthisSource(int num)
    {
        thisSource.clip = clip[num];
        thisSource.Play();

    }


}
