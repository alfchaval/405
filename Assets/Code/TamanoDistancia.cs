using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamanoDistancia : MonoBehaviour {

	public float distanciaMinima = 0.001f;
	public float distanciaMaxima = 5f;
	public float TamanoMinimo = -0.1f;
	public float TamanoMaximo = 5f;

	void Update () {
		//float distancia = Vector3.Distance (transform.position, GameObject.Find ("PLayer").transform.position);
		//float tamano;
		//if (distancia > distanciaMaxima) {
		//	tamano = TamanoMaximo;
		//} else if (distancia < distanciaMinima) {
		//	tamano = TamanoMinimo;
		//} else {
		//	tamano = ((distancia - distanciaMinima) / (distanciaMaxima - distanciaMinima)) * (TamanoMaximo - TamanoMinimo) + TamanoMinimo;
		//}
		////Debug.Log (distancia + " || " + tamano);
		//transform.localScale = new Vector3 (tamano, tamano, tamano);
	}
}
