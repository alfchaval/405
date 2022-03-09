using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Grabadora : MonoBehaviour
{
    public int evento;
    bool grabadoraOn;
    public bool cassetteWCsonado;
    public GameObject luztelevision;
    public GameObject pantallatelevision3D;
    public bool rebobinadaWillyCinta;
    public bool rebobinadaWaterCinta;

    public void Awake()
    {
        print("se enciende grabadora awake");
        PlayerPrefs.SetInt("PsicofoniaSonada", 0);
    }

    public void OnDisable()
    {
        print("se apaga la grabadora");
    }

    public void OnTriggerStay(Collider enter)
    {
        if (enter == enter.gameObject.CompareTag("eventoGrabadora") && grabadoraOn)
        {
            GetComponent<AudioSource>().clip = enter.gameObject.GetComponent<InfoItem>().clipItem;
        }
    }

    public void ToggleRecord()
    {
        grabadoraOn = true;
        Invoke("RecordOff", 1);
    }

    public void RecordOff()
    {
        grabadoraOn = false;
    }

    public void CleanRecord()
    {
        GetComponent<AudioSource>().clip = null;
    }

    public void RebobinarAtras()
    {
        if (GetComponent<AudioSource>().clip.name.Contains("CassetteTrabajo") && !rebobinadaWaterCinta)
        {
            print("rebobina cinta WC");
            rebobinadaWaterCinta = true;
        }
        else if (GetComponent<AudioSource>().clip.name.Contains("CassetteTrabajo"))
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    FindObjectOfType<managersubtitulos>().escribirDurante(2, "Its already rewind", true);
                    break;
                case LanguageManager.Language.Spanish:
                    FindObjectOfType<managersubtitulos>().escribirDurante(2, "No puedo rebobinar la cinta porque ya está rebobinada", true);
                    break;
            }
            print("no puedo rebobinar la cinta Wc porque ya esta rebobinada");
        }

        if (GetComponent<AudioSource>().clip.name.Contains("cintawillygolpes") && !rebobinadaWillyCinta)
        {
            print("rebobina cinta willyllantos");
            rebobinadaWillyCinta = true;
        }
        else if (GetComponent<AudioSource>().clip.name.Contains("cintawillygolpes"))
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    FindObjectOfType<managersubtitulos>().escribirDurante(2, "It's already rewinded", true);
                    break;
                case LanguageManager.Language.Spanish:
                    FindObjectOfType<managersubtitulos>().escribirDurante(2, "No puedo rebobinar la cinta porque ya está rebobinada", true);
                    break;
            }
            print("no puedo rebobinar la cinta willyllantos porque ya esta rebobinada");
        }

        if (!GetComponent<AudioSource>().clip.name.Contains("CassetteTrabajo") && !GetComponent<AudioSource>().clip.name.Contains("cintawillygolpes"))
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    FindObjectOfType<managersubtitulos>().escribirDurante(2, "There's nothing to rewind", true);
                    break;
                case LanguageManager.Language.Spanish:
                    FindObjectOfType<managersubtitulos>().escribirDurante(2, "No hay nada que rebobinar", true);
                    break;
            }
            print("no hay nada que rebobinar");
        }
    }

    public void ForwardAdelante()
    {
        if (GetComponent<AudioSource>().clip.name.Contains("CassetteTrabajo") && rebobinadaWaterCinta)
        {
            print("avanza la cinta WC");
            rebobinadaWaterCinta = false;
        }
        else
        {
            print("no puedo Avanzar la cinta Wc porque ya esta Avanzada");
        }

        if (GetComponent<AudioSource>().clip.name.Contains("cintawillygolpes") && rebobinadaWillyCinta)
        {
            print("avanza la cinta WC");
            rebobinadaWillyCinta = false;
        }
        else
        {
            print("no puedo rebobinar la cinta willyllantos porque ya esta rebobinada");
        }
        if (!GetComponent<AudioSource>().clip.name.Contains("CassetteTrabajo") && !GetComponent<AudioSource>().clip.name.Contains("cintawillygolpes"))
        {
            print("no hay nada que rebobinar");
        }
    }

    public void LlamarGrabadora()
    {
        // ANIM GRABADORA ESCUCHAR(AL TERMINAR GRABACION)---- > GRABADORA DEJAR DE ESCUCHAR

        //Usar cassete desde notes: ----> grabadora probar cassete

        //grabadora probar cassete(al terminar grabacion)---- > dejarDeEscuchar Cinta
        AudioSource audioSource = GetComponent<AudioSource>();
        print(audioSource.clip.name);
        if (audioSource.clip.name.Contains("CassetteTrabajo") && !cassetteWCsonado)
        {
            FindObjectOfType<AuxiliarSonidos>().GetComponent<AudioSource>().Stop();
            Invoke("llamadaAbrirWC", 35f);
        }
        else if (audioSource.clip.name.Contains("Pelea_00"))// EL NOMBRE DE LA PISTA DE LA CINTA FINAL
        {
            Invoke("finalDeJuego", audioSource.clip.length + 1);
        }
        else if (audioSource.clip.name.Contains("old phone ringing"))
        {
            Invoke("delayRingPlay", Random.Range(1, 4));
        }
        else if (audioSource.clip.name.Contains("Gut") && PlayerPrefs.GetInt("PsicofoniaSonada") == 0)
        {
            PlayerPrefs.SetInt("PsicofoniaSonada", 1);
            FindObjectOfType<AuxiliarSonidos>().callJohnCor();

        }
       
        audioSource.Play();

    }

    public void StopGrabadora()
    {
        if (GetComponent<AudioSource>().clip.name.Contains("CassetteTrabajo") && !cassetteWCsonado)
        {
            llamadaAbrirWC();
        }
        else if (GetComponent<AudioSource>().clip.name.Contains("old phone ringing"))
        {
            Invoke("delayRingStop", Random.Range(1, 2));
        }
        GetComponent<AudioSource>().Stop();
    }

    public void delayRingPlay()
    {
        FindObjectOfType<GameManager>().trueFinalphoneInteractiveSpot.SetActive(true);
        GameObject.Find("Phone").GetComponent<AudioSource>().clip = GameObject.Find("Phone").GetComponent<ClipStorage>().ring;
        GameObject.Find("Phone").GetComponent<AudioSource>().loop = true;
        GameObject.Find("Phone").GetComponent<AudioSource>().Play();
    }
    public void delayRingStop()
    {
        FindObjectOfType<GameManager>().trueFinalphoneInteractiveSpot.SetActive(false);
        GameObject.Find("Phone").GetComponent<AudioSource>().clip = GameObject.Find("Phone").GetComponent<ClipStorage>().ring;
        GameObject.Find("Phone").GetComponent<AudioSource>().Stop();
    }
    public void llamadaAbrirWC()
    {
        if (!cassetteWCsonado)
        {
            FindObjectOfType<AuxiliarSonidos>().ostEscena7Tema8_2();
            FindObjectOfType<GameManager>().InvokeTV();
            cassetteWCsonado = true;
        }

    }

    public void finalDeJuego()
    {
        //quitar joystick
        GameObject.Find("ManagerSoundtrack").GetComponent<AudioSource>().Stop();
        //FindObjectOfType<GameManager>().QuitarControlFinal();//  POR AQUI SIGUE ALFONSO //CAMBIO FINAL
        //fundido a negro
        GameObject.Find("PanelFade").GetComponent<Animator>().Play("FadeIn");
        Invoke("callPostFadeIn", 3f);
        //teleportación

        //te acercas a la tele

        //se reproduce el vídeo
    }

    public void callFadeOutPanel()// alterado
    {
        GameObject.Find("InventarioNuevo").SetActive(false);
        GameObject.Find("PanelFade").GetComponent<Animator>().Play("FadeOut");
        FindObjectOfType<GameManager>().doorFinalInteractiveSpot.SetActive(true);
        GameObject.Find("PanelFade").GetComponent<Animator>().SetBool("FinalAnim", false);
        FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.ForwardSpeed = 2f;
        FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.StrafeSpeed = 3f;
        FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.BackwardSpeed = 1f;
        //Invoke("CallTv2D", 8f);
        //Invoke("callVozNoPuedoSer", 15f);
        //FindObjectOfType<GameManager>().camaraCine.GetComponent<Animator>().Play("enfocar tv grabación final");
    }

    public void CallTv2D()//es la 3D pero vamos a dejarlo asi para que no de problemas
    {
        GameObject.Find("CamaraCine2").GetComponent<Animator>().enabled = false;
        //luztelevision.SetActive(true);
        pantallatelevision3D.GetComponent<VideoPlayer>().clip = FindObjectOfType<GameManager>().VideoCarretera;
        pantallatelevision3D.GetComponent<VideoPlayer>().Play();
        pantallatelevision3D.GetComponent<Renderer>().material.color = FindObjectOfType<GameManager>().colorTVOn;
    }
    public void callVozNoPuedoSer()
    {
        FindObjectOfType<AuxiliarSonidos>().vozNoPuedoSerYo();
    }
    public void callPostFadeIn()                    //CAMBIO FINAL
    {
        //Transform player = GameObject.Find("PLayer").transform;
        //player.position = new Vector3(-5.75f, player.position.y, -4.15f);
        //player.eulerAngles = new Vector3(0f, -90f, 0f);
        this.GetComponent<AudioSource>().Stop();
        //FindObjectOfType<GameManager>().camaraCine.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-0.753f, 0.452f, -1.395f);
        GameObject.FindGameObjectWithTag("Player").transform.rotation = Quaternion.identity;
        GameObject.FindGameObjectWithTag("Player").transform.Rotate(new Vector3(0, 90, 0));
        FindObjectOfType<GameManager>().DevolverControl();
        FindObjectOfType<AuxiliarSonidos>().sonidoMinutoFinal();
        GameObject.Find("PanelFade").GetComponent<Animator>().SetBool("FinalAnim", true);
        Invoke("callFadeOutPanel", 83f);
        FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.ForwardSpeed = 0.3f;
        FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.StrafeSpeed = 0.3f;
        FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.BackwardSpeed = 0.1f;
        FindObjectOfType<AuxiliarSonidos>().FadeOut();
    }

    //public void callPostFadeIn() //SAFETY COPY
    //{
    //    //Transform player = GameObject.Find("PLayer").transform;
    //    //player.position = new Vector3(-5.75f, player.position.y, -4.15f);
    //    //player.eulerAngles = new Vector3(0f, -90f, 0f);
    //    this.GetComponent<AudioSource>().Stop();
    //    FindObjectOfType<GameManager>().camaraCine.SetActive(true);
    //    GameObject.FindGameObjectWithTag("Player").SetActive(false);
    //    FindObjectOfType<AuxiliarSonidos>().sonidoMinutoFinal();
    //    Invoke("callFadeOutPanel", 70f);

    //}

    //public void callFadeOutPanel()// alterado  //Safety copy
    //{
    //    GameObject.Find("PanelFade").GetComponent<Animator>().Play("FadeOut");
    //    //Invoke("CallTv2D", 8f);
    //    //Invoke("callVozNoPuedoSer", 15f);
    //    //FindObjectOfType<GameManager>().camaraCine.GetComponent<Animator>().Play("enfocar tv grabación final");
    //}
}