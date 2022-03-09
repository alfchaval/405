using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RotarSintonizacionCanales : MonoBehaviour {

    float rotacionInicial;
    Vector2 vectorInicial;
    Vector2 vectorActual;

    double anguloInicial;
    double anguloActual;

    float rotacion;
    bool pulsado = false;

    public float MaxSnow = 1f;
    public float MinSnow = 0.2f;
    public float rotacionSolucion = 35f;
    public bool puzzleResuelto;

    public GameObject nieve;
    public AudioSource tvSource;

    public GameObject videoPlayerTv;
    public RotarCanales dialCanales;
    //public GameObject videoContainer;

    void Start()
    {
        rotacionInicial = transform.eulerAngles.z;
        tvSource = GameObject.Find("Vintage_tv06").GetComponent<AudioSource>();
     //   GameObject.Find("RawImage").GetComponent<VideoPlayer>().Stop();
    }

    void Update()
    {
        //videoContainer.GetComponent<VideoPlayer>().loopPointReached += OnMovieWatched;
        print("Distancia: " + Distancia(rotacionSolucion, transform.eulerAngles.z));

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 raycast = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(raycast, Input.mousePosition);
            if (raycastHit.collider && raycastHit.collider.name == "Sintonizar")
            {
                rotacionInicial = transform.eulerAngles.z;
                vectorInicial = Input.mousePosition - transform.position;
                anguloInicial = CalcularAngulo(vectorInicial);
                pulsado = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            pulsado = false;
            if (dialCanales.PosicionCorrecta() && PosicionCorrecta())
            {
                EstaEnSintonizaciónCorrecto();
                //transform.parent.gameObject.SetActive(false);
            }
        }

        else if (pulsado)
        {
            Vector2 raycast = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            /*
            RaycastHit2D raycastHit = Physics2D.Raycast(raycast, Input.mousePosition);
            if (raycastHit.collider && raycastHit.collider.name == "Sintonizar")
            {
                vectorActual = Input.mousePosition - transform.position;
                anguloActual = CalcularAngulo(vectorActual);
                transform.eulerAngles = new Vector3(0, 0, (float)(rotacionInicial + anguloActual - anguloInicial));
                CambiarTransparencia();
            }
            */
            vectorActual = Input.mousePosition - transform.position;
            anguloActual = CalcularAngulo(vectorActual);
            transform.eulerAngles = new Vector3(0, 0, (float)(rotacionInicial + anguloActual - anguloInicial));
            CambiarTransparencia();
        }
    }

    public bool PosicionCorrecta()
    {
        return Distancia(rotacionSolucion, transform.eulerAngles.z) < 10;
    }

    public void CambiarTransparencia()
    {
        var tempColor = nieve.GetComponent<Image>().color;
        tempColor.a = (Distancia(rotacionSolucion, transform.eulerAngles.z) / 180) * (MaxSnow - MinSnow) + MinSnow;
        nieve.GetComponent<Image>().color = tempColor;
    }

    private float Distancia(float rotacion1, float rotacion2)
    {
        float distancia = Math.Abs(rotacion1 - rotacion2);
        return Math.Min(distancia, 360 - distancia);
    }

    private double CalcularAngulo(Vector2 vectorA)
    {
        if (vectorA.x >= 0 && vectorA.y >= 0)
        {
            return (Math.Atan(vectorA.y / vectorA.x)) * (180 / Math.PI);
        }
        else if (vectorA.x >= 0 && vectorA.y < 0)
        {
            return 360 - (Math.Atan(-vectorA.y / vectorA.x)) * (180 / Math.PI);
        }
        else if (vectorA.x < 0 && vectorA.y >= 0)
        {
            return 180 - (Math.Atan(-vectorA.y / vectorA.x)) * (180 / Math.PI);
        }
        else
        {
            return 180 + (Math.Atan(vectorA.y / vectorA.x)) * (180 / Math.PI);
        }
    }

    public void EstaEnSintonizaciónCorrecto()//falta  que lo reproduzca desde el principio cuando ha resuelto el puzle ya que no se puede loop
    {
        if (!puzzleResuelto)
        {
            //GameObject.Find("RawImage").GetComponent<Image>().enabled = true;
            //GameObject.Find("RawImage").GetComponent<Animator>().enabled = true;
            //dialCanales.GetComponent<RotarCanales>().GetComponent<Collider2D>().enabled = false;
            //GetComponent<Collider2D>().enabled = false;
            //puzzleResuelto = true;
            //FindObjectOfType<AuxiliarSonidos>().GetComponent<AudioSource>().Stop();
            //  GameObject.Find("ButtonSalirTV").SetActive(false);
            GameObject.Find("InterfazTV BUENA").SetActive(false);
            ////FindObjectOfType<GameManager>().CustomInvoke("DevolverControl", 7f);
            Invoke("InvokarResolverPuzle", 40);//esto sera el tiempo que dura el video del tio pasando la nota debajo de la puerta
            Invoke("textoRespuestaSintonizacion", 7);
            FindObjectOfType<GameManager>().QuitarControl();
            FindObjectOfType<GameManager>().camaraCine.GetComponent<gestorCamaraCine>().ApagarCamaraJugador();
            FindObjectOfType<GameManager>().camaraCine.GetComponent<gestorCamaraCine>().gameObject.SetActive(true);
            FindObjectOfType<GameManager>().camaraCine.GetComponent<Animator>().Play("InnerMindDeliverEnvelopeAnimation");
            GameObject.Find("Vintage_tv06").GetComponent<AudioSource>().Stop();
            print("puzzle resuelto");          
            //GameObject.Find("InterfazTV BUENA").transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            //GameObject.Find("InterfazTV BUENA").transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);
            //GameObject.Find("InterfazTV BUENA").transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
           
            //GameObject.Find("RawImage").GetComponent<RawImage>().color = Color.white;
            //GameObject.Find("RawImage").GetComponent<VideoPlayer>().Stop();
            //GameObject.Find("RawImage").GetComponent<VideoPlayer>().Play();   
            //videoPlayerTv.SetActive(true);
          
            //FindObjectOfType<GameManager>().camaraCine.gameObject.SetActive(true);
            //FindObjectOfType<GameManager>().camaraCine.gameObject.GetComponent<Animator>().Play("InnerMindDeliverEnvelopeAnimation");
        }
    }

    public void textoRespuestaSintonizacion()
    {
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                FindObjectOfType<managersubtitulos>().escribirDurante(4, "What the...?", true);
                break;
            case LanguageManager.Language.Spanish:
                FindObjectOfType<managersubtitulos>().escribirDurante(4, "¿Pero qué..?", true);
                break;
        }

        FindObjectOfType<GameManager>().PuntoInterTV.SetActive(false);
        FindObjectOfType<GameManager>().puertaPuzleBano.transform.GetChild(0).gameObject.SetActive(true);


    }
    public void InvokarResolverPuzle()
    {
        puzzleResuelto = true;
        ApagarInterfaz();//HAY QUE BLOQUEAR LOS CONTROLES DE LA TV Y MOSTRAR EL VIDEO DESDE EL PRINCIPIO,CUANDO EL VIDEO ACABE, APAGA INTERFAZ
        FindObjectOfType<GameManager>().colliderAux.SetActive(true);
        //FindObjectOfType<GameManager>().CambiarEstado(5);
        FindObjectOfType<GameManager>().InterfazTV.SetActive(false);
        FindObjectOfType<LookAtTransform>().Look(GameObject.Find("Paquete 5").transform.GetChild(2));
        FindObjectOfType<GameManager>().camaraCine.gameObject.SetActive(false);
        FindObjectOfType<GameManager>().camaraCine.GetComponent<gestorCamaraCine>().EncenderCamaraJugador();
        GameObject.Find("Bisagra4").GetComponent<Animator>().Play("");
    }
    /*

    public void OnMovieWatched(VideoPlayer Player)
    {
        Debug.Log("Entra en MovieWatched");
        if (puzzleResuelto == true) {
            Player.Stop();
            Player.Play();
            Player.isLooping = false;
            Invoke("ApagarInterfaz", 10f);
            Debug.Log("En diez segundos estás fuera");
        }
        else
        {
            Player.Stop();
            Player.Play();
            Debug.Log("Repetimos la peliculita");
        }
    }
    
	*/

    public void ApagarInterfaz()
    {
        if (puzzleResuelto)
        {
            FindObjectOfType<GameManager>().CambiarEstado(5);
            FindObjectOfType<GameManager>().InterfazTV.SetActive(false);
            FindObjectOfType<GameManager>().PuntoInterTV.SetActive(false);
            tvSource.Stop();
            //FindObjectOfType<GameManager>().DevolverControl();
        }
        else
        {
            FindObjectOfType<GameManager>().InterfazTV.SetActive(false);
            tvSource.Stop();
        }
        FindObjectOfType<GameManager>().DevolverControl();

    }
}