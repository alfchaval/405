using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleReloj : MonoBehaviour {

    public float contador;
    public bool contando;
    public GameObject luz;
    public AudioSource tvSource;
	// Use this for initialization
	void Start () {
       // FindObjectOfType<GameManager>().QuitarControl();
        tvSource = GameObject.Find("television-texturizada2Piezas").GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        //if (contando)
        //{
        //    contador += Time.deltaTime;
        //}
        //if (contador >= 2)
        //{
        //    contando = false;
        //    PuzleRelojResuelto();
        //}
	}

    public void PuzleRelojResuelto()
    {
        FindObjectOfType<GameManager>().RelojObjeto.GetComponent<AudioSource>().Play();
        Debug.Log("SE HA RESUELTO EL PUZLE");
        Invoke("InvokeTV", 3f);
       
        
    }
    public void InvokeTV()
    {
        tvSource.Play();
        luz.SetActive(true);
        FindObjectOfType<GameManager>().PuntoInterTV.SetActive(true);
        //FindObjectOfType<GameManager>().DevolverControl();
        //GameObject.Find("Manecilla De reloj 2").GetComponent<MeshRenderer>().enabled = true;
        //FindObjectOfType<GameManager>().InterfazReloj.SetActive(false);

       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        contando = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        contando = false;
        contador = 0;
    }
    public void ApagarReloj()
    {
        
    }
}
