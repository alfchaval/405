using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escondite : MonoBehaviour {

	public RayAccion accionSc;
	public bool aSalvoAvailable = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ComprobarStado(){
		if(!accionSc.boleano){ //Puerta cerrada
			aSalvoAvailable=true;
		}else{  //PuertaAbierta
			aSalvoAvailable=false;
		}
	}
}
