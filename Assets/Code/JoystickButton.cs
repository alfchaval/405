using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickButton : MonoBehaviour {
	public GameObject palanca;
    public float rango;
    //Vector3 centro;
    public bool activo = false;
    public Vector2 retval;
	public bool PC = false;
	ControlScene controlScene;
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	public int name1=-1;
	int name2=-1;
	bool aMovido=false;
	
	// Use this for initialization
	void Awake ()
    {
		controlScene = GameObject.FindGameObjectWithTag("esceneManager").GetComponent<ControlScene>();
        //centro = transform.position;
		centra();
		name1=-1;
	}
	

	void Update ()
    {
		if(!controlScene.PC){
			TouchCheck();
		}else{
			MouseCheck();
		}
        
        
	}
	void TouchCheck()
    {
		Touch[] myTouches = Input.touches;
        for(int i = 0; i<Input.touchCount; i++){
			if(myTouches[i].position.x<Screen.width/3f && myTouches[i].position.y<Screen.height/1.5f){
				name1=myTouches[i].fingerId;
				if(name1!=controlScene.IDrottouch){
				
					if(myTouches[i].phase == TouchPhase.Began){
						firstPressPos = new Vector2(myTouches[i].position.x,myTouches[i].position.y);
						palanca.transform.position = new Vector3(firstPressPos.x,firstPressPos.y,0f);
						aMovido=true;
					}
					
				
					/*if(myTouches[i].phase == TouchPhase.Ended){
						centra();
						//activo = false;			
					} 
					retval = new Vector2(secondPressPos.x-firstPressPos.x,secondPressPos.y-firstPressPos.y);
					//retval = new Vector2(palanca.transform.localPosition.x, palanca.transform.localPosition.y);*/
				} 
			}
			
			if(myTouches[i].phase == TouchPhase.Moved){
				name2 =myTouches[i].fingerId;
				if(name1==name2){
						secondPressPos = new Vector2(myTouches[i].position.x,myTouches[i].position.y);
						if(aMovido){
							palanca.transform.position = new Vector3(secondPressPos.x,secondPressPos.y,0f);//-new Vector3(firstPressPos.x,firstPressPos.y,0f);
							retval = new Vector2(secondPressPos.x-firstPressPos.x,secondPressPos.y-firstPressPos.y);
						}else{
							retval = new Vector2(0f,0f);
						}
					}
			}
			if(myTouches[i].phase == TouchPhase.Ended){
				name2 =myTouches[i].fingerId;
				if(name1==name2){
					if(myTouches[i].phase== TouchPhase.Ended){
						centra();
						name1=-1;
					}
				}
			}
			
		}
		
		
	}
	void MouseCheck(){

			if(Input.GetMouseButton(0)){
				float angl;
				if (Vector3.Distance(Input.mousePosition, transform.position) < rango)
				{
					palanca.transform.localPosition = Input.mousePosition - transform.position;
					activo = true;
				}
				else
				{
					if (activo == false)
					{
						centra();
						retval = Vector2.zero;
					}
					else
					{
						angl = 180*Mathf.Deg2Rad+ Mathf.Atan2(transform.position.y - Input.mousePosition.y, transform.position.x - Input.mousePosition.x);
						palanca.transform.localPosition = new Vector3(rango*Mathf.Cos(angl), rango * Mathf.Sin(angl),0);
					}                
				}
			
			}
			if(Input.GetMouseButtonUp(0)){
				centra();
				activo = false;
				retval = Vector2.zero;
			}			
			
			retval = new Vector2(palanca.transform.localPosition.x, palanca.transform.localPosition.y);
		
		
	}

    void centra()
    {
        palanca.transform.localPosition = Vector3.zero;
		retval = new Vector2(0f,0f);
    }

}
