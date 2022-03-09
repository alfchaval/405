using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptAuxiliarTrigeaTexto : MonoBehaviour {

    public string textoAmostrar;
    public int delay;
    public bool mostrado;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {

            if (!mostrado)
            {
                mostrado = true;
                FindObjectOfType<managersubtitulos>().escribirDurante(delay, textoAmostrar);
            }
        }
      
    }
}
