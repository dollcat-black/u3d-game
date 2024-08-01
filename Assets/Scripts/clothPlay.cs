using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class clothPlay : MonoBehaviour
{

    public GameObject bone1;
    public GameObject bone2;

    public float speedZ=0;
    public float force=10;

    public Vector3 startPoint1;

    public float currz;

    public Vector3 endPoint;

    public Vector3 Pointforce;

    public float z;

    public float y;


    // Start is called before the first frame update
    void Start()
    {
        startPoint1=bone1.GetComponent<Transform>().localPosition;
        endPoint=transform.position;
        currz=startPoint1.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
   speedZ=transform.position.z-endPoint.z;
   if(speedZ!=0)
   {
    endPoint=transform.position;
   bone1.GetComponent<Transform>().localPosition=new Vector3(startPoint1.x,startPoint1.y+Mathf.Abs(speedZ)*force,
   startPoint1.z-speedZ*force);
   currz=bone1.GetComponent<Transform>().localPosition.z;
   }

   if(speedZ==0){
      z=currz-startPoint1.z;
        y=bone1.GetComponent<Transform>().localPosition.y-startPoint1.y;
       
    
   bone1.GetComponent<Transform>().localPosition=new Vector3(startPoint1.x,startPoint1.y+0.1f,
   startPoint1.z+z);
   if(z>0.1f)
   {
   currz=currz-0.1f;
   }

   if(z<-0.1f)
   {
   currz=currz+0.1f;
   }


   }
   


    }
}
