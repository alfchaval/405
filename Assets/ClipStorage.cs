using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipStorage : MonoBehaviour {

    public AudioClip[] clips;
    public GameObject partesTelefonoBorrar;
    public AudioClip ring;
    public AudioClip clipsPuzzle;
    public AudioClip[] clipsFinal;
    public GameManager gameManager;
    public bool isOn;

    public void StartCall()
    {
        if (!isOn)
        {
            isOn = true;
            StartCoroutine(AnswerPhone());
            gameManager.QuitarControl();
        }

        else
        {
            Debug.Log("No puedes volver a usar el teléfono, ya estás usándolo");
        }
        
    }

    IEnumerator AnswerPhone()
    {
     
        FindObjectOfType<GameManager>().objetoSoundtrack.GetComponent<AuxiliarSonidos>().FadeOut();
        partesTelefonoBorrar = GameObject.Find("PartesBorrables");
        partesTelefonoBorrar.SetActive(false);
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().loop = false;
        if (gameManager.estadoJuego < 3 )
        {
            FindObjectOfType<AuxiliarSonidos>().FadeOut();
            gameManager.Telephone_splitted.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false; 
            FindObjectOfType<AuxiliarSonidos>().GetComponent<AuxiliarSonidos>().vozHolaQuienEs();
            GetComponent<AudioSource>().clip = clips[0];
            Invoke("InvokableTextAux", GetComponent<AudioSource>().clip.length);
            //GameObject.Find("AudioSource MaryCry").GetComponent<AudioSource>().Stop(); //innecesario
            gameManager.Telephone_splitted.GetComponent<AudioSource>().Stop();
        }
        if (gameManager.estadoJuego == 3)
        {
            FindObjectOfType<AuxiliarSonidos>().GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = clips[2];
        }
        if (gameManager.estadoJuego == 6)
        {
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    GetComponent<AudioSource>().clip = clipsFinal[1];
                    break;
                case LanguageManager.Language.Spanish:
                    GetComponent<AudioSource>().clip = clipsFinal[0];
                    break;
            }
           

            FindObjectOfType<AuxiliarSonidos>().GetComponent<AuxiliarSonidos>().callBromas();
          
        }

        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length); //Cuando la llamada termine liberamos

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = clipsPuzzle; //Cuelga el teléfono
        GetComponent<AudioSource>().Play();
        //Colgamos el teléfono, debería sonar!

        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = clips[1]; //Cuelga el teléfono
        GetComponent<AudioSource>().Play();
        //Colgamos el teléfono, debería sonar!

        if (gameManager.estadoJuego == 6)
        {
            FindObjectOfType<InteracionConObjetosRayCast>().grabadora.GetComponent<Grabadora>().finalDeJuego();
        }
        partesTelefonoBorrar.SetActive(true);
        gameManager.Telephone_splitted.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
     



        if (gameManager.estadoJuego == 3)
        {
            gameManager.DevolverControl();
            GameObject.Find("PuntoInteraccionSellar").GetComponent<PuntoInteraccion>().numeroInteraccion = 5;
            FindObjectOfType<AuxiliarSonidos>().vozSusCosas();
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    FindObjectOfType<managersubtitulos>().escribirDurante(5, "Maybe she hasn’t made it in yet...She must’ve done a runner while I was asleep...");
                    break;
                case LanguageManager.Language.Spanish:
                   // FindObjectOfType<managersubtitulos>().escribirDurante(2, "¿Qué ha sido eso?");
                    break;
            }
            Invoke("InvokeLucesFuera", 6f);
        }

        else if (gameManager.estadoJuego == 1)
        {
            gameManager.CambiarEstado(2);
            FindObjectOfType<GameManager>().objetoSoundtrack.GetComponent<AudioSource>().Stop();
            FindObjectOfType<AuxiliarSonidos>().vozJohnNoEntiendo();
            Invoke("InvokeChirrido", 4);
        
        }
       
        isOn = false;

    }

    public void InvokableTextAux()
    {
        FindObjectOfType<managersubtitulos>().escribirDurante(4, "Someone's gone and chopped the cord...");
        FindObjectOfType<AuxiliarSonidos>().vozJohn_Chord();
    }

    public void InvokeLucesFuera()
    {
        gameManager.HabitacionNormal.SetActive(false);
        gameManager.HabitacionDestrozada.SetActive(true);
        gameManager.luzDormitorio.SetActive(false);
        GameObject.Find("AuxiliarSonido2").GetComponent<AuxiliarSonidos>().alboroto();
        //FindObjectOfType<AuxiliarSonidos>().GetComponent<AuxiliarSonidos>().vozJohnLuz();//esto se come al otro dialogo
    }
    public void InvokeChirrido()
    {
        FindObjectOfType<AuxiliarSonidos>().GetComponent<AuxiliarSonidos>().sonidoPuertaChirrido();
    }

}
