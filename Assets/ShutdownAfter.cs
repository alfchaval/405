using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutdownAfter : MonoBehaviour {
 
    public bool ShowedVater;
    public AudioSource audiosourceLocked;
    public bool sangreTriggerMostrada;
    public GameObject sangreVete;

    public void EncenderAnimObjeto()
    {   
        CancelInvoke();
        GetComponent<Animator>().SetBool("EnciendeSangre", true);
    }

    public void Shutdown()
    {
        CancelInvoke();
        Invoke("AnimationExit", 0.1f);
    }
     
    public void AnimationExit()
    {
        GetComponent<Animator>().SetBool("EnciendeSangre", false);
    }

    public void CambiarEstadoAuxHabitacionDestrozada()// se llama desde la animacion bloodfadeout con efecto
    {
        if (!sangreTriggerMostrada)
        {
            FindObjectOfType<AuxiliarSonidos>().FadeOut();
            audiosourceLocked.Play();      
            GameObject.Find("PuntoInteraccionSellar").GetComponent<PuntoInteraccion>().numeroInteraccion = 0;
            GameObject.Find("AuxiliarSonido1").GetComponent<AuxiliarSonidos>().sonidoPuertaUnlock();
            sangreVete.SetActive(true);
            GameObject.Find("SangreEchaUnVistazo").SetActive(false);
            sangreTriggerMostrada = true;
            //Sonido john se asusta sorprendido o algo asi
        }
    }

    public void ResolverPuzzleBaneraCortina()
    {
        GameObject.Find("AnimacionPuzzleBanera").GetComponent<Animator>().Play("puzleBanera");
        //PrepararPlayer();                     WIP  Scriptar momento bañera, por alguna razon algo bloquea la rotacion de la camara
    }
    public void PrepararPlayer()
    {
        FindObjectOfType<MyPlayer>().transform.GetChild(0).GetComponent<FuncionesAuxiliaresGrabadora>().LiberarCamara();
        FindObjectOfType<GameManager>().QuitarControlConGrabadora();
        FindObjectOfType<MyPlayer>().transform.position = new Vector3(-4.5f, 0.42f, -7.7f);
        FindObjectOfType<MyPlayer>().transform.GetChild(0).GetComponent<Animator>().Play("Movimientobaneralinterna");
    }
    public void encenderVater()
    {

        if (!ShowedVater)
        {
            FindObjectOfType<GameManager>().InterVater.SetActive(true);
            ShowedVater = true;
        }
    }
}
