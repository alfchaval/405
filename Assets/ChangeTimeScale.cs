using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTimeScale : MonoBehaviour
{
    public float wantedSpeed = 1;
    public bool changeSpeed;
    void Update()
    {
        if (changeSpeed)
        {
            changeSpeed = false;
            Time.timeScale = wantedSpeed;
        }
    }
}
