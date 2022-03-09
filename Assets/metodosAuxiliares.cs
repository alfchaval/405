using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metodosAuxiliares : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void escribirAux()
    {
        FindObjectOfType<managersubtitulos>().escribirDurante(5,"¿Que hace aquí la manecilla del reloj?", true);

        //ahora deberia salir el punto de interacion de recoger la manecilla del reloj, y que esto active que al selecionar el reloj se pueda manejar
    }
}
