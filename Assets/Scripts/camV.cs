using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Converters;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class camV : MonoBehaviour
{
    // Start is called before the first frame update
  
    public float sensitivityVert = 9.0f;
public float jsensitivityHor=0.5f;
    public float minimumVert = -80.0f;
    public float maximumVert = 80.0f;
public float starTime=0;
    public float rotationX = 0;
    
    public float jd=0;

    public float jd1=2;

    public float ll=0;
   public float z=0;
public float t=1;
public float t1=1;

public float zoomTimeNear=0;

public float zoomTimeFar=0;
   public GameObject center;  //镜头中心

   public GameObject centerY;
   
   public GameObject look;  //看向物体

   public GameObject playerObject;

   public GameObject campo1;

   public GameObject cube1;

   public Vector3 lookX=Vector3.zero; //镜头-看向物体向量
   public Vector3 lookY=Vector3.zero;//镜头-看向物体向量

public float minCamDistant=2;//镜头与角色最小距离
public float maxCamDistant=5; //镜头与角色最大距离
   public float currentX=0; //镜头看向方向x轴夹角

   public float currentX1=0;

   public float currentXX=0;

   public Vector3 lookcen=Vector3.zero;//镜头-物体向量Y轴旋转至镜头看向方向同一平面向量
   public Vector3 cam1=Vector3.zero; //镜头看向方向在xz平面的向量
   public float lookRotateY=0;//镜头-物体向量与镜头看向方向Y轴夹角
   public Vector3 lookc=Vector3.zero;  //镜头看向方向向量

   public float lookSpeed=1; //看向物体速度系数

   public float jj=0;  //镜头看向方向在X轴方向的角度
   public float jz=0;  //镜头-物体向量Y轴旋转至镜头看向方向同一平面在X轴方向的角度

   public float jk=0;  //镜头-物体向量与镜头看向方向向量的角度


   public float hg=5;

  public int c=0;

 private Playeraction controls;
   public float lockb=0;
public Vector2 move=Vector2.zero;
public Vector2 arrow=Vector2.zero;

   public float x1=0;
   public float y1=0;

      public float x2=0;
   public float y2=0;
   
   public Vector3 hfix=Vector3.zero;

   public Vector3 hitpos=Vector3.zero;

   public float camhitL=10;

   public float runspeed;

void Awake()
    {
        controls= new Playeraction();
       // controls.GamePlay.Attack.performed += ctx =>Attack();
        controls.GamePlay.Lock.performed += ctx =>lockb=ctx.ReadValue<float>();
        controls.GamePlay.Lock.canceled += ctx =>lockb=0;

         controls.GamePlay.move.performed += ctx =>move=ctx.ReadValue<Vector2>();
        controls.GamePlay.move.canceled += ctx =>move=Vector2.zero;

        controls.GamePlay.Arrow.performed += ctx =>arrow=ctx.ReadValue<Vector2>();
        controls.GamePlay.Arrow.canceled += ctx =>arrow=Vector2.zero;

         
    }

void OnEnable()
    {
      
        controls.GamePlay.Enable();
    }

    void OnDisable()
    {
      
        controls.GamePlay.Disable();
    }
 
    void Start()
    {
       Rigidbody body = GetComponent<Rigidbody>();
        if(body != null)
        {
            body.freezeRotation = true;
           
        }

        
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
   x1=move.x;
   y1=move.y;
    x2=arrow.x;
   y2=arrow.y;
    
        if(Input.GetKeyDown(KeyCode.Escape))//设置按ESC锁定隐藏光标
        {
         
          if(Cursor.lockState == CursorLockMode.Locked)
         { Cursor.lockState = CursorLockMode.None;
         Cursor.visible=true;
         }
          else{Cursor.lockState = CursorLockMode.Locked;
          Cursor.visible=false;
          }
          
        }

runspeed=playerObject.GetComponent<playermove>().runSpeed;
//镜头平滑
if((Input.GetAxis("Mouse X")>0&&!Input.GetKey(KeyCode.E)&&runspeed>0)||(x2>0&&lockb==0&&runspeed>0))
{
    z=z+50f*Time.deltaTime;
    t=t1;
    

}
if(Input.GetAxis("Mouse X")==0&&x2==0&&z>0)
{


    t=t-1*Time.deltaTime;
    if(t<=0)
    {
 z=z-10f*Time.deltaTime;
 t=0;
    }
    
}

if((Input.GetAxis("Mouse X")<0&&!Input.GetKey(KeyCode.E)&&runspeed>0)||(x2<0&&lockb==0&&runspeed>0))

{
     z=z-50f*Time.deltaTime;
     t=t1;
     
     
    }
if(Input.GetAxis("Mouse X")==0&&x2==0&&z<0)
{

    t=t-1*Time.deltaTime;
    if(t<=0)
    {
 z=z+10f*Time.deltaTime;
 t=0;
    }
  
}
z=Mathf.Clamp(z,-hg,hg);
float rotationX1=centerY.GetComponent<Transform>().localEulerAngles.x;
float rotationY = centerY.GetComponent<Transform>().localEulerAngles.y;
centerY.GetComponent<Transform>().localEulerAngles = new Vector3(rotationX1, rotationY, z);

/*if((Input.GetAxis("Mouse X")>0&&!Input.GetKey(KeyCode.E))||(Input.GetKey(KeyCode.RightArrow)&&!Input.GetKey(KeyCode.E))||(Input.GetKey(KeyCode.D)&&Input.GetKey(KeyCode.E)))
{
    z=z+50f*Time.deltaTime;
    t=t1;
    

}
if(Input.GetAxis("Mouse X")==0&&(!(Input.GetKey(KeyCode.E)&&Input.GetKey(KeyCode.A))||!(Input.GetKey(KeyCode.E)&&Input.GetKey(KeyCode.D)))&&z>0)
{


    t=t-1*Time.deltaTime;
    if(t<=0)
    {
 z=z-10f*Time.deltaTime;
 t=0;
    }
    
}

if((Input.GetAxis("Mouse X")<0&&!Input.GetKey(KeyCode.E))||(Input.GetKey(KeyCode.LeftArrow)&&!Input.GetKey(KeyCode.E))||(Input.GetKey(KeyCode.A)&&Input.GetKey(KeyCode.E)))

{
     z=z-50f*Time.deltaTime;
     t=t1;
     
     
    }
if(Input.GetAxis("Mouse X")==0&&(!(Input.GetKey(KeyCode.E)&&Input.GetKey(KeyCode.A))||!(Input.GetKey(KeyCode.E)&&Input.GetKey(KeyCode.D)))&&z<0)
{

    t=t-1*Time.deltaTime;
    if(t<=0)
    {
 z=z+10f*Time.deltaTime;
 t=0;
    }
  
}
z=Mathf.Clamp(z,-hg,hg);
float rotationX1=centerY.GetComponent<Transform>().localEulerAngles.x;
float rotationY = centerY.GetComponent<Transform>().localEulerAngles.y;
centerY.GetComponent<Transform>().localEulerAngles = new Vector3(rotationX1, rotationY, z);
*/


//Vector3 distant=center.GetComponent<Transform>().position-transform.position;
//float l=distant.magnitude;
//distant=distant.normalized;
//滚轮控制镜头距离
if(Input.GetAxis("Mouse ScrollWheel")>0)
{
    zoomTimeFar=0;
    zoomTimeNear=1;
   
}

if(Input.GetAxis("Mouse ScrollWheel")<0)
{
    zoomTimeFar=1;
    zoomTimeNear=0;
   
}



if(zoomTimeNear>0)
{
    zoomTimeNear=zoomTimeNear-2*Time.deltaTime;
    Vector3 distant=center.GetComponent<Transform>().position+hfix-transform.position;
float l=distant.magnitude;
if(l>minCamDistant){
distant=distant.normalized;
    transform.position=transform.position+distant*2*zoomTimeNear*Time.deltaTime;}
   campo1.GetComponent<Transform>().position=transform.position;
}

if(zoomTimeFar>0)
{
    zoomTimeFar=zoomTimeFar-2*Time.deltaTime;
    Vector3 distant=center.GetComponent<Transform>().position+hfix-transform.position;
float l=distant.magnitude;
if(l<maxCamDistant){
    distant=distant.normalized;
    transform.position=transform.position-distant*2*zoomTimeFar*Time.deltaTime;
 campo1.GetComponent<Transform>().position=transform.position;
}
    }



       
            
            //both horizontal and vertical rotation here
            /*_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
           _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert); //限制视角上下限
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            */
           // float _rotationX=transform.localEulerAngles.x;
            //float rotationY = transform.localEulerAngles.y;
            //transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            //判断镜头看向方向在x轴的夹角
        
           currentX1=centerY.GetComponent<Transform>().localEulerAngles.x;
             if(currentX1>maximumVert+10)
            {
          currentX1=currentX1-360;                
            }
            currentX=transform.localEulerAngles.x;
            if(currentX>maximumVert+10)
            {
          currentX=currentX-360;                
            }
            
            currentXX=currentX+currentX1;
            //鼠标纵向旋转视角
          if((Input.GetAxis("Mouse Y")>0&&!Input.GetMouseButton(0))||(y2>0.1f&&lockb==0))
           {
            if(currentX1>minimumVert&&currentX1<maximumVert+5){
            float rotationX=centerY.GetComponent<Transform>().localEulerAngles.x;
            rotationX -= Mathf.Clamp((Input.GetAxis("Mouse Y")+y2)* sensitivityVert,-2,2);
          starTime=0.1f;
           c=1;
            //rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert); //限制视角上下限
           float rotationY1 = centerY.GetComponent<Transform>().localEulerAngles.y;
           float rotationZ = centerY.GetComponent<Transform>().localEulerAngles.z;
          
           centerY.GetComponent<Transform>().localEulerAngles = new Vector3(rotationX, rotationY1, rotationZ);
            }

           }
           
  //鼠标纵向旋转视角
            if((Input.GetAxis("Mouse Y")<0&&!Input.GetMouseButton(0))||(y2<-0.1f&&lockb==0))
           {
            if(currentX1>minimumVert-5&&currentX1<maximumVert)
            {
           float rotationX=centerY.GetComponent<Transform>().localEulerAngles.x;
            rotationX -= Mathf.Clamp((Input.GetAxis("Mouse Y")+y2) * sensitivityVert,-2,2);
          starTime=0.1f;
           c=-1;
           //rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);
           float rotationY1 = centerY.GetComponent<Transform>().localEulerAngles.y;
           float rotationZ = centerY.GetComponent<Transform>().localEulerAngles.z;
           centerY.GetComponent<Transform>().localEulerAngles = new Vector3(rotationX, rotationY1, rotationZ);
           }
           }

         
         
         
         /*if(Input.GetAxis("Mouse Y")>0&&!Input.GetMouseButton(0))
           {
            if(currentX1>minimumVert&&currentX1<maximumVert+5){
            float rotationX=centerY.GetComponent<Transform>().localEulerAngles.x;
            rotationX -= Mathf.Clamp(Input.GetAxis("Mouse Y") * sensitivityVert,-2,2);
          starTime=0.1f;
           c=1;
            //rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert); //限制视角上下限
           float rotationY1 = centerY.GetComponent<Transform>().localEulerAngles.y;
           float rotationZ = centerY.GetComponent<Transform>().localEulerAngles.z;
          
           centerY.GetComponent<Transform>().localEulerAngles = new Vector3(rotationX, rotationY1, rotationZ);
            }

           }
           
  //鼠标纵向旋转视角
            if(Input.GetAxis("Mouse Y")<0&&!Input.GetMouseButton(0))
           {
            if(currentX1>minimumVert-5&&currentX1<maximumVert)
            {
           float rotationX=centerY.GetComponent<Transform>().localEulerAngles.x;
            rotationX -= Mathf.Clamp(Input.GetAxis("Mouse Y") * sensitivityVert,-2,2);
          starTime=0.1f;
           c=-1;
           //rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);
           float rotationY1 = centerY.GetComponent<Transform>().localEulerAngles.y;
           float rotationZ = centerY.GetComponent<Transform>().localEulerAngles.z;
           centerY.GetComponent<Transform>().localEulerAngles = new Vector3(rotationX, rotationY1, rotationZ);
           }
           }*/
//鼠标射击控制视角
     if(Input.GetAxis("Mouse Y")>0&&Input.GetMouseButton(0))
           {
            if(currentX1>minimumVert&&currentX1<maximumVert+5){
            float rotationX=transform.localEulerAngles.x;
            rotationX -= Mathf.Clamp(Input.GetAxis("Mouse Y") * sensitivityVert,-2,2);
          starTime=0.1f;
           c=1;
            //rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert); //限制视角上下限
           float rotationY1 = transform.localEulerAngles.y;
           float rotationZ = transform.localEulerAngles.z;
          
           transform.localEulerAngles = new Vector3(rotationX, rotationY1, rotationZ);
            }

           }
  
//鼠标射击控制视角
            if(Input.GetAxis("Mouse Y")<0&&Input.GetMouseButton(0))
           {
            if(currentX1>minimumVert-5&&currentX1<maximumVert)
            {
           float rotationX=transform.localEulerAngles.x;
            rotationX -= Mathf.Clamp(Input.GetAxis("Mouse Y") * sensitivityVert,-2,2);
          starTime=0.1f;
           c=-1;
           //rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);
           float rotationY1 = transform.localEulerAngles.y;
           float rotationZ = transform.localEulerAngles.z;
           transform.localEulerAngles = new Vector3(rotationX, rotationY1, rotationZ);
           }
           }
       
       /*  
     //键盘纵向旋转视角
           if(Input.GetKey(KeyCode.UpArrow)&&!Input.GetKey(KeyCode.E))
           {
            
            if(currentX>minimumVert&&currentX<maximumVert+5)
          {
          transform.Rotate(-jsensitivityHor,0,0);
         //starTime=0.1f;
         c=1;
          }

           }
   //键盘纵向旋转视角
           if(Input.GetKey(KeyCode.DownArrow)&&!Input.GetKey(KeyCode.E))
           {
          
            if(currentX>minimumVert-5&&currentX<maximumVert) 
          {
          transform.Rotate(jsensitivityHor,0,0);
          c=-1;
          //starTime=0.1f;
           }
           }
*/
 


           //停止移动视角后镜头平滑移动
  //if(Input.GetAxis("Mouse Y")==0&&!Input.GetKey(KeyCode.DownArrow)&&!Input.GetKey(KeyCode.UpArrow)&&starTime>0&&c!=0&&!Input.GetKey(KeyCode.E))
    /*if(Input.GetAxis("Mouse Y")==0&&Input.GetKey(KeyCode.DownArrow)&&Input.GetKey(KeyCode.UpArrow)&&starTime>0&&c!=0&&!Input.GetKey(KeyCode.E)&&!Input.GetMouseButton(0))
       {
          starTime=starTime-0.1f*Time.deltaTime;
          rotationX=rotationX-Mathf.Lerp(0, c*jsensitivityHor,starTime);
            float rotationY1 = centerY.GetComponent<Transform>().localEulerAngles.y;
            float rotationZ=centerY.GetComponent<Transform>().localEulerAngles.z;
          if(currentX1>minimumVert&&currentX1<maximumVert)
          {
          centerY.GetComponent<Transform>().localEulerAngles = new Vector3(rotationX, rotationY1, rotationZ);
          }
           if(starTime<=0)
           {
            starTime=0;
           }
        }
*/
 

 /*
 if(Input.GetAxis("Mouse Y")==0&&Input.GetKey(KeyCode.DownArrow)&&Input.GetKey(KeyCode.UpArrow)&&starTime>0&&c!=0&&lockb<0.1f&&!Input.GetMouseButton(0))
       {
          starTime=starTime-0.1f*Time.deltaTime;
          rotationX=rotationX-Mathf.Lerp(0, c*jsensitivityHor,starTime);
            float rotationY1 = centerY.GetComponent<Transform>().localEulerAngles.y;
            float rotationZ=centerY.GetComponent<Transform>().localEulerAngles.z;
          if(currentX1>minimumVert&&currentX1<maximumVert)
          {
          centerY.GetComponent<Transform>().localEulerAngles = new Vector3(rotationX, rotationY1, rotationZ);
          }
           if(starTime<=0)
           {
            starTime=0;
           }
        }

           // rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert); //限制视角上下限
           // float rotationY = transform.localEulerAngles.y;
           // transform.localEulerAngles = new Vector3(rotationX, rotationY, z);
	      
   */
    
//镜头看向方向纵向跟随物体
   /* if(Input.GetKey(KeyCode.E)&&look==true)
        {
        lookX=look.GetComponent<Transform>().position-transform.position;
        //ll=lookX.magnitude;
        
    lookY=lookX;
   // lookcen=lookX;
    //lookX.x=0;
    cam1=transform.forward;
    cam1.y=0;
    lookY.y=0;
    lookRotateY=Vector3.SignedAngle(cam1,lookY,Vector3.up);
    lookc=transform.forward;
    //Quaternion rotation1=Quaternion.Euler(-centerY.GetComponent<Transform>().localEulerAngles.x,0,0);
    //lookc=rotation1*lookc;
    lookc.x=0;
    
    //jj=Vector3.SignedAngle(lookc,new Vector3(0,1,0),Vector3.right);
    //jz=Vector3.SignedAngle(lookX,new Vector3(0,1,0),Vector3.right);
    //lookX=look.GetComponent<Transform>().position;
    //lookc=transform.position;
    //c=Vector3.SignedAngle(lookc,lookX,Vector3.right);
   //lookRotateX=jj-jz;

if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
{
    if(Input.GetKey(KeyCode.A))
    {
    jd=jd-10*Time.deltaTime;

    if(jd<-jd1)
    {
        jd=-jd1;
    }
    }
   if(Input.GetKey(KeyCode.D))
    {
    jd=jd+10*Time.deltaTime;
    if(jd>jd1)
    {
        jd=jd1;
    }

    }
}
  else
   {
if(jd>0.01)
{
    jd=jd-10*Time.deltaTime;
}
 if(jd<-0.01)
 {
    jd=jd+10*Time.deltaTime;
 }

//ll=ll/jd1;
   }



    Quaternion rotation=Quaternion.Euler(0,-lookRotateY+jd,0);
    lookX=rotation*lookX;
      lookcen=lookX;
      Vector3 loo=lookX;
      loo.x=0;
    jj=Vector3.SignedAngle(lookc,new Vector3(0,1,0),Vector3.right);
    jz=Vector3.SignedAngle(loo,new Vector3(0,1,0),Vector3.right);
    jk=Vector3.SignedAngle(new Vector3(0,lookc.y,lookc.z),new Vector3(0,lookX.y,lookX.z),Vector3.right);

if(jk>0.1||jk<-0.1)
{
        if(jz>0)
        {
            
            //transform.Rotate(-jk*lookSpeed*Time.deltaTime,0,0);
       float rotationX2=transform.localEulerAngles.x;
       rotationX2-=jk*lookSpeed*Time.deltaTime;
      float rotationY1 = transform.localEulerAngles.y;
            float rotationZ= transform.localEulerAngles.z;
      transform.localEulerAngles = new Vector3(rotationX2, rotationY1, rotationZ);
           
        }
        if(jz<0)
        {
            float rotationX2=transform.localEulerAngles.x;
              rotationX2-=-jk*lookSpeed*Time.deltaTime;
      float rotationY1 = transform.localEulerAngles.y;
            float rotationZ=transform.localEulerAngles.z;
     transform.localEulerAngles = new Vector3(rotationX2, rotationY1, rotationZ);
          
     
        }
      
         }
         
      }
*/


  if(lockb>0.1f&&look==true)
        {
        lookX=look.GetComponent<Transform>().position-transform.position;
        //ll=lookX.magnitude;
        
    lookY=lookX;
   // lookcen=lookX;
    //lookX.x=0;
    cam1=transform.forward;
    cam1.y=0;
    lookY.y=0;
    lookRotateY=Vector3.SignedAngle(cam1,lookY,Vector3.up);
    lookc=transform.forward;
    //Quaternion rotation1=Quaternion.Euler(-centerY.GetComponent<Transform>().localEulerAngles.x,0,0);
    //lookc=rotation1*lookc;
    lookc.x=0;
    
    //jj=Vector3.SignedAngle(lookc,new Vector3(0,1,0),Vector3.right);
    //jz=Vector3.SignedAngle(lookX,new Vector3(0,1,0),Vector3.right);
    //lookX=look.GetComponent<Transform>().position;
    //lookc=transform.position;
    //c=Vector3.SignedAngle(lookc,lookX,Vector3.right);
   //lookRotateX=jj-jz;

if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
{
    if(Input.GetKey(KeyCode.A))
    {
    jd=jd-10*Time.deltaTime;

    if(jd<-jd1)
    {
        jd=-jd1;
    }
    }
   if(Input.GetKey(KeyCode.D))
    {
    jd=jd+10*Time.deltaTime;
    if(jd>jd1)
    {
        jd=jd1;
    }

    }
}
  else
   {
if(jd>0.01)
{
    jd=jd-10*Time.deltaTime;
}
 if(jd<-0.01)
 {
    jd=jd+10*Time.deltaTime;
 }

//ll=ll/jd1;
   }



    Quaternion rotation=Quaternion.Euler(0,-lookRotateY+jd,0);
    lookX=rotation*lookX;
      lookcen=lookX;
      Vector3 loo=lookX;
      loo.x=0;
    jj=Vector3.SignedAngle(lookc,new Vector3(0,1,0),Vector3.right);
    jz=Vector3.SignedAngle(loo,new Vector3(0,1,0),Vector3.right);
    jk=Vector3.SignedAngle(new Vector3(0,lookc.y,lookc.z),new Vector3(0,lookX.y,lookX.z),Vector3.right);

if(jk>0.1||jk<-0.1)
{
        if(jz>0)
        {
            
            //transform.Rotate(-jk*lookSpeed*Time.deltaTime,0,0);
       float rotationX2=transform.localEulerAngles.x;
       rotationX2-=jk*lookSpeed*Time.deltaTime;
      float rotationY1 = transform.localEulerAngles.y;
            float rotationZ= transform.localEulerAngles.z;
      transform.localEulerAngles = new Vector3(rotationX2, rotationY1, rotationZ);
           
        }
        if(jz<0)
        {
            float rotationX2=transform.localEulerAngles.x;
              rotationX2-=-jk*lookSpeed*Time.deltaTime;
      float rotationY1 = transform.localEulerAngles.y;
            float rotationZ=transform.localEulerAngles.z;
     transform.localEulerAngles = new Vector3(rotationX2, rotationY1, rotationZ);
          
     
        }
      
         }
         
      }



      
  /*if(!Input.GetKey(KeyCode.UpArrow)&&!Input.GetKey(KeyCode.DownArrow)&&!Input.GetMouseButton(0))
  {
    if(currentX>0.05)
        {
            transform.Rotate(-currentX*Time.deltaTime,0,0);
        }
         if(currentX<-0.05)
         {
            transform.Rotate(-currentX*Time.deltaTime,0,0);
         }
  }
*/


//按w使得镜头返回到初始位置



    //判断镜头与物体是否有遮挡物，有则移动到遮挡物前 
   Vector3 origin=playerObject.GetComponent<Transform>().position+hfix;
   Vector3 direction=(transform.position-origin).normalized;
   //Ray ray=new Ray(origin,direction);
   RaycastHit hit;
  

        if(Physics.Raycast(origin,direction,out hit,10))
     {
   
     if(hit.collider.name!="camPo")
     {
       
    hitpos=hit.point;
      Vector3 po=center.GetComponent<Transform>().position+hfix-hit.point;
      Vector3 pon=po.normalized;
     // po=po-pon*0.2f;
      float l2=po.magnitude;
Vector3 distant=center.GetComponent<Transform>().position+hfix-transform.position+pon*0.8f;
float l=distant.magnitude;
if(l>l2&&l>1.5f){
distant=distant.normalized;
    transform.position=transform.position+distant*2*(l-l2)*Time.deltaTime;}
 


        }


      }

      if(hitpos!=Vector3.zero)
      {

 camhitL=(transform.position-hitpos).magnitude;
      
      }
     
     if(camhitL>1)
     {
      hitpos=Vector3.zero;
     }

if((y1!=0||x1!=0||y2<-0.1f)&&currentX1>10&&camhitL>1)
   {
   // if(!Input.GetKey(KeyCode.E)){
//transform.localEulerAngles=new Vector3(campo1.GetComponent<Transform>().localEulerAngles.x,transform.localEulerAngles.y,transform.localEulerAngles.z);
  //  }
/*if(currentX1>0.05)
        {
            centerY.GetComponent<Transform>().Rotate(-currentX1*Time.deltaTime,0,0);
        }
         if(currentX1<-0.05)
         {
            centerY.GetComponent<Transform>().Rotate(-currentX1*Time.deltaTime,0,0);
         }
*/
         if(currentX>0.05)
        {
            GetComponent<Transform>().Rotate(-currentX*Time.deltaTime,0,0);
        }
         if(currentX<-0.05)
         {
            GetComponent<Transform>().Rotate(-currentX*Time.deltaTime,0,0);
         }

Vector3 distant=campo1.GetComponent<Transform>().position-transform.position;
float l=distant.magnitude;
if(l>0.05)
{
distant=distant.normalized;
transform.position=transform.position+distant*2*Time.deltaTime;
}
else
{
    transform.position=campo1.GetComponent<Transform>().position;
}
   }


   
    }

    }
    

