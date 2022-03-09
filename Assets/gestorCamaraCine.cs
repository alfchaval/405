using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestorCamaraCine : MonoBehaviour {

    public GameObject camaraJugador;
    public GameObject puertaPrincipal;
    public GameObject objetoPasos;

    private managersubtitulos managersubtitulos;
    private AuxiliarSonidos auxiliarSonidos;

	void Start ()
    {
        managersubtitulos = FindObjectOfType<managersubtitulos>();
        auxiliarSonidos = FindObjectOfType<AuxiliarSonidos>();
	}

    public void desactivar()
    {
        gameObject.SetActive(false);
    }
    public void DialogoPostSofa0()
    {
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                managersubtitulos.escribirDurante(1, "insertar aqui sonido del tio levantandose");
                break;
            case LanguageManager.Language.Spanish:
                managersubtitulos.escribirDurante(1, "insertar aqui sonido del tio levantandose");
                break;
        }
    }
    public void DialogoPostSofa1()
    {

        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                auxiliarSonidos.vozHayAlguien();
                managersubtitulos.escribirDurante(4, "Hello? Is anyone there?", false);
                break;
            case LanguageManager.Language.Spanish:
                auxiliarSonidos.vozHola();
                managersubtitulos.escribirDurante("¿Hola?", false);
                break;
        }
    }
    public void DialogoPostSofa2()
    {
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                // managersubtitulos.escribirDurante(3, "¿hay alguien?");
                break;
            case LanguageManager.Language.Spanish:
                auxiliarSonidos.vozHayAlguien();
                managersubtitulos.escribirDurante(3, "¿hay alguien?");
                break;
        }
    }


    public void DialogoPostSofa3()
    {
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                managersubtitulos.escribirDurante(3, "Who's having a laugh at this hour?");
                break;
            case LanguageManager.Language.Spanish:
                managersubtitulos.escribirDurante(3, "Who's having a laugh at this hour?");
                break;
        }
        auxiliarSonidos.vozBromas();
    }

    public void sonidoPaso()
    {
        objetoPasos.GetComponent<AudioSource>().Play();
    }

    public void EncenderCamaraJugador()
    {
        camaraJugador.GetComponent<Camera>().enabled = true;
    }
    public void ApagarCamaraJugador()
    {
        camaraJugador.GetComponent<Camera>().enabled = false;
    }
    public void AbrirPuertaPrincipal()
    {
        puertaPrincipal.GetComponent<Animator>().SetBool("Open", true);
       
    }

    public void CerrarPuertaPrincipal()
    {
        puertaPrincipal.GetComponent<Animator>().SetBool("Open", false);

    }

    public void QuitarControlAux()
    {
        FindObjectOfType<GameManager>().QuitarControl();
    }
    public void DevoolverControlAux()
    {
        FindObjectOfType<GameManager>().DevolverControl();
    }

    public void CustomInvoke(string methodName,float time)
    {
        Invoke(methodName, time);
    }

    public void HideInvNew()
    {
       FindObjectOfType<GameManager>().newInventory.SetActive(false);
    }
    public void UnideInvNew()
    {
        FindObjectOfType<GameManager>().newInventory.SetActive(true);
    }
    //public void SpawnSofaTrick()
    //{
    //    transform.Find("SofaCameraTrick").transform.GetChild(0).gameObject.SetActive(true);
    //}
}
