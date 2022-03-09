using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorTelefono : MonoBehaviour {

    public string totalMarcado;
    public string nombreDelBoton;
    public string numeroDelBoton;
    public AudioSource audioLocked;
    public GameObject interacionSellarAEncender;
    public GameObject bisagra2DePuntoInteracionSellar;

    private managersubtitulos managersubtitulos;
    private AuxiliarSonidos auxiliarSonidos;

    void Start ()
    {
        managersubtitulos = FindObjectOfType<managersubtitulos>();
        auxiliarSonidos = FindObjectOfType<AuxiliarSonidos>();
        IniciarPuzzleTelefono();
    }

    public void IniciarPuzzleTelefono()
    {
        //AQUI SE DEBE DE ABRIR LA INTERFAZ PARA PUZLE TELEFONO Y COMENZAR LOS DIALOGOS
        FindObjectOfType<GameManager>().QuitarControl();
        FindObjectOfType<GameManager>().InterfazTelefono.SetActive(true);
        interacionSellarAEncender.SetActive(true);
        bisagra2DePuntoInteracionSellar.GetComponent<Animator>().SetBool("AbrirPuerta", false);
        interacionSellarAEncender.GetComponent<PuntoInteraccion>().numeroInteraccion = 5;
        audioLocked.Play();//aqui suena la puerta cerrandose
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                //managersubtitulos.escribirDurante(3, "Creo que el telefono de su madre empezaba por 555....", true);
                break;
            case LanguageManager.Language.Spanish:
                managersubtitulos.escribirDurante(3, "Creo que el telefono de su madre empezaba por 555....", true);
                break;
        }
    }

    public void AddNumber() //Extrae el número del botón pulsado y lo añade a la lista
    {
        //numeroDelBoton = nombreDelBoton.Substring(nombreDelBoton.Length - 1, 1);

        Debug.Log("Numero del botón:" + numeroDelBoton);
        Debug.Log("Antes, el total marcado era:" + totalMarcado);
        totalMarcado = totalMarcado + numeroDelBoton;
        Debug.Log("Ahora, el total marcado es:" + totalMarcado);

        if (totalMarcado.Length == 1 && totalMarcado != ("5"))
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(2, "Five..." + numeroDelBoton, true);
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(2, "su numero empezaba por 5, no por " + numeroDelBoton, true);
                    break;
            }
            totalMarcado = null;
        }
        else if (totalMarcado.Length == 1 && totalMarcado == ("5"))
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(2, "Five again...");
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(2, "Vale, el siguiente numero era... 5 de nuevo");
                    break;
            }
            auxiliarSonidos.llamarTlF1();
            //AQUIIII1
        }

        else if (totalMarcado.Length == 2 && totalMarcado != ("55"))
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(3, "Come one, it's not a big deal, let's start again.", true);
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(3, "Vamos no es tan dificil.. 5...5..., otra vez.", true);
                    break;
            }
            totalMarcado = null;

        }
        else if (totalMarcado.Length == 2 && totalMarcado == ("55"))
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(2, "Another five...");
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(2, "Ahora toca 5 otra vez");
                    break;
            }
            auxiliarSonidos.llamarTlF2();
            //AQUIIII1
        }
        else if (totalMarcado.Length == 3 && totalMarcado != ("555"))
        {
            Debug.Log("Te has equivocado, macho");
            totalMarcado = null;
        }
        else if (totalMarcado.Length == 3 && totalMarcado == ("555"))
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(2, "Now four...");
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(2, "Ahora un 4...");
                    break;
            }
            auxiliarSonidos.llamarTlF3();
            //AQUIIII1
        }
        else if (totalMarcado.Length == 4 && totalMarcado != ("5554"))
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(3, "Damn, let's start again.", true);
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(3, "Joder, no he marcado el numero correcto", true);
                    break;
            }
            totalMarcado = null;
        }
        else if (totalMarcado.Length == 4 && totalMarcado == ("5554"))
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(4, "Seven...");
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(4, "...7...");
                    break;
            }
            auxiliarSonidos.llamarTlF4();
            //AQUIIII1
        }
        else if (totalMarcado.Length == 5 && totalMarcado != ("55547"))
        {

            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(3, "Forget it, let's start again", true);
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(3, "Olvidalo, volvamos a empezar", true);
                    break;
            }
            totalMarcado = null;
        }
        else if (totalMarcado.Length == 5 && totalMarcado == ("55547"))
        {
            auxiliarSonidos.llamarTlF5();
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(4, "Now...five...");
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(4, "Ahora iba...5...");
                    break;
            }
            //AQUIIII1
        }
        else if (totalMarcado.Length == 6 && totalMarcado != ("555475"))
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(3, "Wrong number, let's do it from the beggining.", true);
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(3, "Me equivoqué de número", true);
                    break;
            }
            totalMarcado = null;
        }
        else if (totalMarcado.Length == 6 && totalMarcado == ("555475"))
        {
            auxiliarSonidos.llamarTlF6();
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(3, "And finally...six...hope they answer...");
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(3, "Y por ultimo 6, espero que esten despiertos aun...");
                    break;
            }
            //AQUIIII1
        }
        else if (totalMarcado.Length == 7 && totalMarcado != ("5554756"))
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(3, "Christ, I got the wrong number...let's do it again.", true);
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(3, "Joder, Habre marcado algun número mal...", true);
                    break;
            }
            totalMarcado = null;
        }
        else if (totalMarcado.Length >= 8)
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(3, "Christ, I got the wrong number...let's do it again.", true);
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(3, "Joder, Habre marcado algun número mal...", true);
                    break;
            }
            totalMarcado = null;
        }
        else if (totalMarcado == ("5554756")) //si el número marcado es el correcto:
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    managersubtitulos.escribirDurante(3, "Ok, got it", true);
                    break;
                case LanguageManager.Language.Spanish:
                    managersubtitulos.escribirDurante(3, "Bien, está llamando", true);
                    break;
            }
            FindObjectOfType<GameManager>().InterfazTelefono.SetActive(false);
            FindObjectOfType<ClipStorage>().StartCall();
            FindObjectOfType<GameManager>().PuntoInterCajon.SetActive(true);         
            Invoke("apagaLaLuzConDialogos", 28f);
        }

    }

    public void apagaLaLuzConDialogos()
    {
       
        //FindObjectOfType<managersubtitulos>().escribirDurante(3, "Se ha ido la luz?", true);
        //GameObject.Find("AuxiliarSonido2").GetComponent<AuxiliarSonidos>().sonidoPuertaLock();
        FindObjectOfType<GameManager>().DevolverControl();
    }
}
