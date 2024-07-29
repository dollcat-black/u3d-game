using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easyCloth : MonoBehaviour
{

 public GameObject PlayerObject;
 public GameObject Bone1;
 public GameObject BoneEnd;
 public GameObject Bone2;
 public GameObject BoneEnd1;

 public float anglesZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bone1.GetComponent<Transform>().position=BoneEnd.GetComponent<Transform>().position;
        Bone2.GetComponent<Transform>().position=BoneEnd1.GetComponent<Transform>().position;
    float speed=PlayerObject.GetComponent<playermove>().movespeed;
anglesZ=transform.localEulerAngles.z;
    if(speed>0&&anglesZ<230)
    {
      transform.Rotate(0,0,1);
      Bone1.GetComponent<Transform>().Rotate(0,0,0.5f);
      Bone2.GetComponent<Transform>().Rotate(0,0,0.2f);
    }
   if(speed==0&&anglesZ>200)
   {
    transform.Rotate(0,0,-1);
     Bone1.GetComponent<Transform>().Rotate(0,0,-0.5f);
      Bone2.GetComponent<Transform>().Rotate(0,0,-0.2f);
   }

   
   
   
   
    }
}
