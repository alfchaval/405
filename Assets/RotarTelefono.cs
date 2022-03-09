using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotarTelefono : MonoBehaviour
{

    float rotacionInicial;
    Vector2 vectorInicial;
    Vector2 vectorActual;

    double anguloInicial;
    double anguloActual;
    double anguloBoton;
    float speedBackward = 0.01f;
    public bool resetting;
    GameObject botonauxiliar;
    // float rotacion;
    bool pulsado = false;

    int numeroPulsado;
    int numeroMarcado;

    void Start()
    {
        rotacionInicial = transform.eulerAngles.z;
    }

    void Update()
    {
        if (!resetting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                Vector2 raycast = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D raycastHit = Physics2D.Raycast(raycast, Input.mousePosition);
                if (raycastHit.collider && raycastHit.collider.name.Contains("BotonTelefono"))
                {
                     botonauxiliar = raycastHit.collider.gameObject;
                    //CancelInvoke();
                    //   FindObjectOfType<GestorTelefono>().nombreDelBoton = raycastHit.collider.gameObject.name;
                    vectorInicial = Input.mousePosition - transform.position;
                    anguloInicial = CalcularAngulo(vectorInicial);
                    numeroPulsado = 1 + (((int)anguloInicial - 40) / 30);
                    pulsado = true;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                pulsado = false;
                resetting = true;
                if (transform.eulerAngles.z > 5 && transform.eulerAngles.z < 350)
                {
                    numeroMarcado = (10 - (((int)transform.eulerAngles.z - 20) / 30));
                    if (numeroMarcado == numeroPulsado)
                    {
                        FindObjectOfType<GestorTelefono>().numeroDelBoton = numeroMarcado.ToString();
                        FindObjectOfType<GestorTelefono>().AddNumber();
                        print(numeroMarcado.ToString());//numero marcado correctamen

                    }
                    else
                    {
                        if (botonauxiliar.gameObject.name.Contains("BotonTelefono"))
                        {
                             FindObjectOfType<GestorTelefono>().numeroDelBoton = botonauxiliar.gameObject.name.Split()[botonauxiliar.gameObject.name.Split().Length - 1].ToString();
                             FindObjectOfType<GestorTelefono>().AddNumber();
                             print("el numero anadido ha sido  "+ botonauxiliar.gameObject.name.Split()[botonauxiliar.gameObject.name.Split().Length - 1]);
                             print(numeroMarcado.ToString()+" este viene del else rehecho");
                        }
                        int azar = UnityEngine.Random.Range(1, 4);
                        if (azar == 1)
                        {
                            switch (FindObjectOfType<LanguageManager>().currentLanguage)
                            {
                                case LanguageManager.Language.English:
                                    FindObjectOfType<managersubtitulos>().escribirDurante(2, "Shit!", true);
                                    break;
                                case LanguageManager.Language.Spanish:
                                    FindObjectOfType<managersubtitulos>().escribirDurante(2, "¡Mierda!", true);
                                    break;
                            }
                  
                        }
                        else if (azar == 2)
                        {
                            print("llamamos a texto auxliar");

                            switch (FindObjectOfType<LanguageManager>().currentLanguage)
                            {
                                case LanguageManager.Language.English:
                                    FindObjectOfType<managersubtitulos>().escribirDurante(2, "Come on, John", true);
                                    break;
                                case LanguageManager.Language.Spanish:
                                    FindObjectOfType<managersubtitulos>().escribirDurante(3, "Tranquilizate no es tan dificil...", true);
                                    break;
                            }

                          
                            CancelInvoke();
                            Invoke("textoAuxiliar", 1);
                        }
                        else if (azar == 3)
                        {
                           
                            switch (FindObjectOfType<LanguageManager>().currentLanguage)
                            {
                                case LanguageManager.Language.English:
                                    FindObjectOfType<managersubtitulos>().escribirDurante(2, "Is this even working?", true);
                                    break;
                                case LanguageManager.Language.Spanish:
                                    FindObjectOfType<managersubtitulos>().escribirDurante(2, "¿Funciona esta cosa?", true);
                                    break;
                            }
                        }
                        else
                        {
                            switch (FindObjectOfType<LanguageManager>().currentLanguage)
                            {
                                case LanguageManager.Language.English:
                                    FindObjectOfType<managersubtitulos>().escribirDurante(4, "Great, now I have to start from the beggining", true);
                                    break;
                                case LanguageManager.Language.Spanish:
                                    FindObjectOfType<managersubtitulos>().escribirDurante(3, "Tranquilizate no es tan dificil...", true);
                                    break;
                            }
                        }
                        FindObjectOfType<GestorTelefono>().totalMarcado = "";
                    }
                }
                InvokeRepeating("ResetearDial", 0, speedBackward);
            }

            else if (pulsado)
            {
                Vector2 raycast = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D raycastHit = Physics2D.Raycast(raycast, Input.mousePosition);
                if (raycastHit.collider && raycastHit.collider.name.Contains("BotonTelefono"))
                {
                    vectorActual = Input.mousePosition - transform.position;
                    anguloActual = CalcularAngulo(vectorActual);
                    if (anguloActual > 350 || anguloActual < anguloInicial)
                    {
                        transform.eulerAngles = new Vector3(0, 0, (float)(rotacionInicial + anguloActual - anguloInicial));
                    }
                }
            }
        }
    }
    public void textoAuxiliar()
    {
        print("texto auxliar ok");
        FindObjectOfType<managersubtitulos>().escribirDurante(3, "Don't you know how phones work?", true);
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

    private void ResetearDial()
    {
        if (Math.Abs(transform.eulerAngles.z - rotacionInicial) < 1)
        {
            CancelInvoke();
            resetting = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 1);
        }
    }
}