using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text1 : MonoBehaviour
{
      
    private float _rotationX = 0;
    public float sensitivityHor=3;
    public float jsensitivityHor=0.5f;
    public GameObject playerObject;
	// Use this for initialization

    public float starTime=0;
  
    public float delta;
    public int a=0;
    public Vector3 po1; 
    public float tpo=1;
    public Vector3 po2;
    public float l3;

    public Vector3 aaa;
    public float backspeed=1;
      public float maxDistant=2;

      public float a1;

      public float c=0;
	void Start () {
       
	}
	

	void Update () {
        
            
   /*   if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.Space))    
    {
        
        po1=playerObject.GetComponent<Transform>().position-transform.position;
        l3=po1.magnitude;
        po1=po1.normalized;
        aaa=playerObject.GetComponent<Rigidbody>().velocity;

        //transform.position+=po1*l3*l3/100;
       // l3=Mathf.Clamp(l3,0,maxDistant-0.04f);
         
       
       a1=Vector3.Dot(aaa,po1);
       if(a1<0&&l3>=maxDistant-0.04)
        {
            l3=maxDistant-0.1f;
        }
      /* a1=Vector3.Dot(aaa,po1);
      if(a1>0&&l3>=maxDistant-0.04f)
      {
        l3=po1.magnitude;
        } */
        //l3=Mathf.Clamp(l3,0,maxDistant);


     /*transform.GetComponent<Rigidbody>().velocity=po1*l3*l3/maxDistant;
    
    }
       else
       {

       po2=playerObject.GetComponent<Transform>().position-transform.position;
       l3=po2.magnitude;
       po2=po2.normalized;
       //l3=Mathf.Clamp(l3,0,maxDistant);
       //backspeed=backspeed*l3/maxDistant;
       transform.GetComponent<Rigidbody>().velocity=po2*l3*l3*backspeed;
       /*po1=po2.normalized;
        if(l3>0.005)
        {
       transform.position+=po1*l3/200;
       } 
       
       else
       {
        transform.position=playerObject.GetComponent<Transform>().position;
       }
       */
   //  }
transform.position=playerObject.GetComponent<Transform>().position;



if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow))
        {
            c=1;
            a=1;
             starTime=1;
             if(Input.GetKey(KeyCode.LeftArrow))
             {
                delta = -jsensitivityHor;
                c=1;
            a=1;
             starTime=1;
             }
               if(Input.GetKey(KeyCode.RightArrow))
             {
                delta = jsensitivityHor;
                c=1;
            a=2;
             starTime=1;
             }

        //float rotationY = transform.localEulerAngles.y + delta;
        transform.Rotate(0,delta,0);
       // transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            c=0;
        
        }

        



       
    if( Input.GetAxis("Mouse X")==0&&c==0)
        {
       
        
            float b=0;
            if(a==1)
            {
                b=-0.1f;
              
            }
            if(a==2)
            {
            b=0.1f;
               
            }
        starTime=starTime-2f*Time.deltaTime;
        delta=Mathf.Lerp(0,b* sensitivityHor,starTime);
float rotationY = transform.localEulerAngles.y + delta;
       transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
       
        }
        


        if(Input.GetAxis("Mouse X")>=0.05||Input.GetAxis("Mouse X")<=-0.05)
        {
        
            if(Input.GetAxis("Mouse X")<0)
            {
                a=1;
           

            }
            else
            {

                a=2;
              
            }
            starTime=1;
            delta = Input.GetAxis("Mouse X") * sensitivityHor;
        float rotationY = transform.localEulerAngles.y + Mathf.Clamp(delta,-5,5);
        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    
        }
        
        


        /*transform.position=playerObject.GetComponent<Transform>().position;
        float delta = Input.GetAxis("Mouse X") * sensitivityHor;
        float rotationY = transform.localEulerAngles.y + delta;
        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
          */   
            
        
    }
}


