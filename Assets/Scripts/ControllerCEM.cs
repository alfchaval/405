using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCEM : MonoBehaviour {


    public bool insidePerimeter;//Registra si estamos dentro del área de influence de un campo electromagnético
    public Transform epicenter; //El epicentro, este debe ser el punto central del campo electromagnético
    public Material capsuleCEM; //Material de la capsula para cambiarle el color posteriormente
    public AudioSource sourceCEM; //AudioSource del detector

    public float minDist = 1.5f;
    public float maxDist = 6f;
    public float closePitch = 1.5f;
    public float farPitch = 0.75f;



    // Use this for initialization
    void Start () {

        capsuleCEM = GetComponent<Renderer>().material; //Asigna el material de la capsula
    }
	
	// Update is called once per frame

	void Update () {

        #region Dist/Pitch 

        //Recoge la distancia entre el epicenter y el transform del CEM y varía el pitch del sourceCEM en función de esta distancia.

        float dist = Vector3.Distance(epicenter.position, transform.position);
        print("Distance to other: " + dist);
        float x = Mathf.Clamp(dist, 1.5f, 4.5f);
        float pitch = (farPitch - closePitch) * (x - minDist) / (maxDist - minDist) + closePitch;
        sourceCEM.pitch = pitch;
        #endregion

        //Dependiendo de la distancia, vamos a asignar un color u otro al capsuleCEM y a enceder/apagar el sourceCEM

        if (dist > 6) 
        {
            insidePerimeter = false;
            if (sourceCEM.enabled)
            {
                sourceCEM.enabled = false;
            }
            capsuleCEM.color = Color.gray;
        }

        if (dist <= 6 && dist > 3)
        {
            
            if (!insidePerimeter)
            {
                insidePerimeter = true;
            }
            if (!sourceCEM.enabled)
            {
                sourceCEM.enabled = true;
            }
            capsuleCEM.color = Color.green;
            print("cambia a verde");
        }

        if (dist <= 3 && dist > 1)
        {
            if (!insidePerimeter)
            {
                insidePerimeter = true;
            }
            if (!sourceCEM.enabled)
            {
                sourceCEM.enabled = true;
            }

         
            capsuleCEM.color = Color.yellow;
            print("cambia a amarillo");
        }

        if (dist < 1)
        {
            if (!insidePerimeter)
            {
                insidePerimeter = true;
            }
            if (!sourceCEM.enabled)
            {
                sourceCEM.enabled = true;
            }


       
            capsuleCEM.color = Color.red;
            print("cambia a rojo");
        }

    }

}
