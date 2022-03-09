using UnityEngine;
using System;
//using UnityEngine.Events;
//using UnityEditor.Events;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    public bool isOpen;
    public bool isOpenRecorder;
    public Animator inventoryAnimator;
    public Animator recorderAnimator;
    public Button botonInventory;
    public GameObject[] inventoryButtons;
    public GameObject grabadoraObjetoPicar;
    public GameObject cemObjetoPicar;
    public GameObject luzObjetoPicar;
    public GameObject grabadora;
    public GameObject cem;
    public GameObject luz;
    public GameObject flecha1;
        
    public bool grabadoraEquipada;
    public bool luzEquipada;
    public bool primeraVezAbiertoINV;

    public GameObject[] listaObjetos;       //0 linterna 1 Grabadora
    public GameObject[] listaNotas;         //0- Periodico 1- BlocJohn 2- Diario Mary 3- nota Mary1 4 nota Mary2 5 notaWC 6 FotosFinal
    public GameObject[] listaBackgrounds;
    public GameObject[] listaCassetes;      //0 WC 1 Willy MOribundo 2 ParanoiaJohn

    int itemId;
    Sprite itemIMG;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void OpenInventory()
    {
      
        if (!isOpen)// ESTO HAY QUE CAMBIARLO POR EL NUEVO INVENTARIO
        {
            if (!primeraVezAbiertoINV)
            {
                flecha1.SetActive(false);
                primeraVezAbiertoINV = true;
            }

            inventoryAnimator.Play("openInventory");
            isOpen = true;
            botonInventory.onClick.RemoveAllListeners();
            botonInventory.onClick.AddListener(CloseInventory);
            print("Abro inv");
            FindObjectOfType<GameManager>().inventarioMostrado = true;
        }
        else
        {
            CloseInventory();
            print("se ha cerrado el inventario");
        }
      
    }
    public void CloseInventory()
    {
        if (isOpen)
        {
            print("dentro del metodo cerrar inventario");
            inventoryAnimator.Play("closeinventory");
            isOpen = false;
            botonInventory.onClick.RemoveAllListeners();
            botonInventory.onClick.AddListener(OpenInventory);
            print("Cierra inv");
            //FindObjectOfType<GameManager>().inventarioMostrado = false;
        }
      
    }
    public void ObtenerObjeto(Button botonObjeto)
    {
        itemId = botonObjeto.GetComponent<InfoItem>().itemID;
        itemIMG = botonObjeto.GetComponent<InfoItem>().itemIMG;
        AddItem(itemId, itemIMG);
    }
    public void llamarGrabadora()
    {
        if (grabadoraEquipada)
        {
            CloseRecorderPanel();
            grabadora.SetActive(false);
          //  grabadoraEquipada = false;
           
            print("ha intentado equipar la grabadora y como  la tenia se ha DESequipado");
        }
        else
        {

            grabadora.SetActive(true);
            cem.SetActive(false);
            luz.SetActive(false);
            grabadoraEquipada = true;
            luzEquipada = false;
            print("ha intentado equipar la grabadora y como no la tenia se ha equipado");
        }
        CloseInventory();


    }

    public void CallGrabadoraDesdeCassete() {
        if (!grabadoraEquipada)
        {         
            grabadora.SetActive(true);
            cem.SetActive(false);
            luz.SetActive(false);
            grabadoraEquipada = true;
            luzEquipada = false;
            print("llama a grabadora desde inventario");
        }
    }
    public void llamarCem()
    {

        grabadora.SetActive(false);
        cem.SetActive(true);
        luz.SetActive(false);
        /* FindObjectOfType<InteracionConObjetosRayCast>().cem.SetActive(true);
         FindObjectOfType<InteracionConObjetosRayCast>().grabadora.SetActive(false);
         FindObjectOfType<InteracionConObjetosRayCast>().luz.SetActive(false);*/
    }
    public void llamarLuz()
    {
        if (luzEquipada)
        {
            FindObjectOfType<AuxiliarSonidos>().sonidoLinternaOff();
            luz.SetActive(false);
            luzEquipada = false;
        }
        else
        {
            FindObjectOfType<AuxiliarSonidos>().sonidoLinternaOn();
            grabadora.SetActive(false);
            cem.SetActive(false);
            luz.SetActive(true);
            if (grabadoraEquipada)
            {
                CloseRecorderPanel();
               
            }
            luzEquipada = true;
           // grabadoraEquipada = false;
        }
        CloseInventory();

        /*FindObjectOfType<InteracionConObjetosRayCast>().luz.SetActive(true);
        FindObjectOfType<InteracionConObjetosRayCast>().grabadora.SetActive(false);
        FindObjectOfType<InteracionConObjetosRayCast>().cem.SetActive(false);*/
    }

    //public void llamarCassette(int itemId)
    //{
    //    grabadora.GetComponent<Grabadora>().evento = itemId;

    //}

    public void desequiparTodo()
    {
        grabadora.SetActive(false);
        if (luzEquipada)
        {
            FindObjectOfType<AuxiliarSonidos>().sonidoLinternaOff();
            luz.SetActive(false);
            luzEquipada = false;
        }
        
        if (grabadoraEquipada)
        {
         //   grabadoraEquipada = false;
            CloseRecorderPanel();
        }
       
       
    }
    public void AddItem(int itemId, Sprite itemIMG)
    {
        FindObjectOfType<AuxiliarSonidos>().sonidoEquiparInv();
        inventoryButtons = GameObject.FindGameObjectsWithTag("InventoryButtons");
        switch (itemId)// ESTO HAY QUE CAMBIARLO PARA QUE SEA EL NUEVO INVENTARIO
        {
            case 0:
                //if (!inventoryButtons[itemId].GetComponent<itemSlot>().ocupado)// grabadora
                //{
                //    inventoryButtons[itemId].GetComponent<itemSlot>().ocupado = true;
                //    inventoryButtons[0].GetComponent<Button>().onClick.RemoveAllListeners();
                //    inventoryButtons[0].GetComponent<Button>().onClick.AddListener(llamarGrabadora);
                //    inventoryButtons[0].GetComponent<Button>().onClick.AddListener(OpenRecorderPanel);

                //    inventoryButtons[0].GetComponent<Button>().onClick.AddListener(luz.GetComponent<LuzUltraVioleta>().ApagarTodasLuces);
                //    inventoryButtons[itemId].GetComponent<Image>().sprite = itemIMG;
                //    Image image = inventoryButtons[itemId].GetComponent<Image>();
                //    var tempColor = image.color;
                //    tempColor.a = 1f;
                //    image.color = tempColor;
                //}
                listaObjetos[1].SetActive(true);
                Debug.Log("Recoge la grabadora");
                break;
            case 1: // llamar a la luz
                //if (!inventoryButtons[itemId].GetComponent<itemSlot>().ocupado)
                //{
                //    inventoryButtons[itemId].GetComponent<itemSlot>().ocupado = true;
                //    inventoryButtons[1].GetComponent<Button>().onClick.RemoveAllListeners();
                //    inventoryButtons[1].GetComponent<Button>().onClick.AddListener(llamarLuz);
                //    inventoryButtons[1].GetComponent<Button>().onClick.AddListener(CloseRecorderPanel);
                //    inventoryButtons[itemId].GetComponent<Image>().sprite = itemIMG;
                //    Image image = inventoryButtons[itemId].GetComponent<Image>();
                //    var tempColor = image.color;
                //    tempColor.a = 1f;
                //    image.color = tempColor;
                //}
                listaObjetos[0].SetActive(true);
                llamarLuz();
                break;
            //case 2:
            //    if (!inventoryButtons[itemId].GetComponent<itemSlot>().ocupado)
            //    {
            //        inventoryButtons[itemId].GetComponent<itemSlot>().ocupado = true;
            //        inventoryButtons[2].GetComponent<Button>().onClick.RemoveAllListeners();
            //        inventoryButtons[2].GetComponent<Button>().onClick.AddListener(llamarLuz);
            //        inventoryButtons[2].GetComponent<Button>().onClick.AddListener(CloseRecorderPanel);
            //        inventoryButtons[itemId].GetComponent<Image>().sprite = itemIMG;
            //        Image image = inventoryButtons[itemId].GetComponent<Image>();
            //        var tempColor = image.color;
            //        tempColor.a = 1f;
            //        image.color = tempColor;
            //    }
            //    break;
            //case 3:
            //    if (!inventoryButtons[itemId].GetComponent<itemSlot>().ocupado)
            //    {
            //        inventoryButtons[itemId].GetComponent<itemSlot>().ocupado = true;
            //        inventoryButtons[3].GetComponent<Button>().onClick.RemoveAllListeners();
            //        //   inventoryButtons[3].GetComponent<Button>().onClick.AddListener(delegate { llamarCassette(itemId); });
            //        inventoryButtons[3].GetComponent<Button>().onClick.AddListener(llamarGrabadora);
            //        inventoryButtons[3].GetComponent<Button>().onClick.AddListener(OpenRecorderPanel);
            //        inventoryButtons[3].GetComponent<Button>().onClick.AddListener(luz.GetComponent<LuzUltraVioleta>().ApagarTodasLuces);
            //        inventoryButtons[itemId].GetComponent<Image>().sprite = itemIMG;
            //        Image image = inventoryButtons[itemId].GetComponent<Image>();
            //        var tempColor = image.color;
            //        tempColor.a = 1f;
            //        image.color = tempColor;
            //    }
            //    break;
            //case 4:
            //    // Este caso es la llavePrueba
            //    if (!inventoryButtons[itemId].GetComponent<itemSlot>().ocupado)
            //    {
            //        inventoryButtons[itemId].GetComponent<itemSlot>().ocupado = true;
            //        inventoryButtons[4].GetComponent<Button>().onClick.RemoveAllListeners();
            //        inventoryButtons[itemId].GetComponent<Image>().sprite = itemIMG;
            //    }
            //    break;

            default:
                break;
        }


        /* if (GameObject.FindGameObjectsWithTag("InventoryButtons")[0].name.Contains(""))
         {
         }*/
        for (int i = 0; i < inventoryButtons.Length; i++)
        {

            /*if (!inventoryButtons[i].GetComponent<itemSlot>().ocupado)
            {
                inventoryButtons[i].GetComponent<itemSlot>().ocupado = true;
                inventoryButtons[i].GetComponent<itemSlot>().currentItem = itemId;
                inventoryButtons[i].GetComponent<Image>().sprite = itemIMG;
                inventoryButtons[i].GetComponent<Button>().onClick.AddListener(CloseInventory);
                Debug.Log("close inventory");
                if (inventoryButtons[i].name.Contains("grabadora"))
                {
                    Debug.Log("soygrabadora . add listener");
                    inventoryButtons[i].GetComponent<Button>().onClick.RemoveAllListeners();
                    inventoryButtons[i].GetComponent<Button>().onClick.AddListener(llamarGrabadora);
                }
                else if (inventoryButtons[i].name.Contains("cem"))
                {
                    inventoryButtons[i].GetComponent<Button>().onClick.AddListener(llamarCem);
                }
                else if (inventoryButtons[i].name.Contains("luz"))
                {
                    inventoryButtons[i].GetComponent<Button>().onClick.AddListener(llamarLuz);
                }
                Debug.Log("hola entro de boton que gustazo");
                break;
            }*/
        }
    }


    public void OpenRecorderPanel()
    {
 
            print("Abrimos el panel grabadora");
            recorderAnimator.Play("ToggleRecorderIn");
 
    }

    public void CloseRecorderPanel()
    {
      
            print("Cerramos el panel grabadora");
        if (grabadoraEquipada)
        {
            recorderAnimator.Play("ToggleRecorderOut");
            grabadoraEquipada = false;
        }
           
         
  

    }




}