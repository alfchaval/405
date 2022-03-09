using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorBotonDialTV : MonoBehaviour {

    public GameObject botonMirror;
    public bool haciendoMirror;

	void Start ()
    {
        print(transform.eulerAngles);
        InvokeRepeating("updateRotationChanel", 0.1f, 0.2f);
    }

    public void updateRotationChanel()
    {
        transform.eulerAngles = new Vector3(0, 0, botonMirror.transform.eulerAngles.z);
    }
}
