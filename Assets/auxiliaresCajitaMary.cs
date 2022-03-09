using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auxiliaresCajitaMary : MonoBehaviour {

    public GameObject puntoInterExaminarCajita;
    public GameObject puntoInterPhone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EncenderInteracionHijo()
    {
        //GetComponent<Animator>().Play("CajitaMarySale");
        GameObject.Find("puertaParaLuis (5)").GetComponentInChildren<Animator>().SetBool("AbrirPuerta", false);
        puntoInterExaminarCajita.SetActive(true);
        puntoInterPhone.SetActive(true);
    }
}
