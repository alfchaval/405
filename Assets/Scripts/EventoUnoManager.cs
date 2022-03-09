using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoUnoManager : MonoBehaviour
{
    public bool estaYaHaSonado;
    public GameManager gamemanager;

    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !estaYaHaSonado)
        {
            if (gameObject.name.Equals("Pasillo"))
            {      
              //  FindObjectOfType<managersubtitulos>().escribirDurante(2, "¿Mary? ¿Estás aqui?", true);
                //
                //
                //
                //.vozMaryAhi1();
            }
            else if (gameObject.name.Equals("Despacho"))
            {
               // FindObjectOfType<managersubtitulos>().escribirDurante(3, "No creo que esté en mi despacho.", true);
            }
            else if (gameObject.name.Equals("Dormitorio"))
            {
                FindObjectOfType<LookAtTransform>().Look(GameObject.Find("Bed_1").transform);
                switch (FindObjectOfType<LanguageManager>().currentLanguage)
                {
                    case LanguageManager.Language.English:
                        FindObjectOfType<managersubtitulos>().escribirDurante(4, "I don't get it... Where's Mary?", true);
                        break;
                    case LanguageManager.Language.Spanish:
                        FindObjectOfType<managersubtitulos>().escribirDurante(4, "Hmmm...No entiendo nada, habría dejado una nota o algo...", true);
                        break;
                }

                gamemanager.triggerPuertaCocina.SetActive(true);
                //TRIGGEAR AUDIO MARY ESTAS AHI??
            }
            else if (gamemanager.habitacionesVisitadas == 3)//repetido?
            {
                //FindObjectOfType<managersubtitulos>().escribirDurante(4, "uhm no entiendo nada, habria dejado una nota o algo...");
            }
            else if (gameObject.name.Equals("CocinaTrigger"))
            {
                AuxiliarPortazo();
                Invoke("AuxiliarEscribirfinalEventoUno", 1);
            }
            gamemanager.habitacionesVisitadas++;
            Debug.Log("Entra en habitación:" + gameObject.name);
            if (gamemanager.habitacionesVisitadas == 2)
            {
               // auxiliarSonidos.vozHolaMary();
            }
            if (gamemanager.habitacionesVisitadas >= 3 && !gameObject.name.Equals("Dormitorio"))
            {               
                gamemanager.QuitarControl();
                AuxiliarPortazo();
                Invoke("AuxiliarEscribirfinalEventoUno", 1);
                gamemanager.CambiarEstado(1);
                Invoke("AuxiliarDevolverControl", 4f);
            }
            if (true)
            {

            }
            gameObject.SetActive(false);
            estaYaHaSonado = true;
        }
    }

    public void AuxiliarPortazo()
    {
        print("teeeeeest");
        gamemanager.QuitarControl();
        GameObject.Find("Audio SourcePortazo").GetComponent<AudioSource>().Play();
        FindObjectOfType<AuxiliarSonidos>().vozPeroQue();
        FindObjectOfType<InteracionConObjetosRayCast>().CallMaryCry();
        FindObjectOfType<AuxiliarSonidos>().ostEscena3Tema5();
    }

    public void AuxiliarEscribirfinalEventoUno()
    {
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                FindObjectOfType<managersubtitulos>().escribirDurante(6, "Christ! What the...? Mary?", true);
                break;
            case LanguageManager.Language.Spanish:
                FindObjectOfType<managersubtitulos>().escribirDurante(6, "¿Qué ha sido eso?", true);
                break;
        }
        Invoke("AuxiliarDevolverControl", 4);
    }

    public void AuxiliarDevolverControl()
    {
        gamemanager.DevolverControl();
    }
}

