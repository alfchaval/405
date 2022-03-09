using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {

    public GameObject cameraCine;

	// Use this for initialization
	void Start () {
        Invoke("InvokeFinLoading", 4f);
	}
	
    public void InvokeFinLoading()
    {
        cameraCine.SetActive(true);
        gameObject.SetActive(false);
        
    }
}
