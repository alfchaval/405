using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteracionConObjetosRayCast : MonoBehaviour
{


    int contadorAux = 0;
    RaycastHit2D hit;
    Vector2[] touches = new Vector2[5];
    public AudioClip clipItem;
    public GameObject objeto;
    public int itemId;
    public Sprite itemIMG;
    public SoundManager soundManager;
    public GameObject grabadora;
    public GameObject cem;
    public GameObject luz;
    public GameObject objetoPickUp;
    private GameObject gameobjectAuxiliarParaAlmacenarHit;
    public GameObject ObjetoSobreElQueActua;
    
    public Animator animBisagra;
    public bool seguroDeAcion;
    public List<GameObject> listaObjetosAux = new List<GameObject>();
    public GameObject[] listaSlotsParaNotas;
    public int numeroLLaveAbrirPuerta;
    public int numeroDeNotasRecogidas;
    public bool seguroInteracion;
    public Text textoSubtitulo;
    public bool PuertaAporreada;
    public bool inventarioMostrado;
    public bool primeraNotaRecogida;
    public GameManager gameManager;
    public int numInterAux;
    public managersubtitulos managerSub;
    public GameObject telefono;
    public GameObject[] slotsCasetes;
    public bool puertaEnUso;
    public GameObject puertaLuisPuzle;
    public GameObject DEBUG;
    public GameObject referenciaDeEmergenciaPuntoInteracion;
    public bool sangreveteSeHaIdo;
    int ignorarPlayer;
    public bool haTerminadoDeMirarOficina;
    public GameObject refCamaraCine;
    public GameObject puntoInteracionASalvar;
    public GameObject puntoInterPeriodico;
    public GameObject puntoInterBlocNotasOficina;
    public GameObject puntoInterGrabadoraOficina;
    public GameObject objetoSangrePasado;
    public GameObject telefonoCocina;
    public GameObject telefonoSinNota;
    public GameObject telefonoConNota;
    public GameObject puntoInterCajonGrabadora;

    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
        managerSub = FindObjectOfType<managersubtitulos>().GetComponent<managersubtitulos>();
    }

    void Update()
    {
        /*if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0 && Input.touchCount < 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    //checkTouch(Input.GetTouch(0).position);
                    checkTouch2(Input.GetTouch(0).position);
                }
            }
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {

                //checkTouch(Input.mousePosition);
                checkTouch2(Input.mousePosition);
            }
        }*/
    }


    private void checkTouch(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Debug.Log("prueba pos" + pos);

        Vector2 touchPos = new Vector2(wp.x, wp.y);
        Collider2D hit = Physics2D.OverlapPoint(touchPos);


        //Debug.Log("oryeba hit" + gameObject.name);

        if (gameObject.CompareTag("objeto"))
        {
            //nombreObjetoText.text = hit.ToString();
            Debug.Log("objetoray");
        }
    }
    public void AbrirCerrojo()
    {
        seguroDeAcion = false;
    }
    public void AbrirPuerta()
    {
        DEBUG.GetComponent<Text>().text += '\n' + "Abriendo";
        print("abrirpuerta de " + ObjetoSobreElQueActua.name + " intenta abrir cerrojo");
        if (!seguroDeAcion)
        {
            DEBUG.GetComponent<Text>().text += '\n' + "Sin seguro";
            if (gameManager.habitacionDestrozadaMostrada && !sangreveteSeHaIdo)
            {
                print("Has visto el maniquí");
                GameObject.Find("Sangre Vete").SetActive(false);
                print("Asi que borra el vete");
                sangreveteSeHaIdo = true;
                puntoInterCajonGrabadora.SetActive(true);
            }

            if (ObjetoSobreElQueActua.transform.parent == objeto.transform.parent)
            {
                DEBUG.GetComponent<Text>().text += '\n' + "ültimo";
                animBisagra = ObjetoSobreElQueActua.GetComponent<Animator>();
                animBisagra.SetBool("AbrirPuerta", true);
                //ObjetoSobreElQueActua.GetComponent<Animator>().SetBool("AbrirPuerta", true);
                print("abrir" + ObjetoSobreElQueActua.name);
                seguroDeAcion = true;
                Invoke("AbrirCerrojo", 0.1f);
            }
        }
        if (animBisagra.GetBool("AbrirPuerta") && gameManager.estadoJuego < 5)
        {
            PuntoInteraccion[] listaAux = objeto.transform.parent.GetComponentsInChildren<PuntoInteraccion>();
            for (int i = 0; i < listaAux.Length; i++)
            {
                listaAux[i].gameObject.SetActive(false);
                referenciaDeEmergenciaPuntoInteracion.SetActive(false);
            }
        }
        else if (animBisagra.GetBool("AbrirPuerta") && gameManager.estadoJuego >= 5)
        {
            PuntoInteraccion[] listaAux = objeto.transform.parent.GetComponentsInChildren<PuntoInteraccion>();
            for (int i = 0; i < listaAux.Length; i++)
            {
                if (gameManager.estadoJuego >= 5)
                {
                    //listaAux[i].gameObject.SetActive(true);
                    listaAux[0].gameObject.SetActive(true);
                    referenciaDeEmergenciaPuntoInteracion.SetActive(false);
                }           
            }
        }
        
    }
  
    public void CerrarPuerta()
    {
        PuntoInteraccion[] listaAux = objeto.transform.parent.GetComponentsInChildren<PuntoInteraccion>();

        listaAux[0].gameObject.SetActive(true);
        referenciaDeEmergenciaPuntoInteracion.SetActive(true);

        print("cerrar puerta  de " + ObjetoSobreElQueActua.name + " intenta abrir cerrojo");
        if (!seguroDeAcion)
        {      
                animBisagra = ObjetoSobreElQueActua.GetComponent<Animator>();
                animBisagra.SetBool("AbrirPuerta", false);
                //ObjetoSobreElQueActua.GetComponent<Animator>().SetBool("AbrirPuerta", false);

                seguroDeAcion = true;
                Invoke("AbrirCerrojo", 0.1f);
           
        }
    }

    public void Interactuar(int numeroInteraccion)
    {
        DEBUG.GetComponent<Text>().text += '\n' + "Interactuando";
        objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = true;
        DEBUG.GetComponent<Text>().text += '\n' + "Puede interactuar";
        DEBUG.GetComponent<Text>().text += '\n' + "Número: " + 0;
        switch (numeroInteraccion)
        {
            case 0:
                if (ObjetoSobreElQueActua.transform.parent == objeto.transform.parent)
                {
                    objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                    if (FindObjectOfType<GameManager>().estadoJuego > 4)
                    {
                        FindObjectOfType<AuxiliarSonidos>().ostEscena6Tema4_2();
                    }
                    puertaEnUso = true;
                    if (ObjetoSobreElQueActua.GetComponent<Animator>().GetBool("AbrirPuerta"))
                    {
                        DEBUG.GetComponent<Text>().text += '\n' + "Abrir puerta";
                        ObjetoSobreElQueActua.GetComponent<AudioSource>().clip = soundManager.sonidoPuertaCerrar[Random.Range(0, 2)];
                        CerrarPuerta();

                        ObjetoSobreElQueActua.GetComponent<AudioSource>().Play();
                        break;
                    }
                    else
                    {
                        DEBUG.GetComponent<Text>().text += '\n' + "No abrir puerta";
                        ObjetoSobreElQueActua.GetComponent<AudioSource>().clip = soundManager.sonidoPuertaAbrir[Random.Range(0,2)];
                        AbrirPuerta();
                        ObjetoSobreElQueActua.GetComponent<AudioSource>().Play();
                        break;
                    }
                   
                }

                break;

            case 1:

                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;

                print("entraEnSwich case 1");
                soundManager.GetComponent<AudioSource>().clip = soundManager.sonidoRecoger;
                soundManager.GetComponent<AudioSource>().Play();


                if (ObjetoSobreElQueActua.tag.Equals("grabadora"))
                {              
                    switch (FindObjectOfType<LanguageManager>().currentLanguage)
                    {
                        case LanguageManager.Language.English:
                            FindObjectOfType<managersubtitulos>().escribirDurante(2, "I got: tape recorder");
                            break;
                        case LanguageManager.Language.Spanish:
                            FindObjectOfType<managersubtitulos>().escribirDurante(2, "Has recogido: Grabadora");
                            break;
                    }

                    FindObjectOfType<InventoryManager>().listaObjetos[1].SetActive(true);

                    GameObject.Find("puertaParaLuis (3)").GetComponentInChildren<Animator>().SetBool("AbrirPuerta", false);


                    grabadora = ObjetoSobreElQueActua;
                    itemId = objetoPickUp.GetComponent<InfoItem>().itemID;
                    itemIMG = objetoPickUp.GetComponent<InfoItem>().itemIMG;
                    GameObject.Find("InventoryManager").GetComponent<InventoryManager>().AddItem(itemId, itemIMG);
                    gameManager.PuntoInterGrabadora.transform.parent.gameObject.SetActive(false);
                    GameObject.Find("InventoryManager").GetComponent<InventoryManager>().llamarGrabadora();

                    //   gameObject.transform.GetChild(0).GetComponent<LuzUltraVioleta>().ApagarTodasLuces(); //la luz es el hijo 0 del player
                    GameObject.Find("GrabadoraDeJugador").GetComponent<Animator>().Play("NewEscucharRecorder");
                    FindObjectOfType<GameManager>().interacionpuertabanioPorfuera.SetActive(false);
                }

                else if (ObjetoSobreElQueActua.tag.Equals("Cem"))
                {
                    itemId = objetoPickUp.GetComponent<InfoItem>().itemID;
                    itemIMG = objetoPickUp.GetComponent<InfoItem>().itemIMG;
                    GameObject.Find("InventoryManager").GetComponent<InventoryManager>().AddItem(itemId, itemIMG);

                }

                else if (ObjetoSobreElQueActua.tag.Equals("LuzUV"))
                {
                    
                    switch (FindObjectOfType<LanguageManager>().currentLanguage)
                    {
                        case LanguageManager.Language.English:
                            FindObjectOfType<managersubtitulos>().escribirDurante(2, "I got: UV Light");
                            break;
                        case LanguageManager.Language.Spanish:
                            FindObjectOfType<managersubtitulos>().escribirDurante(2, "Has recogido: Luz Ulravioleta");
                            break;
                    }
                    //if (!inventarioMostrado)
                    //{
                    //    gameManager.inventarioMostrado = true;
                    //    gameManager.Inventario.SetActive(true);
                    //    inventarioMostrado = true;
                    //}
                    //itemId = objetoPickUp.GetComponent<InfoItem>().itemID;
                    //itemIMG = objetoPickUp.GetComponent<InfoItem>().itemIMG;
                    GameObject.Find("InventoryManager").GetComponent<InventoryManager>().AddItem(1, itemIMG);
                }
                break;

            case 2://examinar objeto
                FindObjectOfType<InventoryManager>().CloseInventory();
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                print("Entra En Swich case 2");

                if (objetoPickUp.tag.Equals("examinable"))
                {
                    print("hemos pasado por el case 2 dentro del objeto examinable " + contadorAux);
                    itemId = objetoPickUp.GetComponent<InfoItem>().itemID;
                    itemIMG = objetoPickUp.GetComponent<InfoItem>().itemIMG;
                    FindObjectOfType<MemoManager>().GetComponent<MemoManager>().PickUpMemo(itemId, itemIMG, objetoPickUp.GetComponent<InfoItem>().textExam);
                    listaSlotsParaNotas[numeroDeNotasRecogidas].GetComponent<FileSlot>().AddFile(itemIMG, objetoPickUp.GetComponent<InfoItem>().textExam, objetoPickUp.GetComponent<InfoItem>().tituloNotaOCinta);
                    numeroDeNotasRecogidas++;
                }  //Aquí tendremos que hacer algo que de feedbak de que se ha guardado la nota
                   //if (gameManager.estadoJuego ==6)
                   //{
                   //    print("se esta examinando la cajita, hay que cambiar los estados y hacer que te llamen");
                   //    for (int i = 0; i < FindObjectsOfType<FileSlot>().Length; i++)
                   //    {
                   //        if (!FindObjectsOfType<FileSlot>()[i].ocupado)
                   //        {
                   //            FindObjectsOfType<FileSlot>()[i].AddFile("Cajita Mary",FindObjectOfType<SoundManager>().cassettePelea);
                   //            print("se ha añadido la nota pelea");
                   //        }
                   //    }
                   //}
                break;

            default:
                print("entraEnSwich Interactuar default");
                break;

            case 3://para la sal cogerla y equiparla
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                break;

            case 4: // cassetes

                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                for (int q = 0; q < GameObject.FindGameObjectsWithTag("SlotCasete").Length; q++)
                {
                    listaObjetosAux.Add(GameObject.FindGameObjectsWithTag("SlotCasete")[q]);
                }


                for (int i = 0; i < listaObjetosAux.Count; i++)
                {
                    print(listaObjetosAux[i].name);

                    if (!listaObjetosAux[i].GetComponent<FileSlot>().ocupado)
                    {
                        if (listaObjetosAux[i].GetComponentInParent<FileSlot>().tag.Equals("SlotCasete"))
                        {
                            listaObjetosAux[i].GetComponentInParent<FileSlot>().AddFile(objetoPickUp.GetComponent<InfoItem>().tituloNotaOCinta, objetoPickUp.GetComponent<InfoItem>().clipItem);
                            print(listaObjetosAux[i].gameObject.name);
                        }
                        break;
                    }
                }
                break;
            case 5: //Puertas Cerradas
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
             //   managerSub.escribirDurante(3, "Está cerrada.", true);
                switch (FindObjectOfType<LanguageManager>().currentLanguage)
                {
                    case LanguageManager.Language.English:
                        FindObjectOfType<managersubtitulos>().escribirDurante(3, "Won't open", true);
                        break;
                    case LanguageManager.Language.Spanish:
                        FindObjectOfType<managersubtitulos>().escribirDurante(3, "Está cerrada", true);
                        break;
                }

                break;

            case 6:// esto es para examinar solo texto
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                textoSubtitulo.text = objetoPickUp.GetComponent<Text>().text;
                Invoke("BorrarTexto", 5);
                if (ObjetoSobreElQueActua != null)
                {
                    if (ObjetoSobreElQueActua.name.Contains("Azulejo"))
                    {
                        gameManager.PuntoInterCuchillo.SetActive(true);
                        if (GameObject.Find("PuntoInteraccion ExamCuchillo"))
                        {
                            GameObject.Find("PuntoInteraccion ExamCuchillo").SetActive(false);
                        }

                    }
                }
                break;

            case 7:// Sin implementar
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                textoSubtitulo.text = "Todavía por implementar";
                Invoke("BorrarTexto", 5);
                break;

            case 8://esto es para el telefono
                FindObjectOfType<GameManager>().QuitarControl();
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                gameManager.InterfazTelefono.SetActive(true);
                gameManager.objetoSoundtrack.GetComponent<AuxiliarSonidos>().FadeOut();
               
                break;

            case 9://cortina
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                if (ObjetoSobreElQueActua.GetComponent<Animator>().GetBool("CortinaAbierta"))
                {
                    ObjetoSobreElQueActua.GetComponent<Animator>().SetBool("CortinaAbierta", false);
                    FindObjectOfType<GameManager>().sangreCompletado.SetActive(false);
                }
                else
                {
                    ObjetoSobreElQueActua.GetComponent<Animator>().SetBool("CortinaAbierta", true);
                    // FindObjectOfType<puzzleCortina>().HaAbiertoCortina();
                    FindObjectOfType<GameManager>().sangreCompletado.SetActive(true);
                }


                break;

            case 10://Puerta cerrada para golpear
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                if (!PuertaAporreada)
                {

                    gameManager.QuitarControl();
                    gameManager.PuntoInterTelefono1.SetActive(true);
                    Debug.Log("Aporreas la puerta");
                    //ObjetoSobreElQueActua.GetComponent<AudioSource>().Play();//prefiero el sonido en la animacion
                    ObjetoSobreElQueActua.GetComponent<Animator>().Play("AporreoPuerta");
                    //gameManager.objetoSoundtrack.GetComponent<AudioSource>().clip = FindObjectOfType<SoundtrackManager>().Knock;
                    FindObjectOfType<GameManager>().objetoSoundtrack.GetComponent<AudioSource>().Play();
                    //Aquí anim de la puerta moviéndose

                    Invoke("InvokeLlamada", 5);
                    //Sonido teléfono
                    PuertaAporreada = true;
                }
                break;

            case 11: //Teléfono
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                FindObjectOfType<ClipStorage>().StartCall();
                break;

            case 12: //TapaVater
                print("entra en case 12 de interactuar");
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                GameObject.Find("VaterSeparado (1)").GetComponent<Animator>().Play("Tapa vater");
                Invoke("AuxiliarMuestraPuntoOculto", 1.5f);
                break;
            case 13: //Abrir cajón grabadora
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                GameObject.Find("CajonFrontal").transform.GetChild(1).gameObject.SetActive(true);//encender la grabadora del cajon
                //GameObject.Find("Abrible").GetComponent<Animator>().Play("AbrirCajon");
                gameManager.PuntoInterCajon.transform.GetComponentInParent<Animator>().Play("AbrirCajon");
                FindObjectOfType<AuxiliarSonidos>().sonidoCajonAbrir();
                gameManager.PuntoInterGrabadora.SetActive(true);
                gameManager.PuntoInterCajon.SetActive(false);
               // objetoSangrePasado.SetActive(false);
                GameObject.Find("CajonFrontal").transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 14: //recogernotaConGrabadora          
                     //objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                     //FindObjectOfType<MemoManager>().GetComponent<MemoManager>().PickUpMemo(itemId, itemIMG, objetoPickUp.GetComponent<InfoItem>().textExam);
                     //    FindObjectOfType<MemoManager>().panelExamMemo.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(escribirAux);
                     //    //falta aniadirlo
                break;

            case 15://Sacar el azulejo
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                GameObject.Find("Bathroom_Furniture_02").GetComponent<Animator>().Play("SacarAzulejoDeMueble");
                Invoke("InvokeManecilla", 3);


                break;
            case 16:// Recoger Cuchillo
              //  managerSub.escribirDurante(2, "Has recogido: Cuchillo");
                switch (FindObjectOfType<LanguageManager>().currentLanguage)
                {
                    case LanguageManager.Language.English:
                        FindObjectOfType<managersubtitulos>().escribirDurante(3, "I got: Knife");
                        break;
                    case LanguageManager.Language.Spanish:
                        FindObjectOfType<managersubtitulos>().escribirDurante(3, "Has recogido: Cuchillo");
                        break;
                }
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                gameManager.PuntoInterAzulejo.SetActive(true);
                GameObject.Find("PuntoInteraccion PickCuchillo").SetActive(false);
                GameObject.Find("PuntoInteraccion OjoAzulejo").SetActive(false);
                GameObject.Find("Kitchen_knife2").SetActive(false);
                break;

            case 17: //Recoger Manecilla
                managerSub.escribirDurante(2, "Has recogido: Manecilla");
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                gameManager.PuntoInterManecillaUse.SetActive(true);
                //GameObject.Find("PuntoInteraccion ExamReloj").SetActive(false);
                GameObject.Find("Manecilla").SetActive(false);

                break;

            case 18: //Puzzle Reloj
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                gameManager.InterfazReloj.SetActive(true);

                break;
            case 19: //Puzzle TV
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                gameManager.QuitarControl();
                gameManager.InterfazTV.SetActive(true);
                for (int i = 0; i < puertaLuisPuzle.GetComponentsInChildren<PuntoInteraccion>().Length; i++)
                {
                    puertaLuisPuzle.GetComponentsInChildren<PuntoInteraccion>()[i].gameObject.SetActive(true);
                }

                break;

            //case 20://desequipar
            //    objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
            //    break;
            //case 21:
            //    objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
            //    break;

            case 22: //Pick nota+cassete
                print("entra en case 22 de interactuar");
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;

                //FindObjectOfType<InventoryManager>().CloseInventory();
                //gameManager.MenuFiles.SetActive(true);
                FindObjectOfType<InventoryManager>().listaNotas[5].SetActive(true);
                FindObjectOfType<MemoManager>().backgroundPlaceholderSelect[0].SetActive(true);
                FindObjectOfType<InventoryManager>().listaCassetes[0].SetActive(true);
                soundManager.GetComponent<AudioSource>().clip = soundManager.sonidoRecoger;
                soundManager.GetComponent<AudioSource>().Play();
                FindObjectOfType<GameManager>().QuitarControl();
                numeroDeNotasRecogidas++;
                gameManager.borrarVater.SetActive(false);
                telefonoSinNota.SetActive(true);
                break;


            case 23: //Recoge LlaveDeDetrasDeCortina MOVIDO DE SITIO
                     //objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                     //FindObjectOfType<GameManager>().CambiarEstado(6);// AQUI FALTA EL RESTO DE COSAS QUE TENGA QUE HACER COMO DIALOGOS, LO QUE SEA
                     //managerSub.escribirDurante(4, "Parece la llave del joyero que Mary guarda debajo de la mesita de noche...", true);
                     //Invoke("CallApagarEstucheLlave", 0.1f);
                break;

            case 24:
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                //Aquí animación de la caja con un evento al final de la misma con el métodoAnimCaja
                GameObject.Find("CajaMAry").GetComponent<Animator>().Play("CajitaMarySale");

                break;

            case 25:

                #region comentado
                //FindObjectOfType<AuxiliarSonidos>().sonidoRecogerPapel();
                //objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                //        FindObjectOfType<InventoryManager>().CloseInventory();
                //        print("Entra En Swich case 25");         
                //        print("hemos pasado por el case 2 dentro del objeto examinable " + contadorAux);
                //        itemId = objetoPickUp.GetComponent<InfoItem>().itemID;
                //        itemIMG = objetoPickUp.GetComponent<InfoItem>().itemIMG;
                //        FindObjectOfType<MemoManager>().GetComponent<MemoManager>().PickUpMemo(itemId, itemIMG, objetoPickUp.GetComponent<InfoItem>().textExam);
                //        listaSlotsParaNotas[numeroDeNotasRecogidas].GetComponent<FileSlot>().AddFile(itemIMG, objetoPickUp.GetComponent<InfoItem>().textExam, objetoPickUp.GetComponent<InfoItem>().tituloNotaOCinta);
                //        numeroDeNotasRecogidas++;
                //        gameManager.borrarJoyero.SetActive(false);
                //        objeto.SetActive(false);
                //      //Aquí tendremos que hacer algo que de feedbak de que se ha guardado la nota
                //      //Aquí examinar la caja y su contenido
                //for (int i = 0; i < slotsCasetes.Length; i++)
                //{
                //    if (!slotsCasetes[i].GetComponent<FileSlot>().ocupado)
                //    {
                //        FindObjectsOfType<FileSlot>()[i].AddFile("Cajita Mary", FindObjectOfType<SoundManager>().cassettePelea);
                //        print("se ha añadido la nota pelea");
                //        break;
                //    }
                //}
                #endregion

                FindObjectOfType<MemoManager>().backgroundPlaceholderSelect[2].SetActive(true);
                FindObjectOfType<GameManager>().QuitarControl();

                break;
            case 26: //punto interacion sellado hasta que no ves las movidas de la oficina
                if (haTerminadoDeMirarOficina)
                {
                    if (ObjetoSobreElQueActua.transform.parent == objeto.transform.parent)
                    {
                        objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;

                        puertaEnUso = true;
                        if (ObjetoSobreElQueActua.GetComponent<Animator>().GetBool("AbrirPuerta"))
                        {
                            DEBUG.GetComponent<Text>().text += '\n' + "Abrir puerta";
                            ObjetoSobreElQueActua.GetComponent<AudioSource>().clip = soundManager.sonidoPuertaCerrar[Random.Range(0, 2)];
                            CerrarPuerta();

                            ObjetoSobreElQueActua.GetComponent<AudioSource>().Play();
                            break;
                        }
                        else
                        {
                            DEBUG.GetComponent<Text>().text += '\n' + "No abrir puerta";
                            ObjetoSobreElQueActua.GetComponent<AudioSource>().clip = soundManager.sonidoPuertaAbrir[Random.Range(0, 2)];
                            AbrirPuerta();
                            ObjetoSobreElQueActua.GetComponent<AudioSource>().Play();
                            break;
                        }
                    }
                }
                else
                {
                   // FindObjectOfType<managersubtitulos>().escribirDurante(4, "Aun voy a trabajar un poco mas, no quiero molestarla hasta que me vaya a dormir");
                    switch (FindObjectOfType<LanguageManager>().currentLanguage)
                    {
                        case LanguageManager.Language.English:
                            FindObjectOfType<managersubtitulos>().escribirDurante(4, "I'm going to work a bit before going to bed");
                            break;
                        case LanguageManager.Language.Spanish:
                            FindObjectOfType<managersubtitulos>().escribirDurante(4, "Aún voy a trabajar un poco mas, no quiero molestarla hasta que me vaya a dormir");
                            break;
                    }
                    objeto.SetActive(true);
                }
                if (FindObjectOfType<GameManager>().estadoJuego == 0)
                {
                    Invoke("DevolverPuntoInteracion", 0.5f);
                }

                break;
            case 27://punto interacion mesa oficina
                    //GameObject.Find("PanelFade").GetComponent<Animator>().Play("FadeInNegro");

                gameManager.despachoUsado = true;
                haTerminadoDeMirarOficina = true;
                FindObjectOfType<GameManager>().QuitarControl();
                transform.GetChild(0).GetComponent<Camera>().enabled = false;
                refCamaraCine.SetActive(true);
                refCamaraCine.GetComponent<Animator>().Play("CamaraCineParaMesa oficina");
                refCamaraCine.transform.GetChild(0).GetComponent<Camera>().enabled = true;

                gameManager.QuitarControl();
                auxPlayWhiskyDrink();
                Invoke("AuxTurnOnInteractivePointNewsPaper", 8);

                transform.position = new Vector3(-9.5f, transform.position.y, -0.424f);
                FindObjectOfType<GameManager>().QuitarControl();
                break;
            case 28://punto interacion periodico
                haTerminadoDeMirarOficina = true;
                FindObjectOfType<AuxiliarSonidos>().sonidoRecogerPapel();
                FindObjectOfType<MemoManager>().backgroundPlaceholderSelect[3].SetActive(true);
                //FindObjectOfType<managersubtitulos>().escribirDurante(4, "Se ha anadido a tu inventario");
                puntoInterBlocNotasOficina.SetActive(true);
                FindObjectOfType<MemoManager>().PickUpMemo(19, null, "TEXTO NULL A  CAMBIAR POR ALGO");
                FindObjectOfType<AuxiliarSonidos>().vozJohnNoEntiendo();
                break;
            case 29://punto interacion notas sobre el caso y movidas escritas personales
                if (!haTerminadoDeMirarOficina)
                {
                    FindObjectOfType<AuxiliarSonidos>().vozJohn_FridayAlready();
                }

                haTerminadoDeMirarOficina = true;
                FindObjectOfType<AuxiliarSonidos>().sonidoRecogerPapel();
              
                
                FindObjectOfType<MemoManager>().backgroundPlaceholderSelect[4].SetActive(true);
                puntoInterGrabadoraOficina.SetActive(true);

                break;
            case 30://punto interacion grabadora con sonido willy retorciendose de dolor    //AnimGrabadoraOficina  
              gameManager.recorderOfficeTable.GetComponent<Animator>().Play("NewOfficeRecorderAnim");
                Invoke("auxPlayWhiskyDrink", 4);
                gameManager.knifeColliderTrigger.SetActive(true);
                //pasamos a un metodo todo lo que habia que hacer para qure pueda ser llamado por el animgrabadoraoficina
                break;

            case 31:// punto interacion DiarioMary con paginas arrancadas
                    //Guardar en inventario y recoger Diario de mary
                FindObjectOfType<AuxiliarSonidos>().sonidoRecogerPapel();
                FindObjectOfType<GameManager>().QuitarControl();
                FindObjectOfType<managersubtitulos>().escribirDurante(3, "Mary's Diary... ?");
                FindObjectOfType<MemoManager>().backgroundPlaceholderSelect[6].SetActive(true);
                break;
            case 32:// punto interacion Nota Arrancada Diario Mary 01
                FindObjectOfType<AuxiliarSonidos>().sonidoRecogerPapel();
                FindObjectOfType<GameManager>().QuitarControl();
                FindObjectOfType<managersubtitulos>().escribirDurante(3, "Diary page from Mary");
                //  FindObjectOfType<MemoManager>().backgroundPlaceholderSelect[6].SetActive(true);
                //FindObjectOfType<MemoManager>().PickUpMemo(17, null, "TEXTO NULL A  CAMBIAR POR ALGO");
                FindObjectOfType<InventoryManager>().listaNotas[3].gameObject.SetActive(true);
                FindObjectOfType<InventoryManager>().listaBackgrounds[6].gameObject.SetActive(true);
                //Guardar en inventario y recoger nota de mary
                break;
            case 33:// punto interacion Nota Arrancada Diario Mary 02
                FindObjectOfType<AuxiliarSonidos>().sonidoRecogerPapel();
                FindObjectOfType<GameManager>().QuitarControl();
                FindObjectOfType<managersubtitulos>().escribirDurante(3, "This is a page of Mary's diary");
                FindObjectOfType<InventoryManager>().listaNotas[4].gameObject.SetActive(true);
                FindObjectOfType<InventoryManager>().listaBackgrounds[7].gameObject.SetActive(true);
                //Guardar en inventario y recoger nota de mary

                break;
            case 34:// punto interacion Abrir Armario Para poder alcanzar Nota Mary 1
                print("ABRIR ARMARIO");
                ObjetoSobreElQueActua.GetComponent<Animator>().Play("PuertaARmario");
                //animacion de abrir y yasta
                break;

            case 35: //punto inter nuevo cassette paranoia
                FindObjectOfType<InventoryManager>().listaCassetes[1].SetActive(true);


                break;

            case 36:// nota de debajo de la puerta
                FindObjectOfType<GameManager>().QuitarControl();
                transform.GetChild(0).GetComponent<Camera>().enabled = false;
                refCamaraCine.SetActive(true);
                refCamaraCine.GetComponent<Animator>().Play("JohnAfterNote");
                refCamaraCine.transform.GetChild(0).GetComponent<Camera>().enabled = true;
                gameManager.Invoke("DevolverControl", 16.1f);
                Invoke("CustomAux", 16.1f);
                FindObjectOfType<gestorCamaraCine>().Invoke("CerrarPuertaPrincipal", 15.9f);
                //gameManager.QuitarControl();
                //FindObjectOfType<MemoManager>().backgroundPlaceholderSelect[1].SetActive(true);
                //FindObjectOfType<GameManager>().QuitarControl();
                FindObjectOfType<InventoryManager>().listaNotas[7].SetActive(true);
                FindObjectOfType<managersubtitulos>().escribirDurante(3, "A note was added to your inventory");
                break;
            case 37: //No tienes la nota del teléfono
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                GameObject.Find("PhoneNote").transform.GetChild(0).gameObject.SetActive(true);
                telefonoSinNota.SetActive(false);
                FindObjectOfType<managersubtitulos>().escribirDurante(2, "I dont remember her phone number");
                FindObjectOfType<AuxiliarSonidos>().ostEscena5Tema6_2();
                break;
            case 38: //Tienes la nota del teléfono
                objeto.GetComponent<PuntoInteraccion>().pruebaUnClick = false;
                GameObject.Find("PhoneNote").transform.GetChild(0).gameObject.SetActive(false);
                FindObjectOfType<managersubtitulos>().escribirDurante(4, "A note was added to your inventory");
                FindObjectOfType<InventoryManager>().listaNotas[2].SetActive(true);
                telefonoConNota.SetActive(true);
                break;
            case 39:
                ObjetoSobreElQueActua.GetComponent<Animator>().Play("Outside door blood transition");
                FindObjectOfType<GameManager>().finalNote.SetActive(true);
                GameObject.Find("SourceFinal").GetComponent<AudioSource>().Play();
        
                break;
        }
    }
    public void LastCameraAnimation()
    {
        GameObject.Find("PanelFade").GetComponent<Animator>().Play("FadeOut");
        FindObjectOfType<gestorCamaraCine>().ApagarCamaraJugador();
      
    }
    public void CustomAux()
    {
        refCamaraCine.SetActive(false);
        transform.GetChild(0).GetComponent<Camera>().enabled = true;
    }
    public void auxPlayWhiskyDrink()
    {
        gameManager.whyskyGlassAnim.GetComponent<Animator>().Play("Whsyky Glass Drink");
    }
    public void UsarGrabadoraOficina()
    {
        gameManager.despachoCompletado = true;
        FindObjectOfType<InventoryManager>().listaCassetes[2].SetActive(true);
        haTerminadoDeMirarOficina = true;
        refCamaraCine.SetActive(false);
        transform.GetChild(0).GetComponent<Camera>().enabled = true;

        FindObjectOfType<GameManager>().DevolverControl();
        //  FindObjectOfType<managersubtitulos>().escribirDurante(3, "No puedo más, me voy a dormir.", true);

        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                FindObjectOfType<AuxiliarSonidos>().vozJohn_enough();
                FindObjectOfType<managersubtitulos>().escribirDurante(6, "I’ve had enough of this for a lifetime... Bed’s calling my name anyway.");
                break;
            case LanguageManager.Language.Spanish:
                FindObjectOfType<managersubtitulos>().escribirDurante(3, "No puedo más, me voy a dormir.");
                break;
        }

    }

    public void AuxTurnOnInteractivePointNewsPaper()
    {
        puntoInterPeriodico.SetActive(true);

    }

    public void CallMaryCry()
    {
        GameObject.Find("AudioSource MaryCry").GetComponent<AudioSource>().Play();
    }
    public void DevolverPuntoInteracion()
    {
        puntoInteracionASalvar.SetActive(true);
    }
    public void CallPickUpMemo()
    {
        FindObjectOfType<MemoManager>().GetComponent<MemoManager>().PickUpMemo(itemId, itemIMG, objetoPickUp.GetComponent<InfoItem>().textExam);
    }

    public void Llamarfuncion23Manual()
    {
        GameObject.Find("PuntoInteraccion InterLLaveJoyero").GetComponent<PuntoInteraccion>().pruebaUnClick = false;
        FindObjectOfType<GameManager>().CambiarEstado(6);// AQUI FALTA EL RESTO DE COSAS QUE TENGA QUE HACER COMO DIALOGOS, LO QUE SEA
        managerSub.escribirDurante(4, "This key... belongs to Mary.", true);
        Invoke("CallApagarEstucheLlave", 0.1f);
        transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true;
        transform.GetChild(0).gameObject.GetComponent<Animator>().Play("AnimacionCajitaAnilloAbriendoseDelanteDeCara");
    }
    public void CallApagarEstucheLlave()
    {
        GameObject.Find("Estuche de anillo").SetActive(false);
    }

    public void metodoAnimCaja()
    {
        FindObjectOfType<AuxiliarSonidos>().ostTeaser();
        itemId = objetoPickUp.GetComponent<InfoItem>().itemID;
        itemIMG = objetoPickUp.GetComponent<InfoItem>().itemIMG;
        FindObjectOfType<MemoManager>().GetComponent<MemoManager>().PickUpMemo(itemId, itemIMG, objetoPickUp.GetComponent<InfoItem>().textExam);
        listaSlotsParaNotas[numeroDeNotasRecogidas].GetComponent<FileSlot>().AddFile(itemIMG, objetoPickUp.GetComponent<InfoItem>().textExam, objetoPickUp.GetComponent<InfoItem>().tituloNotaOCinta);
        numeroDeNotasRecogidas++;
        //managerSub.escribirDurante(3, "Que hace mi cara tachada?", true);
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                FindObjectOfType<AuxiliarSonidos>().vozJohn_MaryDoThis();
                FindObjectOfType<managersubtitulos>().escribirDurante(3, "Did... Mary do this?", true);
                break;
            case LanguageManager.Language.Spanish:
                FindObjectOfType<managersubtitulos>().escribirDurante(3, "Que hace mi cara tachada?", true);
                break;
        }
    }
    public void escribirAux()
    {
        if (gameManager.estadoJuego == 2)
        {
            managerSub.escribirDurante(4, "Junto a la nota había un casete", true);
        }
        else if (gameManager.estadoJuego == 3)//el k sea
        {
            managerSub.escribirDurante(4, "falta por implementar");
        }
        else if (gameManager.estadoJuego == 4)
        {
            managerSub.escribirDurante(4, "Jfalta por implementar");
        }
    }

    public void AuxiliarMuestraPuntoOculto()
    {
        objetoPickUp.SetActive(true);
    }
    public void InvokeJODER()
    {
        FindObjectOfType<AuxiliarSonidos>().GetComponent<AuxiliarSonidos>().vozAhoraQue();
        gameManager.DevolverControl();
    }
    public void InvokeLlamada()
    {
      
        telefonoCocina.GetComponent<AudioSource>().Play();
        Invoke("InvokeJODER", 4);
        PuertaAporreada = true;
        GameObject.Find("AudioSource MaryCry").GetComponent<AudioSource>().mute = true;
    }
  

    public void InvokeManecilla()
    {
        gameManager.PuntoInterManecillaPick.SetActive(true);
    }
    public void BorrarTexto()
    {
        textoSubtitulo.text = " ";
    }
    public void checkTouch2(Vector3 pos) //¿porque todas las interaciones que se llaman llevan la llave de puerta con ellas?
    {
        Ray ray;
        if (refCamaraCine.activeInHierarchy)
        {
            ray = refCamaraCine.transform.GetChild(0).GetComponent<Camera>().ScreenPointToRay(pos);
        }
        else
        {
             ray = Camera.main.ScreenPointToRay(pos);
        }
     
        DEBUG.GetComponent<Text>().text = "pos = (" + pos.x + ", " + pos.y + ", " + pos.z + ")";
        Debug.DrawRay(ray.origin, ray.direction * 3, Color.green);
        RaycastHit hit;
        ignorarPlayer = 1 << 13;
        ignorarPlayer = ~ignorarPlayer;

        if (Physics.Raycast(ray, out hit,100f, ignorarPlayer))
        {
            DEBUG.GetComponent<Text>().text += '\n' + "hit = " + hit.transform.gameObject.name + " - " + hit.transform.position.x + ", " + hit.transform.position.y+ ", " + hit.transform.position.z;
            //if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)//HAY QUE CONSEGUIR QUE ESTO SOLO SE ACTIVE CUANDO EL TOUCH ESTA EN ENDED
            //{
                DEBUG.GetComponent<Text>().text += '\n' + "contains: " + hit.transform.gameObject.name.Contains("PuntoInteraccion").ToString();
                DEBUG.GetComponent<Text>().text += '\n' + "equals: " + hit.transform.gameObject.name.Equals("PuntoInteraccion").ToString();
                objeto = hit.transform.gameObject;
                DEBUG.GetComponent<Text>().text += '\n' + "Objeto";
                if (hit.transform.gameObject.name.Contains("PuntoInteraccion"))
                {
                    DEBUG.GetComponent<Text>().text += '\n' + "OK name";
             
                    //Debug.Log("Ray:" + hit.transform.name + "y ha entrado en punto de interacción");
                    if (hit.transform.gameObject.GetComponent<PuntoInteraccion>().objetoPickup != null)//peta aquií
                    {
                        DEBUG.GetComponent<Text>().text += '\n'+ "pickupdentro";
                        objetoPickUp = hit.transform.gameObject.GetComponent<PuntoInteraccion>().objetoPickup;
                    }
                    DEBUG.GetComponent<Text>().text += '\n' + "pickupfuera";
                    ObjetoSobreElQueActua = hit.transform.gameObject.GetComponent<PuntoInteraccion>().objetoSobreElQueActuaPuntoInteracion;
                    //DEBUG.GetComponent<Text>().text += '\n' + ObjetoSobreElQueActua.name;
                    numInterAux = hit.transform.gameObject.GetComponent<PuntoInteraccion>().numeroInteraccion;
                    DEBUG.GetComponent<Text>().text += '\n' + numInterAux.ToString();
                    objeto.transform.GetComponentInChildren<FadeController>().FadeOutIcon();
                    DEBUG.GetComponent<Text>().text += '\n' + "children" +
                        "";

                    Interactuar(hit.transform.gameObject.GetComponent<PuntoInteraccion>().numeroInteraccion);
                    if (numInterAux == 0 && numInterAux == 2 && numInterAux == 6 && numInterAux == 5 && numInterAux == 19)
                    {
                        hit.transform.GetComponentInChildren<FadeController>().Invoke("FadeInIcon", 4);
                    }
                    if (numInterAux != 0 && numInterAux != 2 && numInterAux != 6 && numInterAux != 5 && numInterAux != 19)
                    {

                        hit.transform.gameObject.SetActive(false);
                    }
                    if (hit.transform.gameObject.tag.Equals("objeto"))
                    {
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
                else if (hit.transform.gameObject.CompareTag("Player") || (hit.transform.gameObject.name.Contains("Player")))
                {
                    checkTouch2(pos);
                }
            }
            
            //}
        }
    }

}
