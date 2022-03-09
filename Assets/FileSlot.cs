using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileSlot : MonoBehaviour
{

    public bool ocupado;
    public Sprite imagenDeFondo;

    public string textoAMostrar;

    public string tituloBoton;

    public AudioClip sonidoACargarEnGrabadora;

    public GameObject grabadora;

    public InventoryManager inventoryManager;

    public bool seguroDeAcion;

    // Use this for initialization
    void Start()
    {
        //if (this.gameObject.name.Contains("Cassete"))
        //{
        //    FindObjectOfType<InteracionConObjetosRayCast>().listaObjetosAux.Add(this.gameObject);
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void QuitarSeguroInteracion()
    {
        seguroDeAcion = false;
    }

    public void AddFile(string tituloCasete, AudioClip soniddoAcargar)// SEGUIR POR AQUI
    {
        if (!seguroDeAcion)
        {
            seguroDeAcion = true;
            Invoke("QuitarSeguroInteracion",0.2f);

        ocupado = true;
        tituloBoton = tituloCasete;
        sonidoACargarEnGrabadora = soniddoAcargar;
        transform.GetComponentInChildren<Text>().text = tituloBoton;
            print("entra en addfile cassete con los valores: " + tituloCasete + " " + soniddoAcargar.name);
        }
    }
    public void AddFile(Sprite imagenDeFondo, string textoAMostra, string tituloNota) //Titulo 
    {
        print("entra en addfile con los valores: " + imagenDeFondo.name + " " + textoAMostra + " " + tituloNota);
        if (!seguroDeAcion)
        {
            print("entra en seguro de accion = false, y lo pone a true");
            ocupado = true;
        this.imagenDeFondo = imagenDeFondo;
        this.textoAMostrar = textoAMostra;
        tituloBoton = tituloNota;
        transform.GetComponentInChildren<Text>().text = tituloNota;
            print("ADD FILLE  " + gameObject.name);
        }
    }

    public void PulsarEnCintaDesdeInventario()
    {
        if (GameObject.Find("grabadora"))
        {            
            if (ocupado)
            {
                if (grabadora.transform.GetChild(0).GetComponent<Animator>().GetBool("CintaPuesta"))
                {
                    grabadora.transform.GetChild(0).GetComponent<Animator>().SetBool("CintaPuesta", false);
                    Invoke("InvokePonerCinta", 2);
                    print("la cinta estaba puesta, quitamos y....");
                }
                else
                {
                    grabadora.transform.GetChild(0).GetComponent<Animator>().SetBool("CintaPuesta", true);
                    grabadora.transform.GetChild(0).GetComponent<Animator>().Play("NewProbarCassete");
                }
                inventoryManager.CallGrabadoraDesdeCassete();
                inventoryManager.OpenRecorderPanel();
                grabadora.GetComponent<AudioSource>().clip = sonidoACargarEnGrabadora;
            }
            else
            {
                print("el slot esta vacio");
            }
        }
        else
        {
            FindObjectOfType<InventoryManager>().llamarGrabadora();        
            FindObjectOfType<GameManager>().instanceUV.ApagarTodasLuces();
            PulsarEnCintaDesdeInventario();
        }
        

    }
    public void InvokePonerCinta()
    {
     
            grabadora.transform.GetChild(0).GetComponent<Animator>().SetBool("CintaPuesta", true);
            print("..... y.... ponemos");
        
       
    }
    public void PulsarEnNotaDesdeInventario()
    {
            if (ocupado)
            {
            if (this.textoAMostrar.Contains("mora"))
            {
                FindObjectOfType<MemoManager>().GetComponent<MemoManager>().PickUpMemo(2, imagenDeFondo, this.textoAMostrar);
            }
            else if (this.textoAMostrar.Contains("perdonarme"))
            {

                FindObjectOfType<MemoManager>().GetComponent<MemoManager>().PickUpMemo(4, imagenDeFondo, this.textoAMostrar);
            }
            else if (this.textoAMostrar.Contains("milla"))
            {
                FindObjectOfType<MemoManager>().GetComponent<MemoManager>().PickUpMemo(5, imagenDeFondo, this.textoAMostrar);
            }
                
            }
            else
            {
                print("el slot esta vacio");
            }
        
      

    }
}

