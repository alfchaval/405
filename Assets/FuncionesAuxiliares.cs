using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionesAuxiliares : MonoBehaviour {

    private managersubtitulos managersubtitulos;

	void Start ()
    {
        managersubtitulos = FindObjectOfType<managersubtitulos>();
    }

    public void EscribirDuranteNotaInventarioAdded()
    {
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                managersubtitulos.escribirDurante(4, "Added to the inventory");
                break;
            case LanguageManager.Language.Spanish:
                managersubtitulos.escribirDurante(4, "Guardado en Inventario");
                break;
        }
    }
    public void SuenaAporrearPuerta()
    {
        GetComponent<AudioSource>().Play();
    }
    public void SuenaManillar()
    {
        transform.GetChild(0).GetComponent<AudioSource>().Play();
    }
    public void MostrarSubtituloAux()
    {
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                managersubtitulos.escribirDurante(1, "Someone's there?");
                break;
            case LanguageManager.Language.Spanish:
                managersubtitulos.escribirDurante(1, "¡¿Hola?! ¡¿Hay alguien ahí?!");
                break;
        }
        FindObjectOfType<AuxiliarSonidos>().vozMaryAhi1();
    }

    public void MostrarSubtituloAux2()
    {
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                managersubtitulos.escribirDurante(3, "Mary?...");
                break;
            case LanguageManager.Language.Spanish:
                managersubtitulos.escribirDurante(3, "¿Mary?... que extraño...");
                break;
        }
    }

    public void MostrarSubtituloAux0()
    {
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                managersubtitulos.escribirDurante(1, "Wont open");
                break;
            case LanguageManager.Language.Spanish:
                managersubtitulos.escribirDurante(1, "Está cerrado...");
                break;
        }
    }

    public void MostrarSubtituloAux3()
    {
        FindObjectOfType<AuxiliarSonidos>().vozMaryAhi4();
    }
}
