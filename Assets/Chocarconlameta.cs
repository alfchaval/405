using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocarconlameta : MonoBehaviour {


    public GameObject mochiladeobjeto;

    public Material material;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Renderer>().material = material;
    }

}
