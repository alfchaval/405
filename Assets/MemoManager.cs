using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MemoManager : MonoBehaviour {

    public Animator panelFadeAnim1;
    public Animator panelFadeAnim2;
    public GameObject panelExamMemo;
    public GameObject menuFiles;
    public GameManager gameManager;
    public GameObject backgroundPlaceholder;
    public GameObject[] backgroundPlaceholderSelect;
    public bool primeraNotaRecogida;
    public bool aux2Dicho;
    public bool aux3Dicho;
    public bool hecho;



    // Use this for initialization
    void Start () {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void ResetBotonCerrarPanelExam()
    {
       //añadir un if aqui,, para que solo lo encuentre si existe
        GameObject.Find("CloseExamMemo").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("CloseExamMemo").GetComponent<Button>().onClick.AddListener(FindObjectOfType<MemoManager>().ClosePanelExam);
    }
    public void AuxiliarDecirmovida1()
    {
        if (gameManager.estadoJuego == 3)
        {
            if (!hecho)
            {
                FindObjectOfType<managersubtitulos>().GetComponent<managersubtitulos>().escribirDurante("No..", true);
            }
        }
       
    }
    public void AuxiliarDecirmovidaFotosMary()
    {
        FindObjectOfType<managersubtitulos>().GetComponent<managersubtitulos>().escribirDurante(2,"Our pictures and another tape", true);
    }

    public void PickUpMemo (int itemId, Sprite itemIMG , string textExam)
    {
        FindObjectOfType<AuxiliarSonidos>().sonidoRecogerPapel();
        //if (!primeraNotaRecogida)
        //{
        //    //menuFiles.SetActive(true);
        //    primeraNotaRecogida = true;
        //    print("primera nota recogida false, ha entrado y la ha puesto a true");
        //}

        if (itemId == 4) //NotacasseteWC
        {
            FindObjectOfType<InventoryManager>().listaNotas[5].SetActive(true);
            backgroundPlaceholder = backgroundPlaceholderSelect[0];
            backgroundPlaceholderSelect[0].SetActive(true);
            FindObjectOfType<GameManager>().QuitarControl();
            print("entra en itemid = 4, ebcuebde ek backgroundplaceholderselect 0 ");

        }
        else if (itemId == 2) //Nota puerta
        {
            backgroundPlaceholder = backgroundPlaceholderSelect[1];
            print("entra en itemid = 2, ebcuebde ek backgroundplaceholderselect 1 ");
            if (!GameObject.Find("puertaParaLuis (3)").GetComponentInChildren<Animator>().GetBool("AbrirPuerta"))
            {
                GameObject.Find("puertaParaLuis (3)").transform.GetChild(1).gameObject.SetActive(true);
            }
       
       
        }
        else if (itemId == 5) //Fotos mary
        {
          
            backgroundPlaceholder = backgroundPlaceholderSelect[2];
            FindObjectOfType<InventoryManager>().listaNotas[6].SetActive(true);
             

        }

        else if (itemId == 16)// DiarioMary1
        {
            FindObjectOfType<InventoryManager>().listaNotas[2].SetActive(true);
            FindObjectOfType<GameManager>().QuitarControl();
            backgroundPlaceholderSelect[6].SetActive(true);
        }

        else if (itemId == 17)// NotaMary
        {
            FindObjectOfType<InventoryManager>().listaNotas[3].SetActive(true);
            FindObjectOfType<GameManager>().QuitarControl();
            backgroundPlaceholderSelect[5].SetActive(true);
        }
        else if (itemId == 18)// NotaMary2
        {
            FindObjectOfType<InventoryManager>().listaNotas[4].SetActive(true);
            backgroundPlaceholderSelect[7].SetActive(true);
            FindObjectOfType<GameManager>().QuitarControl();
        }
        else if (itemId == 19)//PeriodicoJohn
        {
            FindObjectOfType<InventoryManager>().listaNotas[0].SetActive(true);
            backgroundPlaceholderSelect[3].SetActive(true);
        }

        else if (itemId == 20)//BlocNotasJohn
        {
            FindObjectOfType<InventoryManager>().listaNotas[1].SetActive(true);
            backgroundPlaceholderSelect[4].SetActive(true);
        }


        else if (itemId == 0)
        {
            //Se llama desde Inventario, recoge la imagen desde imagenAMostrar o así
        }

       
        //panelExamMemo.GetComponent<Text>().text = textExam;
            //Invoke("ShowImageCall", 1f);
        FindObjectOfType<managersubtitulos>().GetComponent<managersubtitulos>().escribirDurante(1, "A note has been added to your files.");
        FindObjectOfType<InventoryManager>().desequiparTodo();
        FindObjectOfType<GameManager>().QuitarControl();

        if (itemId == 4) //Cuando recoges la nota del váter
        {

            FindObjectOfType<GameManager>().CambiarEstado(3);
        }


    }

    public void ShowImageCall()
    {
        FindObjectOfType<AuxiliarSonidos>().sonidoRecogerPapel();
        print("ShowImageCall");
        backgroundPlaceholder.SetActive(true);
        panelExamMemo.SetActive(true);
        if (gameManager.estadoJuego == 3)
        {
            GameObject.Find("CloseExamMemo").GetComponent<Button>().onClick.AddListener(AuxiliarDecirmovida1);
        }
        else if (gameManager.estadoJuego == 6)
        {
            GameObject.Find("CloseExamMemo").GetComponent<Button>().onClick.AddListener(AuxiliarDecirmovidaFotosMary);
        }
        print("sale de ShowImageCall");

    }
    public void ClosePanelExam()
    {
        //GameObject.Find("CloseExamMemo").GetComponent<Button>().onClick.AddListener(FindObjectOfType<MemoManager>().ResetBotonCerrarPanelExam);

        if (FindObjectOfType<GameManager>().estadoJuego == 2) //Cuando recoges la nota del váter
        {
            //FindObjectOfType<GameManager>().objetoSoundtrack.GetComponent<AudioSource>().clip = FindObjectOfType<SoundtrackManager>().Llamada;
            //FindObjectOfType<GameManager>().objetoSoundtrack.GetComponent<AudioSource>().Play();
            FindObjectOfType<GameManager>().CambiarEstado(3);
            FindObjectOfType<AuxiliarSonidos>().FadeOut();
        }
        if (FindObjectOfType<GameManager>().estadoJuego == 6) //Cuando la cajita de Mary
        {
            FindObjectOfType<GameManager>().trueFinalphoneInteractiveSpot.SetActive(false);
            //ESTO SE TIENE QUE MOVER A CUANDO REPRODUCES LA CINTA ROTA
        }        
        //panelExamMemo.SetActive(false);
        //backgroundPlaceholder.SetActive(false);
        panelFadeAnim1.Play("FadeOut");
        print("Sale ClosePanelExam");
        Invoke("escribirAux", 2);
        FindObjectOfType<GameManager>().DevolverControl();
    }

    public void escribirAux()
    {
        //if (gameManager.estadoJuego == 2)
        //{
        //    FindObjectOfType<managersubtitulos>().escribirDurante(4, "Junto a la nota había un casete", true);
        //}
        if (gameManager.estadoJuego == 3)//el k sea
        {
            if (!hecho)
            {
                hecho = true;
                //FindObjectOfType<managersubtitulos>().escribirDurante("no no no no… esto no puede estar pasando… voy a llamarla", false);
                switch (FindObjectOfType<LanguageManager>().currentLanguage)
                {
                    case LanguageManager.Language.English:
                        FindObjectOfType<managersubtitulos>().escribirDurante("No, no, no, no... this can't be happening...", false);
                        break;
                    case LanguageManager.Language.Spanish:
                        FindObjectOfType<managersubtitulos>().escribirDurante("no no no no… esto no puede estar pasando… voy a llamarla", false);
                        break;
                }
                FindObjectOfType<AuxiliarSonidos>().GetComponent<AuxiliarSonidos>().vozNoPuedeEstar();
                Invoke("invokeAuxescribir2", 3);
            }

        }
        else if (gameManager.estadoJuego == 4)
        {
            FindObjectOfType<managersubtitulos>().escribirDurante(4, "falta por implementarestadojuego4");
        
        }

    }

    public void invokeAuxescribir2()
    {
        if (!aux2Dicho)
        {
            ///  FindObjectOfType<managersubtitulos>().escribirDurante(" voy a llamarla, voy a llamar a casa de su madre ahora mismo", false);
            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:
                    FindObjectOfType<managersubtitulos>().escribirDurante(3, "God what was her mum’s number?", false);
                    break;
                case LanguageManager.Language.Spanish:
                    FindObjectOfType<managersubtitulos>().escribirDurante(4, "voy a llamarla, voy a llamar a casa de su madre ahora mismo", false);
                    break;
            }
            Invoke("invokeAuxescribir3", 2);
        }
        else
        {

        }

    }
    public void invokeAuxescribir3()
    {
        if (!aux3Dicho)
        {

            switch (FindObjectOfType<LanguageManager>().currentLanguage)
            {
                case LanguageManager.Language.English:

                    break;
                case LanguageManager.Language.Spanish:
                    FindObjectOfType<managersubtitulos>().escribirDurante(2, "seguro que es un malentendido", false);
                    break;
            }

        }
        else
        {

        }

    }
}

