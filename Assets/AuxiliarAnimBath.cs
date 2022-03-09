using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuxiliarAnimBath : MonoBehaviour {

    public AuxiliarSonidos auxSonidos;
    public InteracionConObjetosRayCast refInteracionConObjetosRaycast;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CallAguaPipe()
    {
        auxSonidos.sonidoWaterPipe();
    }
    public void CallAguaGrifo()
    {
        auxSonidos.sonidoLlenarBath();
    }

    public void CortarSonidoAgua()
    {
        auxSonidos.PararAltavoces();
    }

    public void LlamarAInteractuar23()
    {
        refInteracionConObjetosRaycast.Llamarfuncion23Manual();
    }
}
