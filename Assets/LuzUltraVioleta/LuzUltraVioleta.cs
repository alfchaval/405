using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzUltraVioleta : MonoBehaviour {
  
    //public Camera cam;
    //public GameObject luz;
    //public GameObject Objeto;

	// Use this for initialization
	void Start () {
        //cam.cullingMask = 1 << 0;

        //cam.cullingMask = 1 << 9;
    }

    // Update is called once per frame
    void Update () {

        /*if (Input.GetKey("e"))
        {


            Objeto.layer = 0;
            luz.SetActive(true);
        }
        else
        {
            Objeto.layer = 9;
            luz.SetActive(false);
        }*/

    }

    /*public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Luz")
        {
            cam.cullingMask = 9 << 0;x  
        }
    }*/

    public void OnTriggerEnter(Collider enter)
    {
        if (enter.gameObject.tag == "Luz")
        {
            enter.gameObject.transform.GetChild(0).gameObject.SetActive(true);
           // enter.gameObject.transform.GetChild(0).transform.GetComponent<>
            enter.gameObject.transform.GetChild(0).gameObject.GetComponent<ShutdownAfter>().EncenderAnimObjeto();
        }
    }
    public void OnTriggerExit(Collider exit)
    {

        if (exit.gameObject.tag == "Luz")
        {
            exit.gameObject.transform.GetChild(0).gameObject.GetComponent<ShutdownAfter>().Shutdown();
        }
    }

    public void ApagarTodasLuces ()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Luz").Length; i++)
        {
            //GameObject.FindGameObjectsWithTag("Luz")[i].transform.GetChild(0).gameObject.SetActive(true);
            if (GameObject.FindGameObjectsWithTag("Luz")[i].transform.GetChild(0).GetComponent<Animator>().GetBool("EnciendeSangre"))
            {
                GameObject.FindGameObjectsWithTag("Luz")[i].transform.GetChild(0).GetComponent<ShutdownAfter>().AnimationExit();
            }
        }
    }

  
}
