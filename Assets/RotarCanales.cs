using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarCanales : MonoBehaviour {

    float rotacionInicial;
    Vector2 vectorInicial;
    Vector2 vectorActual;

    double anguloInicial;
    double anguloActual;

    float rotacion;
    bool pulsado = false;

    public int canalActual = 0;

    private float[] canales;
    public int canalSolucion = 4;

    public GameObject nieveTurquesa;
    public GameObject nieveGris;

    public RotarSintonizacionCanales rotarSintonizacionCanales;

    void Start()
    {
        //rotacionInicial = canales[canalActual];
        transform.eulerAngles = new Vector3(0, 0, rotacionInicial);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 raycast = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(raycast, Input.mousePosition);
            Debug.DrawRay(raycast, Input.mousePosition, Color.red, 1);
            if (raycastHit.collider && raycastHit.collider.name == "Dial")
            {
                rotacionInicial = transform.eulerAngles.z;
                vectorInicial = Input.mousePosition - transform.position;
                anguloInicial = CalcularAngulo(vectorInicial);
                pulsado = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            pulsado = false;
            if (PosicionCorrecta() && rotarSintonizacionCanales.PosicionCorrecta())
            {
                rotarSintonizacionCanales.EstaEnSintonizaciónCorrecto();
                transform.parent.gameObject.SetActive(false);
            }
        }

        else if (pulsado)
        {
            Vector2 raycast = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(raycast, Input.mousePosition);
            //if (raycastHit.collider && raycastHit.collider.name == "Canales")
            {
                vectorActual = Input.mousePosition - transform.position;
                anguloActual = CalcularAngulo(vectorActual);
                transform.eulerAngles = new Vector3(0, 0, (float)(rotacionInicial + anguloActual - anguloInicial));
                //CambiarCanal((float)(rotacionInicial + anguloActual - anguloInicial));
            }
        }
    }

    public bool PosicionCorrecta()
    {
        return canalSolucion == canalActual;
    }

    private void CambiarCanal(float rotacion)
    {
        canalActual = CanalCercano(rotacion);
        transform.eulerAngles = new Vector3(0, 0, canales[canalActual]);
        if (canalActual == canalSolucion)
        {
            nieveTurquesa.SetActive(true);
            nieveGris.SetActive(false);
            FindObjectOfType<AuxiliarSonidos>().GetComponent<AuxiliarSonidos>().sonidoDialTv();
        }
        else
        {
            nieveTurquesa.SetActive(false);
            nieveGris.SetActive(true);
            FindObjectOfType<AuxiliarSonidos>().GetComponent<AuxiliarSonidos>().sonidoDialTv();
        }
       
    }

    private int CanalCercano(float rotacion)
    {
        float distancia;
        int canal = 0;
        float cercano = Distancia(canales[0], rotacion);
        for (int i = 1; i < canales.Length; i++)
        {
            distancia = Distancia(canales[i], rotacion);
            if (distancia < cercano)
            {
                cercano = distancia;
                canal = i;
            }
        }
        return canal;
    }

    private float Distancia(float rotacion1, float rotacion2)
    {
        float distancia = Math.Abs(rotacion1 - rotacion2);
        return Math.Min(distancia, 360 - distancia);
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Canal"))
        {
            int.TryParse(collision.name.Substring(6, collision.name.Length - 6), out canalActual);
            if (canalActual == canalSolucion)
            {
                nieveTurquesa.SetActive(true);
                nieveGris.SetActive(false);
            }
            else
            {
                nieveTurquesa.SetActive(false);
                nieveGris.SetActive(true);
            }
            FindObjectOfType<AuxiliarSonidos>().sonidoDialTv();
        }
    }
}