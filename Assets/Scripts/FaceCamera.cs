using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{

    public Camera cameraToLookAt;

    public float minimumDist;
    public float maximumDist;
    public float minimumDistScale;
    public float maximumDistScale;

    void Start()
    {
        cameraToLookAt = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        transform.LookAt(cameraToLookAt.transform.position);
        transform.Rotate(0, 180, 0);
    }
}