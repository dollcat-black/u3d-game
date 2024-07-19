using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camVibrate : MonoBehaviour
{
    // Start is called before the first frame update
public GameObject campo;
    public float camVibrateSet=5;
    public float camV=5.0f;

    public bool isCamVibrate=false;

     public GameObject playerObject;  //角色

     public bool run;

     public float zoomMax=100f;
public float zoomMin=50;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.F))
     {
        isCamVibrate=true;
     }
     else
     {
    isCamVibrate=false;
     }
       if(isCamVibrate==true)
     {
        
       transform.position=new Vector3(Random.Range(0,2*camV)-camV+campo.GetComponent<Transform>().position.x,
         Random.Range(0,1*camV)-camV+campo.GetComponent<Transform>().position.y,
         Random.Range(0,2*camV)-camV+campo.GetComponent<Transform>().position.z);
       camV=camV/2;

       if(camV<=0.01)
       {
        camV=camV=camVibrateSet;
       }
     }
     else
     {
    
    if(camV>0.01)
    {
transform.position=new Vector3(Random.Range(0,2*camV)-camV+campo.GetComponent<Transform>().position.x,
         Random.Range(0,1*camV)-camV+campo.GetComponent<Transform>().position.y,
         Random.Range(0,2*camV)-camV+campo.GetComponent<Transform>().position.z);
       camV=camV/1.2f;

    }
    else
    {
      transform.position=campo.GetComponent<Transform>().position;
    }

     }



run=playerObject.GetComponent<playermove>().run;

if(run||(Input.GetKey(KeyCode.LeftShift)&&(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D))))
{
    
    GetComponent<Camera>().fieldOfView+=1f;
   

}
else
{
  GetComponent<Camera>().fieldOfView-=1f;
  
}
 GetComponent<Camera>().fieldOfView=Mathf.Clamp(GetComponent<Camera>().fieldOfView,zoomMin,zoomMax);
     
        
    }
}
