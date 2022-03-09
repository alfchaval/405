using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAccion : MonoBehaviour {

	// Para las puertas, vamos a hacer que aleatoriamente se abran y se cierren, para crear tension.
	// Hacer sonido diferente si se abre o si se cierra

	public AudioClip SoundAbrir;
	public AudioClip SoundCerrar;
	public int tipo = 0;
	public Animator anim;
	public AudioSource AudioSourceDesconocido;
	public bool boleano = false;
	public float tiempoEventos = 8f; 
	public float tiempoInicial = 10f;
	public int probabilidadEvento = 10;
	public bool ActuaSolo=true;
	
	int evento = 0;
	// Use this for initialization
	void Start () {
		//boleano = false;
		if(ActuaSolo){
			Invoke("IniciarEventos",tiempoInicial);
		}
		if(tipo == 1){
			anim.SetBool("LuzEncendida",boleano);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void IniciarEventos(){
		evento = Random.Range(0,100);
		
		if(evento<=probabilidadEvento){
			FuncionInteraccion();
		} 
		Invoke("IniciarEventos",tiempoEventos);
		
	}
	
	public void FuncionInteraccion(){
		switch(tipo){
				case 0:  // Puertas, armarios, cosas que se abren
					boleano = !boleano;
					anim.SetBool("AbrirPuerta",boleano);
					if(!boleano){
						AudioSourceDesconocido.clip=SoundCerrar;
						AudioSourceDesconocido.Play();
					}else{
						AudioSourceDesconocido.clip=SoundAbrir;
						AudioSourceDesconocido.Play();
					}
					break;
				case 1:
					boleano = !boleano;
					anim.SetBool("LuzEncendida",boleano);
					if(!boleano){
						AudioSourceDesconocido.clip=SoundCerrar;
						AudioSourceDesconocido.Play();
					}else{
						AudioSourceDesconocido.clip=SoundAbrir;
						AudioSourceDesconocido.Play();
					}
					break;				
		}
	}
}
