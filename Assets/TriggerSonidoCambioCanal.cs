using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSonidoCambioCanal : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("SelectorCanal"))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
