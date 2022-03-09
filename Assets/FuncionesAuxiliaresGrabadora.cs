using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionesAuxiliaresGrabadora : MonoBehaviour {

    public bool BathAbierto;
    public bool cerrojo;
    public GameObject panelCerrojo;
    public AudioSource sourceFisico;
    public AudioClip[] soundFisico; //0 Boton - 1 Sacar - 2 Meter
    public bool yaHaSonadoDialogo3;
    public LuzUltraVioleta refALuz;
    MyPlayer myplayer;

    private managersubtitulos managersubtitulos;

    void Start ()
    {
        sourceFisico = gameObject.GetComponent<AudioSource>();
        managersubtitulos = FindObjectOfType<managersubtitulos>();
        myplayer = FindObjectOfType<MyPlayer>();
        //Invoke("llamarFake", 2f);
    }
	
	void Update ()
    {

        if (myplayer.joy.sqrMagnitude > 0)
        {
            GetComponent<Animator>().SetBool("Walking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walking", false);
        }
    }

    //public void llamarFake() Example
    //{
    //        LiberarCamara();
    //        GetComponent<Animator>().Play("MovimientoGrabadora");
    //}
    public void LiberarCamara()
    {
        transform.parent.gameObject.GetComponent<Animator>().Play("ApagarFirstPersonController");
        GetComponent<Animator>().enabled = true;
    }
    public void DevolverControlConGrabadoraAux()
    {
        FindObjectOfType<GameManager>().DevolverControlConGrabadora();
    }

    public void DevolverCamara()
    {
        transform.parent.gameObject.GetComponent<Animator>().Play("EncenderFirstPersonController");
        GetComponent<Animator>().enabled = false;
    }

    public void EjecutarAnimacionCamaraConGrabadora()
    {
        GetComponent<Animator>().Play("AnimacionCabezaMientrasGrabadora");// ESTE NO ES EL NOMBRE DE LA ANIMACION ES PLACEHOLDER
    }

    public void triggerAudioPasos()
    {
        FindObjectOfType<Pasos>().GetComponent<AudioSource>().volume = Random.Range(0.8f, 1);
        FindObjectOfType<Pasos>().GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
        FindObjectOfType<Pasos>().GetComponent<AudioSource>().Play();
    }


    public void sonidoBoton()
    {
        sourceFisico.clip = soundFisico[0];
        sourceFisico.Play();
    }
    public void sonidoSacar()
    {
        sourceFisico.clip = soundFisico[1];
        sourceFisico.Play();
    }
    public void sonidoMeter()
    {
        sourceFisico.clip = soundFisico[2];
        sourceFisico.Play();
    }

    public void DejarDeGrabar()
    {
        GetComponent<Animator>().Play("NewDejarDeEscuchar");
    }
    public void ExaminarGrabadora()
    {
        GetComponent<Animator>().Play("NewExaminarGrabadora");
    }
    public void escribirDialogoGrabadora1()
    {
        refALuz.ApagarTodasLuces();
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                managersubtitulos.escribirDurante(5, "My... tape recorder? I never leave tapes in...", true);
                break;
            case LanguageManager.Language.Spanish:
                managersubtitulos.escribirDurante(5, "Mi grabadora ¿tendrá algo grabado?", true);
                break;
        }
        //FindObjectOfType<GameManager>().objetoSoundtrack.GetComponent<AudioSource>().clip = FindObjectOfType<SoundtrackManager>().Perdida;
        //FindObjectOfType<GameManager>().objetoSoundtrack.GetComponent<AudioSource>().Play();


    }

    public void escribirDialogoGrabadora2()
    {
        sourceFisico.clip = null;//para que no se escuche mas el audio del llanto
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                managersubtitulos.escribirDurante(2, "That’s... my voice... When...? How? When did this happen?");
                break;
            case LanguageManager.Language.Spanish:
                managersubtitulos.escribirDurante(2, "Yo...no recuerdo haber grabado nada de esto,");
                break;
        }
        FindObjectOfType<AuxiliarSonidos>().GetComponent<AuxiliarSonidos>().vozNoRecuerdo();
     //   Invoke("escribirDialogoGrabadora3", 7);
    }

    public void escribirDialogoGrabadora2con5()
    {
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                managersubtitulos.escribirDurante(5, "It's empty", true);
                break;
            case LanguageManager.Language.Spanish:
                managersubtitulos.escribirDurante(5, "No hay ninguna cinta dentro", true);
                break;
        }
        FindObjectOfType<Grabadora>().GetComponent<AudioSource>().clip = null;
        Invoke("escribirDialogoGrabadora3", 5.5f);
       
        //Invoke("escribirDialogoGrabadora4", 5);
    }

    public void escribirDialogoGrabadora3()
    {
        if (!yaHaSonadoDialogo3)
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                 
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante("No...n-no…estoy demasiado asustado, es solo eso, tengo que respirar y pensar con calma.", false);
                    break;
            }
            FindObjectOfType<AuxiliarSonidos>().GetComponent<AuxiliarSonidos>().vozDemasiadoAsustado();
            //Invoke("escribirDialogoGrabadora4", 5);
            yaHaSonadoDialogo3 = true;
            Invoke("escribirDialogoGrabadora4", 7);
        }

    }

    public void escribirDialogoGrabadora4()
    {
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                managersubtitulos.escribirDurante(6, "I shoul listen to the other tape");
                break;
            case LanguageManager.Language.Spanish:
                managersubtitulos.escribirDurante(6, "Deberia comprobar la cinta que encontre en el retrete");
                break;
        }
        GameObject.Find("InventoryManager").GetComponent<InventoryManager>().OpenRecorderPanel();
        
            //Invoke("escribirDialogoGrabadora4", 5);
      

    }

    public void auxiliarPlayGrabadora()
    {
        FindObjectOfType<Grabadora>().LlamarGrabadora();
    }


    public void AbreBath()
    {
        if (!BathAbierto)
        {
            GameObject.Find("puertaParaLuis (3)").GetComponentInChildren<Animator>().SetBool("AbrirPuerta", true);
            BathAbierto = true;
        }     
    }
    public void QuitarCon()
    {
        FindObjectOfType<InventoryManager>().grabadoraEquipada = false;
        FindObjectOfType<GameManager>().QuitarControlConGrabadora();
    }
    public void DevolverCon()
    {
        
        FindObjectOfType<GameManager>().DevolverControlConGrabadora();
        FindObjectOfType<InventoryManager>().grabadoraEquipada = true;
    }

    public void ApartarInterfazGrabadora()
    {
        
        if (!cerrojo)
        {
            print("Entra en ApartarInterfazGrabadora con !cerrojo");
            //Ya está apartada
        }
        else
        {
            print("Entra en ApartarInterfazGrabadora con cerrojo");
            panelCerrojo.SetActive(true);
            cerrojo = true;
        }
        //si esta ya apartada no la apartes otra vez
        //encender panel invisible encima de la interfaz y llamar a la animcion retraer
    }

    public void DevolverInterfazGrabadora()
    {
        if (cerrojo)
        {
            print("Entra en DevolverInterfazGrabadora con cerrojo");
        }
        else
        {
            print("Entra en DevolverInterfazGrabadora con !cerrojo");
            panelCerrojo.SetActive(false);
            cerrojo = false;
        }
        //apagar panel invisible encima de la interfaz y llamar a la animcion Salir a la interfaz
    }
}
