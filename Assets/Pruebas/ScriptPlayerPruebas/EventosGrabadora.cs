using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosGrabadora : MonoBehaviour {

    public GameObject grabadora;
    bool grabadoraOn;


    public void OnTriggerStay(Collider enter)
    {

        if (enter == enter.gameObject.CompareTag("eventoGrabadora") && grabadoraOn)
        {
            grabadora.GetComponent<AudioSource>().clip = enter.GetComponent<InfoItem>().clipItem;
        }


    }

    public void ToggleRecord()
    {
        grabadoraOn = true;
        Invoke("RecordOff", 1);
    }
    public void RecordOff()
    {
 
        grabadoraOn = false;
    }

    public void CleanRecord()
    {
        grabadora.GetComponent<AudioSource>().clip = null;
    }
}
