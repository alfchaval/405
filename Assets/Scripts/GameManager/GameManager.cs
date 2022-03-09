using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public GameObject camaraCine;
    //Esta clase debe de recoger todos los puntos de interacción, que serán alterados durante la partida.
    public List<GameObject> listaPuntosInteraccion = new List<GameObject>();
    public List<GameObject> paquetesEventos = new List<GameObject>();

    public bool inventarioMostrado;
    public bool habitacionDestrozadaMostrada;

    public LuzUltraVioleta instanceUV;

    public Color colorTVOn;
    public Color colorTVOff;
    public GameObject luzTV;
    public InventoryManager inventoryM;
    public int estadoJuego;
    public SoundManager soundManger;
    public GameObject colliderAux;

    public GameObject objetoSoundtrack;
    public GameObject touchField;
    public GameObject fixedJoistick;
    public GameObject panelGrabadora;
    public GameObject Inventario;
    public GameObject InterfazTelefono;
    public GameObject InterfazReloj;
    public GameObject InterfazTV;
    public GameObject RelojObjeto;
    public GameObject MenuFiles;
    public GameObject luzDormitorio;
    public GameObject lamparadormitorioturnoff;
    public GameObject borrarVater;
    public GameObject borrarJoyero;
    public GameObject TvPantalla;
    public GameObject TvPantallaInterfaz;

    public AudioSource PuertaAbriendo;
    public VideoClip VideoCarretera;


    public GameObject HabitacionNormal;
    public GameObject HabitacionDestrozada;

    public GameObject luz;
    public AudioSource tvSource;

    public GameObject PuntoInterVater;
    public GameObject PuntoInterGrabadora;
    public GameObject InterVater;
    public GameObject PuntoInterCortina;
    public GameObject PuntoInterCajon;
    public GameObject PuntoInterCuchillo;
    public GameObject PuntoInterAzulejo;
    public GameObject PaquetePadreBath;
    public GameObject PuntoInterManecillaPick;
    public GameObject PuntoInterManecillaUse;
    public GameObject PuntoInterTelefono1;
    public GameObject PuntoInterTV;
    public GameObject interacionpuertabanioPorfuera;
    public GameObject puertaPuzleBano;
    public GameObject notaArrancadaDiarioMary1;
    public GameObject notaArrancadaDiarioMary2;
    public GameObject PuntoInterArmarioPuerta;
    public GameObject triggerPuertaCocina;
    public GameObject cameraRocio;
    public GameObject recorderOfficeTable;
    public GameObject Telephone_splitted;
    public GameObject newInventory;
    public bool despachoUsado; //entrando en despacho
    public bool despachoCompletado; //nada más que hacer ahí, adiós.
    //  public bool muebleBathExaminado;

    /* Estado 0 = Inicio del juego
     * Estado 1 =
     * Estado 2 =
     * Estado 3 =
     * Estado 4 =
     * Estado 5 =
     * Estado 6 =
     * Estado 7 =
     * Estado 8 = Final. Todo apagado menos televisión y sillón. Interacción con televisor para Carretera Perdida
     */

    //Evento 1 Check Habitaciones
    public int habitacionesVisitadas;
    public GameObject whyskyGlassAnim;
    public GameObject knifeColliderTrigger;
    public GameObject trueFinalphoneInteractiveSpot;
    public GameObject doorFinalInteractiveSpot;
    public GameObject finalNote;
    public GameObject sangreCompletado;
    public GameObject puntoInteraccionTelefonoConNota;
    public void QuitarControl()
    {
        fixedJoistick.GetComponent<FixedJoystick>().Disable();
        touchField.GetComponent<FixedTouchField>().lockedRotation = true;
        touchField.GetComponent<FixedTouchField>().TouchDist = new Vector2(0, 0);
        touchField.GetComponent<FixedTouchField>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;

        touchField.SetActive(false);
        fixedJoistick.SetActive(false);
        //panelGrabadora.GetComponent<Animator>().Play("ToggleRecorderOut");
        FindObjectOfType<InventoryManager>().CloseInventory();

        inventoryM.desequiparTodo();
    }

    public void DevolverControl()
    {
        if (!cameraRocio.activeSelf)
        {    
        if (despachoUsado)
        {
            if (despachoCompletado)
            {
                //fixedJoistick.transform.GetChild(0).GetComponent<RectTransform>().position = new Vector3(1,-1,0);
                fixedJoistick.transform.GetChild(0).GetComponent<RectTransform>().right = new Vector2(0, 0);
                touchField.GetComponent<FixedTouchField>().lockedRotation = false;
                touchField.GetComponent<FixedTouchField>().enabled = true;

                touchField.SetActive(true);
                fixedJoistick.SetActive(true);
                fixedJoistick.GetComponent<FixedJoystick>().background.GetComponent<Image>().color = fixedJoistick.GetComponent<FixedJoystick>().backgroundColor;
                fixedJoistick.GetComponent<FixedJoystick>().handle.GetComponent<Image>().color = fixedJoistick.GetComponent<FixedJoystick>().backgroundColor;
                // panelGrabadora.SetActive(true);
                if (inventarioMostrado)
                {
                    Inventario.SetActive(true);
                }


                Invoke("AuxiliarAPagarKinematic", 2);//cucada de espero que toquen antes de 2 segundos el mando   
            }
            else
            {
                print("No le devolvemos el control, todavía está trasteando el despacho");
            }
                
        }
        else
        {
            //fixedJoistick.transform.GetChild(0).GetComponent<RectTransform>().position = new Vector3(1,-1,0);
            fixedJoistick.transform.GetChild(0).GetComponent<RectTransform>().right = new Vector2(0, 0);
            touchField.GetComponent<FixedTouchField>().lockedRotation = false;
            touchField.GetComponent<FixedTouchField>().enabled = true;

            touchField.SetActive(true);
            fixedJoistick.SetActive(true);
            fixedJoistick.GetComponent<FixedJoystick>().background.GetComponent<Image>().color = fixedJoistick.GetComponent<FixedJoystick>().backgroundColor;
            fixedJoistick.GetComponent<FixedJoystick>().handle.GetComponent<Image>().color = fixedJoistick.GetComponent<FixedJoystick>().backgroundColor;
            // panelGrabadora.SetActive(true);
            if (inventarioMostrado)
            {
                Inventario.SetActive(true);
            }


            Invoke("AuxiliarAPagarKinematic", 2);//cucada de espero que toquen antes de 2 segundos el mando   
        }
        }
    }

    public void QuitarControlConGrabadora()
   {
       fixedJoistick.GetComponent<FixedJoystick>().Disable();
       touchField.GetComponent<FixedTouchField>().lockedRotation = true;
       touchField.GetComponent<FixedTouchField>().TouchDist = new Vector2(0, 0);
       touchField.GetComponent<FixedTouchField>().enabled = false;
       GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
        panelGrabadora.GetComponent<Animator>().Play("ToggleRecorderOut");
        touchField.SetActive(false);
       fixedJoistick.SetActive(false);
       Inventario.SetActive(false);
   }


   public void DevolverControlConGrabadora()
   {
       //fixedJoistick.transform.GetChild(0).GetComponent<RectTransform>().position = new Vector3(1,-1,0);
       fixedJoistick.transform.GetChild(0).GetComponent<RectTransform>().right = new Vector2(0, 0);
       touchField.GetComponent<FixedTouchField>().lockedRotation = false;
       touchField.GetComponent<FixedTouchField>().enabled = true;
       touchField.SetActive(true);
       fixedJoistick.SetActive(true);
        panelGrabadora.SetActive(true);
        fixedJoistick.GetComponent<FixedJoystick>().background.GetComponent<Image>().color = fixedJoistick.GetComponent<FixedJoystick>().backgroundColor;
        fixedJoistick.GetComponent<FixedJoystick>().handle.GetComponent<Image>().color = fixedJoistick.GetComponent<FixedJoystick>().backgroundColor;

        if (inventarioMostrado)
       {
           Inventario.SetActive(true);
       }

       Invoke("AuxiliarAPagarKinematic", 2);//cucada de espero que toquen antes de 2 segundos el mando
   }

    public void QuitarControlFinal()
    {
        fixedJoistick.GetComponent<FixedJoystick>().Disable();
        fixedJoistick.SetActive(false);
        Inventario.SetActive(false);
    }

    public void AuxiliarAPagarKinematic()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = false;
    }

    public void Start()
    {
        soundManger = gameObject.GetComponent<SoundManager>();
        PuntoInterVater.SetActive(false);
        HabitacionDestrozada.SetActive(false);
        PuntoInterTelefono1.SetActive(false);
        GameObject.Find("PuntoInteraccion ExamReloj");
        foreach (var item in GameObject.FindGameObjectsWithTag("Paquete"))
        {
            paquetesEventos.Add(item.gameObject);
            print(item.gameObject.name);
        }
      
        FixEstado();
        GetComponent<AuxiliarSonidos>().ostEscena1Tema1();
        //EncenderTV();
    }


    public void CambiarEstado(int numCambio) //Interactuar() llama a este método para cambiar el estado de juego cuando sea necesario
    {
        estadoJuego = numCambio;
        FixEstado();
    }

    public void FixEstado()
    {
        switch (estadoJuego)
        {
            case 0: //Este case es el principio del juego. Aprovecharemos para apagar todos los objetos (Empiezan encendidos para que la lista los recoja)

                for (int i = 0; i < paquetesEventos.Count; i++)
                {
                    if (paquetesEventos[i])
                    {
                        paquetesEventos[i].SetActive(false);
                    }

                    if (paquetesEventos[i].name.Equals("Paquete 0"))
                    {
                        paquetesEventos[i].SetActive(true);
                    }
                }
                break;

            case 1: //Estado 1, suena el portazo del baño
                Debug.Log("El jugador ha pasado por todas las habitaciones, cambiamos a estado 1");
                //Sonido portazo
                for (int i = 0; i < paquetesEventos.Count; i++)
                {
                    if (paquetesEventos[i].name.Equals("Paquete 0"))
                    {
                        paquetesEventos[i].SetActive(false);
                    }

                    if (paquetesEventos[i].name.Equals("Paquete 1"))
                    {
                        paquetesEventos[i].SetActive(true);
                    }

                }
                break;

            case 2: //Después del teléfono se abre la puerta de baño
                Debug.Log("Contestamos al teléfono, cambiamos a estado 2");
               

                for (int i = 0; i < paquetesEventos.Count; i++)
                {
             
                    if (paquetesEventos[i].name.Equals("Paquete 1"))
                    {
                        paquetesEventos[i].SetActive(false);
                    }

                    if (paquetesEventos[i].name.Equals("Paquete 2"))
                    {
                        paquetesEventos[i].SetActive(true);
                    }
                    

                }
             
                notaArrancadaDiarioMary1.transform.parent = null;
                PuntoInterArmarioPuerta.transform.parent = null;


                GameObject.Find("puertaParaLuis (3)").transform.parent = null;
                GameObject.Find("puertaParaLuis (3)").GetComponentInChildren<Animator>().SetBool("AbrirPuerta", true);
                GameObject.Find("puertaParaLuis (3)").GetComponentInChildren<AudioSource>().Play();
                print("puerta del baño abierta por mary con un chirrido");
                GameObject.Find("puertaParaLuis (3)").transform.GetChild(4).gameObject.GetComponent<Animator>().SetBool("AbrirPuerta", true);//volvemos a llamarlo porque parece que no está abriendo la puerta
                Invoke("InvokeMary", 9);
              

                break;


            case 3: //Vamos a llamar a la suegra DE MIERDA
                Debug.Log("Hemos leido la nota de Mary, cambiamos a estado 3");
                for (int i = 0; i < paquetesEventos.Count; i++)
                {
                    if (paquetesEventos[i].name.Equals("Paquete 2"))
                    {
                        paquetesEventos[i].SetActive(false);
                    }

                    if (paquetesEventos[i].name.Equals("Paquete 3"))
                    {
                        paquetesEventos[i].SetActive(true);
                    }

                    notaArrancadaDiarioMary2.transform.parent = null;

                }
                break;

            case 4: //movidas azulejiles
                for (int i = 0; i < paquetesEventos.Count; i++)
                {
                    if (paquetesEventos[i].name.Equals("Paquete 3"))
                    {
                        paquetesEventos[i].SetActive(false);
                    }

                    if (paquetesEventos[i].name.Equals("Paquete 4"))
                    {
                        paquetesEventos[i].SetActive(true);
                    }
                   
                }

                GameObject.Find("Kitchen_knifeDestruir").SetActive(false);
                PaquetePadreBath.transform.parent = null;
                GameObject.Find("PadreBathDestruir").SetActive(false);
                PuntoInterCuchillo.SetActive(false);
                PuntoInterAzulejo.SetActive(false);
                PuntoInterManecillaPick.SetActive(false);
                break;

            case 5: //Acabamos de ver la tele, nota bajo la puerta
                 //luzDormitorio.SetActive(true);       ¿queremos que se encienda la luz del dormitorio?
                for (int i = 0; i < paquetesEventos.Count; i++)
                {
                    Debug.Log("Pasamos a 5");
                    if (paquetesEventos[i].name.Equals("Paquete 4"))
                    {
                        paquetesEventos[i].SetActive(false);
                    }

                    if (paquetesEventos[i].name.Equals("Paquete 5"))
                    {
                        paquetesEventos[i].SetActive(true);
                    }
                    //puertaPuzleBano.GetComponentInChildren<PuntoInteraccion>().gameObject.SetActive(true);
                    puertaPuzleBano.transform.GetChild(0).gameObject.SetActive(true);


                }
                break;

            case 6:
                for (int i = 0; i < paquetesEventos.Count; i++)
                {
                    if (paquetesEventos[i].name.Equals("Paquete 5"))
                    {
                        paquetesEventos[i].SetActive(false);
                    }

                    if (paquetesEventos[i].name.Equals("Paquete 6"))
                    {
                        paquetesEventos[i].SetActive(true);
                    }

                }
                break;

            case 7:
                for (int i = 0; i < paquetesEventos.Count; i++)
                {
                    if (paquetesEventos[i].name.Equals("Paquete 6"))
                    {
                        paquetesEventos[i].SetActive(false);
                    }

                    if (paquetesEventos[i].name.Equals("Paquete 7"))
                    {
                        paquetesEventos[i].SetActive(true);
                    }

                }
                break;

            default:
                break;
        }
    }
    public void InvokeTV()
    {
        Invoke("EncenderTV", 5);
     
    }

    public void EncenderTV()
    {
        //objetoSoundtrack.GetComponent<AudioSource>().clip = FindObjectOfType<SoundtrackManager>().Subconsciente;
        //objetoSoundtrack.GetComponent<AudioSource>().Play();
       // TvPantalla.GetComponent<Renderer>().material.color = colorTVOn;
        tvSource.Play();
        luz.SetActive(true);
        luzTV.SetActive(true);
        PuntoInterTV.SetActive(true);
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                FindObjectOfType<managersubtitulos>().escribirDurante(6, "Is that the TV?", true);
                break;
            case LanguageManager.Language.Spanish:
                FindObjectOfType<managersubtitulos>().escribirDurante(6, "¿Se ha encendido la televisión?", true);
                break;
        }
        GameObject.Find("Vintage_tv06").GetComponent<AudioSource>().Play();
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("accion"))
        {
            if (item.GetComponent<Animator>())
            {
                item.GetComponent<Animator>().SetBool("AbrirPuerta", true);
            }
        }
        //FindObjectOfType<GameManager>().DevolverControl();
        //GameObject.Find("Manecilla De reloj 2").GetComponent<MeshRenderer>().enabled = true;
        //FindObjectOfType<GameManager>().InterfazReloj.SetActive(false);

    }


    public void CallEncenderPuntoVater()
    {
        PuntoInterVater.SetActive(true);
        if (estadoJuego !=2)
        {
            PuntoInterVater.SetActive(false);
        }
    }
    public void InvokeMary()
    {
        FindObjectOfType<AuxiliarSonidos>().vozMary();
      
    }
    public void CambiarVideoTV()
    {
        TvPantalla.GetComponent<VideoPlayer>().clip = VideoCarretera;
        TvPantallaInterfaz.GetComponent<VideoPlayer>().clip = VideoCarretera;
    }

    public void CustomInvoke(string methodName,float time)
    {
        Invoke(methodName, time);
    }
    public void TurnOnInteractionPointTLF()
    {
        puntoInteraccionTelefonoConNota.SetActive(true);
    }
}
