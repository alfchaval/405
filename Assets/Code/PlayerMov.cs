using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMov : MonoBehaviour {
 
	// 20 176 20 89
	
[Header ("References")]
	public GameObject CamaraPl;
	public Transform InicioRayoVision;
	public GameObject botonInteraccion;
	//public Transform playerTf; // Este es para que las animaciones no desvien el forward (mixamo, provisional)
	public Transform pivoteCam; // Pivote de giro con camara
	public Transform playerPadre; // Objeto principal player
	public JoystickButton JB1;	// Joystick de movimiento
	public Image visor;
	
	//public Text textoVida;
	
	[Header ("Configuration")]
	public float DistanciaVision = 2f;
	
	[Header ("Movil")]
	//public float fuerzaSalto = 5f;
	public float sensibilidadJB1=1f;
	public float sensibilidadJB2=1f;
	public float velocidadJoys = 2f;
	
	[Header ("PC Controller")]
	public float velocidadMov = 2f;
	public float velocidadCorrer = 4f;
	public float Xsensibility = 1f;
	public float Ysensibility = 1f;
	
	[Header ("Variables")]
	public bool playerEscondido=false;
	public GameObject objetoInteraccion;
	ControlScene controlScene;
	Rigidbody rb;
	Vector2 wasdInp;
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	float distX;
	public float distY;
	float multipl = 0.15f;
	public int nameR = -3;
	bool tocado = false;
	float xAxisMouse = 0f;
	float yAxisMouse = 0f;

	// Use this for initialization
	void Awake () {
		//currentVida = vidaMax;
		rb = GetComponent<Rigidbody>();
		controlScene = GameObject.FindGameObjectWithTag("esceneManager").GetComponent<ControlScene>();
		botonInteraccion.SetActive(false);
		if(controlScene.PC){
			JB1.gameObject.SetActive(false);
		}
		visor.color = new Color32(255,255,255,90);
	}
	
	// Update is called once per frame
	void Update () {
		VisionRay();
		
			if(controlScene.PC){
				
				//Andar y Correr
				MovimientoAWSD();
				
				// Interactuar
				if(Input.GetMouseButtonDown(0)){
					FuncionBoton();
				}
				
				//Rotar Camara
				
				MouseRotacion();
			} else {  // Movil
				Movimiento();
				TouchControl();
			}
	}
	public void TouchControl(){
		Touch[] myTouches = Input.touches;
        for(int i = 0; i<Input.touchCount; i++){
			if((myTouches[i].position.y > Screen.height/3f && myTouches[i].position.x>Screen.width/2.5f)|| (myTouches[i].position.x>Screen.width/2.5f && myTouches[i].position.x<=Screen.width/1.6f)){
				nameR=myTouches[i].fingerId;
				tocado=true;
				controlScene.IDrottouch=nameR;
				if(nameR!=JB1.name1){
					switch(myTouches[i].phase){
						case TouchPhase.Began:
							
							//first
							firstPressPos = new Vector2(myTouches[i].position.x,myTouches[i].position.y);
							break;
					
						
					}				
				}//name
			} 
				if(myTouches[i].phase == TouchPhase.Moved && myTouches[i].fingerId==nameR && tocado){
							//Current
							secondPressPos = new Vector2(myTouches[i].position.x,myTouches[i].position.y);
							// Rotacion en X
							distX = firstPressPos.x-secondPressPos.x;
							playerPadre.Rotate(Vector3.up*distX*-multipl*sensibilidadJB2);	
						
							// Rotacion en Y
							distY= firstPressPos.y-secondPressPos.y;
				
							//Limitar angulo maximo y minimo
							if(pivoteCam.localRotation.x<0.40 && distY>0){
								pivoteCam.Rotate(Vector3.right*distY*multipl*sensibilidadJB2/1.6f); // Aspect ratio sensibility correction
							}
							if(pivoteCam.localRotation.x>-0.40 && distY<0){
								pivoteCam.Rotate(Vector3.right*distY*multipl*sensibilidadJB2/1.6f); // Aspect ratio sensibility correction
							}
							if(Vector3.Distance(myTouches[i].deltaPosition,Vector2.zero)<0.8f){
								firstPressPos = secondPressPos;
							}
				}
			if(myTouches[i].phase == TouchPhase.Ended && myTouches[i].fingerId==nameR && tocado){
						distX=0;
						distY=0;
						controlScene.IDrottouch=-1;
						tocado = false;
							
			}
        }	
	}
	private void VisionRay(){
		Vector3 fwd = InicioRayoVision.TransformDirection(Vector3.forward);
		RaycastHit hit = new RaycastHit();
		
		if(Physics.Raycast(InicioRayoVision.position,fwd,out hit)){
			
			if(hit.distance <= DistanciaVision && hit.collider.gameObject.tag=="accion"){
				if(!controlScene.PC){
					botonInteraccion.SetActive(true);
				}
				visor.color = new Color32(20,176,20,90);
				objetoInteraccion = hit.collider.gameObject;
				// Aqui hacer la llamada al boton
				
			} else {
				if(!controlScene.PC){
					botonInteraccion.SetActive(false);
				}
				visor.color = new Color32(255,255,255,90);
				objetoInteraccion = null;
			}
		}
	}
	public void FuncionBoton(){
		if(objetoInteraccion!=null){
			objetoInteraccion.GetComponent<RayAccion>().FuncionInteraccion();
		}
	}
	public void MovimientoAWSD(){
		//velocidadMov
		if(Input.GetKey(KeyCode.Space)){
			if(Input.GetKey(KeyCode.A)){
				this.transform.Translate(Vector3.right*-velocidadCorrer*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.D)){
				this.transform.Translate(Vector3.right*velocidadCorrer*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.W)){
				this.transform.Translate(Vector3.forward*velocidadCorrer*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.S)){
				this.transform.Translate(Vector3.forward*-velocidadCorrer*Time.deltaTime);
			}
		}else{
			if(Input.GetKey(KeyCode.A)){
				this.transform.Translate(Vector3.right*-velocidadMov*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.D)){
				this.transform.Translate(Vector3.right*velocidadMov*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.W)){
				this.transform.Translate(Vector3.forward*velocidadMov*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.S)){
				this.transform.Translate(Vector3.forward*-velocidadMov*Time.deltaTime);
			}	
		}
	}
	public void MouseRotacion(){
		xAxisMouse += Xsensibility*Input.GetAxis("Mouse X");
		yAxisMouse -= Ysensibility*Input.GetAxis("Mouse Y");
		
		CamaraPl.GetComponent<Transform>().eulerAngles = new Vector3(yAxisMouse,CamaraPl.GetComponent<Transform>().eulerAngles.y,0f);
		this.transform.eulerAngles = new Vector3(0f,xAxisMouse,0f);
		
	}
	
	public void Movimiento(){
		if (JB1.retval != Vector2.zero){
			//animPlayer.SetBool("Dance",false);
			wasdInp = new Vector2(JB1.retval.x,JB1.retval.y).normalized;
			
			if(wasdInp.y<0){  //Anda mas lento cuando va para atras
				this.transform.position += wasdInp.y * transform.forward * sensibilidadJB1*Mathf.Abs(wasdInp.y)*velocidadJoys/2f * Time.deltaTime;
			} else {
				this.transform.position += wasdInp.y * transform.forward * sensibilidadJB1*Mathf.Abs(wasdInp.y)*velocidadJoys * Time.deltaTime;
			}
			this.transform.position += wasdInp.x * transform.right *sensibilidadJB1* Mathf.Abs(wasdInp.x)*velocidadJoys/1.2f * Time.deltaTime;
				
			//animPlayer.SetFloat("Horizontal",wasdInp.x);
			//animPlayer.SetFloat("Vertical",wasdInp.y);
		} else{
				// Volver a Idle suavemente
				if(wasdInp.x<0){
					wasdInp.x=wasdInp.x+1.5f*Time.deltaTime;
				}
				if(wasdInp.x>0){
					wasdInp.x=wasdInp.x-1.5f*Time.deltaTime;
				}
				if(wasdInp.y<0){
					wasdInp.y=wasdInp.y+1.5f*Time.deltaTime;
				}
				if(wasdInp.y>0){
					wasdInp.y=wasdInp.y-1.5f*Time.deltaTime;
				}
				//animPlayer.SetFloat("Horizontal",wasdInp.x);
				//animPlayer.SetFloat("Vertical",wasdInp.y);	
		}
	}
	public void Rotacion(){
		
		if((Input.mousePosition.y > Screen.height / 3 && Input.mousePosition.x>=Screen.width/2.5) || (Input.mousePosition.x>=Screen.width/2.5 && Input.mousePosition.x<=Screen.width/1.6)){
		
			if(Input.GetMouseButtonDown(0)){
				//first
				firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			}
			if(Input.GetMouseButton(0)){
				//Current
				secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
				// Rotacion en X
				distX = firstPressPos.x-secondPressPos.x;
				playerPadre.Rotate(Vector3.up*distX*-multipl*sensibilidadJB2);	
				
				// Rotacion en Y
				distY= firstPressPos.y-secondPressPos.y;
				
				//Limitar angulo maximo y minimo
				if(pivoteCam.localRotation.x<0.40 && distY>0){
					pivoteCam.Rotate(Vector3.right*distY*multipl*sensibilidadJB2/1.6f); // Aspect ratio sensibility correction
				}
				if(pivoteCam.localRotation.x>-0.40 && distY<0){
					pivoteCam.Rotate(Vector3.right*distY*multipl*sensibilidadJB2/1.6f); // Aspect ratio sensibility correction
				}
				
			}
			if(Input.GetMouseButtonUp(0)){
				distX=0;
				distY=0;
			}	
		}
	}
	public void OnTriggerStay(Collider col){
		if(col.gameObject.tag=="aSalvo"){
			col.gameObject.GetComponent<Escondite>().ComprobarStado();
			playerEscondido = col.gameObject.GetComponent<Escondite>().aSalvoAvailable;
			
			// Hacer que si te pegas mas de x tiempo escondido, te encuentren
		}
	}
	public void OnTriggerExit(Collider col){
		if(col.gameObject.tag=="aSalvo"){
			playerEscondido=false;
		}
	}
}
