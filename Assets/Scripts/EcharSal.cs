using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcharSal : MonoBehaviour {

    public bool echandoSal = false;
    public GameObject sal;
	
	void Update () {
        if (echandoSal) {
            gameObject.GetComponent<Animator>().SetBool("EchaSal", true);
            Invoke("SalCae", 0.5f);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("EchaSal", false);
        }
    }

    public void Salinizar() {
        echandoSal = !echandoSal;
    }

    public void SalCae() {
        GameObject grano = Instantiate(sal, gameObject.transform);
        grano.transform.localPosition = new Vector3(0, 1, 0);
        grano.transform.parent = null;
    }
}
