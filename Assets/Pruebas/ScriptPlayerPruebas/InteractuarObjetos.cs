using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractuarObjetos : MonoBehaviour {

    
    public GameObject puntoInteraztuador;
    public float distancia;
    public string ditanciaString;
    public Transform prueba;

    
    public GameObject puerta;
    public GameObject informacionObjeto;
    public string nombreObjeto;
    public string funcionObjeto;
    public Text nombreObjetoText;
    public Text funcionObjetoText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //distancia = Vector3.Distance(prueba.position, transform.position);
        InteracionObjetos();

    }

    public void InteracionObjetos()
    {
        var up = transform.TransformDirection(Vector3.up);
        var ray = transform.TransformDirection(new Vector3(0, 0, 3));
        RaycastHit hit;
        Debug.DrawRay(transform.position, /*-up*/ ray, Color.blue);

        if (Physics.Raycast(transform.position, /*-up*/ ray, out hit, 3))
        {

            Debug.Log("HIT");

            if (hit.collider.gameObject.name == "puerta")
            {
                puerta.SetActive(false);
            }
            if (hit.collider.gameObject.CompareTag("ObjetoInteractuable"))
            {
                informacionObjeto = hit.collider.gameObject;
                nombreObjeto = hit.collider.GetComponent<Text>().text;
                funcionObjeto = hit.collider.GetComponent<Text>().text;
            }
        }
    }
}
