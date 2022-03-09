using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixAnimacionFIlesMenu : MonoBehaviour {

    // Use this for initialization
   
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CerrarFiles()
    {
        if (GameObject.Find("MenuFiles") && GameObject.Find("CerrarNotes") && GameObject.Find("CerrarCasetes"))
        {
            GameObject.Find("MenuFiles").GetComponent<Animator>().Play("CerrarFiles");
            GameObject.Find("Menu Notes").GetComponent<Animator>().Play("CerrarNotes");
            GameObject.Find("Menu Casetes").GetComponent<Animator>().Play("CerrarCasetes");
        }
  
    }
}
