using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotarReloj : MonoBehaviour
{

    float rotacionInicial;
    Vector2 vectorInicial;
    Vector2 vectorActual;

    float rotacion;
    bool pulsado = false;
    public bool manecilla1;

    void FixedUpdate()
    {    
            Debug.Log("pulsado:" + pulsado);
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 raycast = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D raycastHit = Physics2D.Raycast(raycast, Input.mousePosition);
                if (raycastHit.collider && raycastHit.collider.name == "ManecillaReloj1")
                {
                    rotacionInicial = transform.eulerAngles.z;
                    vectorInicial = Input.mousePosition - transform.position;
                    pulsado = true;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                pulsado = false;

            }
            else if (pulsado)
            {
                Vector2 raycast = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D raycastHit = Physics2D.Raycast(raycast, Input.mousePosition);
                if (raycastHit.collider && raycastHit.collider.name == "ManecillaReloj1")
                {
                    Debug.Log(rotacionInicial);
                    vectorActual = Input.mousePosition - transform.position;
                    transform.eulerAngles = new Vector3(0, 0, (float)(rotacionInicial + CalcularAngulo(vectorActual) - CalcularAngulo(vectorInicial)));
                }
            }

        
       
       
    }

    //Math.Atan es así de gracioso que te da el resultado en radianes
    private double CalcularAngulo(Vector2 vectorA)
    {
        if (vectorA.x >= 0 && vectorA.y >= 0)
        {
            return (Math.Atan(vectorA.y / vectorA.x)) * (180 / Math.PI);
        }
        else if (vectorA.x >= 0 && vectorA.y < 0)
        {
            return 360 - (Math.Atan(-vectorA.y / vectorA.x)) * (180 / Math.PI);
        }
        else if (vectorA.x < 0 && vectorA.y >= 0)
        {
            return 180 - (Math.Atan(-vectorA.y / vectorA.x)) * (180 / Math.PI);
        }
        else
        {
            return 180 + (Math.Atan(vectorA.y / vectorA.x)) * (180 / Math.PI);
        }
    }

}