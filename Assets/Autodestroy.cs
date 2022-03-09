using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroy : MonoBehaviour {

	void Awake () {
        Invoke("destroyThis", 10f);
	}

    private void destroyThis() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "suelo") {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
            gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.Rotate(new Vector3(90f, 0f, 0f));
        }
    }
}
