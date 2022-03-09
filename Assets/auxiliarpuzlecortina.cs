using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auxiliarpuzlecortina : MonoBehaviour {

    public puzzleCortina refPuzlecortina;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            refPuzlecortina.HaAbiertoCortina();
        }
    }
}
