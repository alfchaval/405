using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastAuxliar : MonoBehaviour
{
    public GameObject cameraCineParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TriggerAnimationFinal()
    {
        cameraCineParent.SetActive(true);
        FindObjectOfType<gestorCamaraCine>().ApagarCamaraJugador();
        cameraCineParent.GetComponent<Animator>().Play("PuertaFinDeJuegoMeter debajo de la puerta");
    }
}
