using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class easyCloth : MonoBehaviour
{

 //public GameObject PlayerObject;
 public GameObject Bone1;
 public GameObject BoneEnd;
 public GameObject Bone2;
 public GameObject BoneEnd1;

public GameObject BoneEnd2;
 public float BoneAnglesZ;
 public float BoneAnglesX;
  public float BoneAnglesY;
  public float Bone1AnglesZ;
   public float Bone1AnglesX;
    public float Bone1AnglesY;
  public float Bone2AnglesZ;
   public float Bone2AnglesX;
    public float Bone2AnglesY;

  public float gravity=0.05f;
  public float force=20;

  public float BoneSpeedX=0;
  public float BoneSpeedY=0;
  public float BoneSpeedZ=0;

   public float Bone1SpeedX=0;
  public float Bone1SpeedY=0;
  public float Bone1SpeedZ=0;

  public float Bone2SpeedX=0;
  public float Bone2SpeedY=0;
  public float Bone2SpeedZ=0;

  //public Vector3 BonePosStart;

  public Vector3 BonePosEnd;
   public Vector3 Bone1PosEnd;
    public Vector3 Bone2PosEnd;

    public float maxAngles=50;
  
    // Start is called before the first frame update
    void Start()
    {
        BonePosEnd=transform.position;
          Bone1PosEnd=Bone1.GetComponent<Transform>().position;
          Bone2PosEnd=Bone2.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
//骨骼1位置与根骨骼末端保持一致
        Bone1.GetComponent<Transform>().position=BoneEnd.GetComponent<Transform>().position;
//骨骼2位置与骨骼1末端保持一致
        Bone2.GetComponent<Transform>().position=BoneEnd1.GetComponent<Transform>().position;
    /*float speed=PlayerObject.GetComponent<playermove>().movespeed;
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
*/
//获取根骨骼旋转角度 
   BoneAnglesZ=transform.localEulerAngles.z;
   BoneAnglesX=transform.localEulerAngles.x;
   BoneAnglesY=transform.localEulerAngles.y;
//获取骨骼1旋转角度 
   Bone1AnglesZ=Bone1.GetComponent<Transform>().localEulerAngles.z;
   Bone1AnglesX=Bone1.GetComponent<Transform>().localEulerAngles.x;
   Bone1AnglesY=Bone1.GetComponent<Transform>().localEulerAngles.y;
//获取骨骼2旋转角度 
   Bone2AnglesZ=Bone2.GetComponent<Transform>().localEulerAngles.z;
   Bone2AnglesX=Bone2.GetComponent<Transform>().localEulerAngles.x;
   Bone2AnglesY=Bone2.GetComponent<Transform>().localEulerAngles.y;

  //根骨骼重置旋转角度（确保正反向旋转为正负数） 
   if(BoneAnglesZ>180)
   {
    BoneAnglesZ=BoneAnglesZ-360;
   }
if(BoneAnglesX>180)
   {
    BoneAnglesX=BoneAnglesX-360;
   }
   if(BoneAnglesY>180)
   {
    BoneAnglesY=BoneAnglesY-360;
   }

  //骨骼1重置旋转角度（确保正反向旋转为正负数） 
   if(Bone1AnglesZ>180)
   {
    Bone1AnglesZ=Bone1AnglesZ-360;
   }

  if(Bone1AnglesX>180)
   {
    Bone1AnglesX=Bone1AnglesX-360;
   }
   if(Bone1AnglesY>180)
   {
    Bone1AnglesY=Bone1AnglesY-360;
   }

  //骨骼2重置旋转角度（确保正反向旋转为正负数） 
    if(Bone2AnglesZ>180)
   {
    Bone2AnglesZ=Bone2AnglesZ-360;
   }
    if(Bone2AnglesX>180)
   {
    Bone2AnglesX=Bone2AnglesX-360;
   }
   if(Bone2AnglesY>180)
   {
    Bone2AnglesY=Bone2AnglesY-360;
   }

//根骨骼受重力自动向下旋转
  if(BoneAnglesZ>0.1f||BoneAnglesZ<-0.1f)
{
    transform.Rotate(0,0,-BoneAnglesZ*gravity);
}

 if(BoneAnglesX>0.1f||BoneAnglesX<-0.1f)
{
    transform.Rotate(-BoneAnglesX*gravity,0,0);
}

/* if(BoneAnglesY>0.1f||BoneAnglesY<-0.1f)
{
    transform.Rotate(0,-BoneAnglesY*gravity,0);
}
*/
//骨骼1点受重力自动向下旋转
if(Bone1AnglesZ>0.1f||Bone1AnglesZ<-0.1f)
{
    Bone1.GetComponent<Transform>().Rotate(0,0,-Bone1AnglesZ*gravity);
}
if(Bone1AnglesX>0.1f||Bone1AnglesX<-0.1f)
{
    Bone1.GetComponent<Transform>().Rotate(-Bone1AnglesX*gravity,0,0);
}

 /*if(Bone1AnglesY>0.1f||Bone1AnglesY<-0.1f)
{
    Bone1.GetComponent<Transform>().Rotate(0,-Bone1AnglesY*gravity,0);
}
*/

//骨骼2点受重力自动向下旋转
if(Bone2AnglesZ>0.1f||Bone2AnglesZ<-0.1f)
{
    Bone2.GetComponent<Transform>().Rotate(0,0,-Bone2AnglesZ*gravity);
}
if(Bone2AnglesX>0.1f||Bone2AnglesX<-0.1f)
{
    Bone2.GetComponent<Transform>().Rotate(-Bone2AnglesX*gravity,0,0);
}

/* if(Bone2AnglesY>0.1f||Bone2AnglesY<-0.1f)
{
    Bone2.GetComponent<Transform>().Rotate(0,-Bone2AnglesY*gravity,0);
}
*/

//计算根骨骼移动速度对根骨骼旋转的影响程度（根骨骼末端（骨骼1）受到根骨骼拉扯的惯性位移）
   BoneSpeedX=transform.position.x-BonePosEnd.x;
      BoneSpeedY=transform.position.y-BonePosEnd.y;
       BoneSpeedZ=transform.position.z-BonePosEnd.z;
   if(BoneSpeedX!=0||BoneSpeedY!=0||BoneSpeedZ!=0)
   {
    BonePosEnd=transform.position;
   }
 transform.Rotate(BoneSpeedZ*force,0,-BoneSpeedX*force);

//计算骨骼1移动速度对骨骼1旋转的影响程度（骨骼1末端（骨骼2）受到骨骼1拉扯的惯性位移）
  Bone1SpeedX=Bone1.GetComponent<Transform>().position.x-Bone1PosEnd.x;
      Bone1SpeedY=Bone1.GetComponent<Transform>().position.y-Bone1PosEnd.y;
       Bone1SpeedZ=Bone1.GetComponent<Transform>().position.z-Bone1PosEnd.z;
   if(Bone1SpeedX!=0||Bone1SpeedY!=0||Bone1SpeedZ!=0)
   {
    Bone1PosEnd=Bone1.GetComponent<Transform>().position;
   }
 Bone1.GetComponent<Transform>().Rotate(Bone1SpeedZ*force,0,-Bone1SpeedX*force);
 
 //计算骨骼1移动速度对骨骼1旋转的影响程度（骨骼1末端（骨骼2）受到骨骼1拉扯的惯性位移）
  Bone2SpeedX=Bone2.GetComponent<Transform>().position.x-Bone2PosEnd.x;
      Bone2SpeedY=Bone2.GetComponent<Transform>().position.y-Bone2PosEnd.y;
       Bone2SpeedZ=Bone2.GetComponent<Transform>().position.z-Bone2PosEnd.z;
   if(Bone2SpeedX!=0||Bone2SpeedY!=0||Bone2SpeedZ!=0)
   {
    Bone2PosEnd=Bone2.GetComponent<Transform>().position;
   }
 Bone2.GetComponent<Transform>().Rotate(Bone2SpeedZ*force,0,-Bone2SpeedX*force);


//限制根骨骼旋转角度
if(transform.localEulerAngles.x>maxAngles&&transform.localEulerAngles.x<180)
{
    transform.localEulerAngles=new Vector3(maxAngles,transform.localEulerAngles.y,transform.localEulerAngles.z);
}

if(transform.localEulerAngles.x<360-maxAngles&&transform.localEulerAngles.x>180)
{
    transform.localEulerAngles=new Vector3(360-maxAngles,transform.localEulerAngles.y,transform.localEulerAngles.z);
}

/*if(transform.localEulerAngles.y>maxAngles&&transform.localEulerAngles.y<180)
{
    transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,maxAngles,transform.localEulerAngles.z);
}

if(transform.localEulerAngles.y<360-maxAngles&&transform.localEulerAngles.y>180)
{
    transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,360-maxAngles,transform.localEulerAngles.z);
}
*/
if(transform.localEulerAngles.z>maxAngles&&transform.localEulerAngles.z<180)
{
    transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,maxAngles);
}

if(transform.localEulerAngles.z<360-maxAngles&&transform.localEulerAngles.z>180)
{
    transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,360-maxAngles);
}


//限制骨骼1旋转角度
if(Bone1.GetComponent<Transform>().localEulerAngles.x>maxAngles&&
Bone1.GetComponent<Transform>().localEulerAngles.x<180)
{
    Bone1.GetComponent<Transform>().localEulerAngles=new Vector3(maxAngles,
    Bone1.GetComponent<Transform>().localEulerAngles.y,
    Bone1.GetComponent<Transform>().localEulerAngles.z);
}

if(Bone1.GetComponent<Transform>().localEulerAngles.x<360-maxAngles&&
Bone1.GetComponent<Transform>().localEulerAngles.x>180)
{
    Bone1.GetComponent<Transform>().localEulerAngles=new Vector3(360-maxAngles,
    Bone1.GetComponent<Transform>().localEulerAngles.y,
    Bone1.GetComponent<Transform>().localEulerAngles.z);
}

/*if(Bone1.GetComponent<Transform>().localEulerAngles.y>maxAngles&&
Bone1.GetComponent<Transform>().localEulerAngles.y<180)
{
    Bone1.GetComponent<Transform>().localEulerAngles=new Vector3(Bone1.GetComponent<Transform>().localEulerAngles.x,
    maxAngles,
    Bone1.GetComponent<Transform>().localEulerAngles.z);
}

if(Bone1.GetComponent<Transform>().localEulerAngles.y<360-maxAngles&&
Bone1.GetComponent<Transform>().localEulerAngles.y>180)
{
    Bone1.GetComponent<Transform>().localEulerAngles=new Vector3(Bone1.GetComponent<Transform>().localEulerAngles.x,
    360-maxAngles,
    Bone1.GetComponent<Transform>().localEulerAngles.z);
}
*/
if(Bone1.GetComponent<Transform>().localEulerAngles.z>maxAngles&&
Bone1.GetComponent<Transform>().localEulerAngles.z<180)
{
    Bone1.GetComponent<Transform>().localEulerAngles=new Vector3(Bone1.GetComponent<Transform>().localEulerAngles.x,
    Bone1.GetComponent<Transform>().localEulerAngles.y,
    maxAngles);
}

if(Bone1.GetComponent<Transform>().localEulerAngles.z<360-maxAngles&&
Bone1.GetComponent<Transform>().localEulerAngles.z>180)
{
    Bone1.GetComponent<Transform>().localEulerAngles=new Vector3(Bone1.GetComponent<Transform>().localEulerAngles.x,
    Bone1.GetComponent<Transform>().localEulerAngles.y,
    360-maxAngles);
}

//限制骨骼2旋转角度
 if(Bone2.GetComponent<Transform>().localEulerAngles.x>maxAngles&&
Bone2.GetComponent<Transform>().localEulerAngles.x<180)
{
    Bone2.GetComponent<Transform>().localEulerAngles=new Vector3(maxAngles,
    Bone2.GetComponent<Transform>().localEulerAngles.y,
    Bone2.GetComponent<Transform>().localEulerAngles.z);
}

if(Bone2.GetComponent<Transform>().localEulerAngles.x<360-maxAngles&&
Bone2.GetComponent<Transform>().localEulerAngles.x>180)
{
    Bone2.GetComponent<Transform>().localEulerAngles=new Vector3(360-maxAngles,
    Bone2.GetComponent<Transform>().localEulerAngles.y,
    Bone2.GetComponent<Transform>().localEulerAngles.z);
}

/*if(Bone2.GetComponent<Transform>().localEulerAngles.y>maxAngles&&
Bone2.GetComponent<Transform>().localEulerAngles.y<180)
{
    Bone2.GetComponent<Transform>().localEulerAngles=new Vector3(Bone2.GetComponent<Transform>().localEulerAngles.x,
    maxAngles,
    Bone2.GetComponent<Transform>().localEulerAngles.z);
}

if(Bone2.GetComponent<Transform>().localEulerAngles.y<360-maxAngles&&
Bone2.GetComponent<Transform>().localEulerAngles.y>180)
{
    Bone2.GetComponent<Transform>().localEulerAngles=new Vector3(Bone2.GetComponent<Transform>().localEulerAngles.x,
    360-maxAngles,
    Bone2.GetComponent<Transform>().localEulerAngles.z);
}
*/
if(Bone2.GetComponent<Transform>().localEulerAngles.z>maxAngles&&
Bone2.GetComponent<Transform>().localEulerAngles.z<180)
{
    Bone2.GetComponent<Transform>().localEulerAngles=new Vector3(Bone2.GetComponent<Transform>().localEulerAngles.x,
    Bone2.GetComponent<Transform>().localEulerAngles.y,
    maxAngles);
}

if(Bone2.GetComponent<Transform>().localEulerAngles.z<360-maxAngles&&
Bone2.GetComponent<Transform>().localEulerAngles.z>180)
{
    Bone2.GetComponent<Transform>().localEulerAngles=new Vector3(Bone2.GetComponent<Transform>().localEulerAngles.x,
    Bone2.GetComponent<Transform>().localEulerAngles.y,
    360-maxAngles);
}
 
Bone1.GetComponent<Transform>().localEulerAngles=new Vector3(Bone1.GetComponent<Transform>().localEulerAngles.x,
transform.localEulerAngles.y,
Bone1.GetComponent<Transform>().localEulerAngles.z);

Bone2.GetComponent<Transform>().localEulerAngles=new Vector3(Bone2.GetComponent<Transform>().localEulerAngles.x,
transform.localEulerAngles.y,
Bone2.GetComponent<Transform>().localEulerAngles.z);

   
   
    }
}
