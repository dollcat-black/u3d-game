using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
//using UnityEditor.Search;
using UnityEngine;
//using UnityEngine.SocialPlatforms.GameCenter;

public class playermove : MonoBehaviour
{
    

public float movespeed=5;
public float jumpHeight=5;
public GameObject center;

public PhysicMaterial noFriction;

public PhysicMaterial haveFriction;
public float angle;

private float a;
private float b;

private float runTimeW=0;
private float runTimeA=0;

private float runTimeS=0;

private float runTimeD=0;

public float rotateSpeed=90;
public bool run=false;

private Playeraction controls;
   public float jump;

   public float jump1=0;

public float run1=0;
  

   public float d=0;

   public float x1=0;
   public float y1=0;

   public Vector2 move=Vector2.zero;

   public Animator m_Animator;

   public bool moving;

   public float inputSpeed;
   public float runSpeed;

   public float movespeed1;
void Awake()
    {
        controls= new Playeraction();
       // controls.GamePlay.Attack.performed += ctx =>Attack();
        controls.GamePlay.Jump.performed += ctx =>jump=ctx.ReadValue<float>();
        controls.GamePlay.Jump.canceled += ctx =>jump=0;

controls.GamePlay.run.performed += ctx =>run1=ctx.ReadValue<float>();
        controls.GamePlay.run.canceled += ctx =>run1=0;

        controls.GamePlay.move.performed += ctx =>move=ctx.ReadValue<Vector2>();
        controls.GamePlay.move.canceled += ctx =>move=Vector2.zero;


         m_Animator = GetComponent<Animator>();   
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
        
    }

   
    
    void FixedUpdate()
    {  
    //transform.Rotate(new Vector3(0,1,0)); //绕Y轴旋转自身
    //Vector3 aaa=transform.forward*Input.GetAxis("Vertical")*movespeed;//构建Z轴方向速度  向量*键盘输入数值及速度参数
    //aaa.y=transform.GetComponent<Rigidbody>().velocity.y;//取消Y轴方向速度，防止影响重力控制
    //transform.GetComponent<Rigidbody>().velocity=aaa;//将速度向量赋予刚体
  
/*if(Input.GetKey(KeyCode.Space))
   {
    if(transform.GetComponent<Rigidbody>().velocity.y==0)
    {Vector3 aaa=transform.up*jumpHeight;//构建Z轴方向速度  向量*键盘输入数值及速度参数
    //aaa.y=transform.GetComponent<Rigidbody>().velocity.y;//取消Y轴方向速度，防止影响重力控制
    transform.GetComponent<Rigidbody>().velocity=new Vector3(transform.GetComponent<Rigidbody>().velocity.x,aaa.y,transform.GetComponent<Rigidbody>().velocity.z);//将速度向量赋予刚体
    }
   }
   */
   x1=move.x;
   y1=move.y;


if(jump1==0)
{
     m_Animator.SetBool("Jump1", false);

}


   /*if(jump==1&&d==0)
   {
    if(transform.GetComponent<Rigidbody>().velocity.y==0)
    {Vector3 aaa=transform.up*jumpHeight;//构建Z轴方向速度  向量*键盘输入数值及速度参数
    //aaa.y=transform.GetComponent<Rigidbody>().velocity.y;//取消Y轴方向速度，防止影响重力控制
    transform.GetComponent<Rigidbody>().velocity=new Vector3(transform.GetComponent<Rigidbody>().velocity.x,aaa.y,transform.GetComponent<Rigidbody>().velocity.z);//将速度向量赋予刚体
    }
    d=1;
   }

*/
 
if(jump==1&&jump1==0)
{
 
 

        
   
   m_Animator.SetBool("Jump1", true);
    Vector3 aaa=transform.up*jumpHeight;
      transform.GetComponent<Rigidbody>().velocity=new Vector3(transform.GetComponent<Rigidbody>().velocity.x,aaa.y,transform.GetComponent<Rigidbody>().velocity.z);//将速度向量赋予刚体
    
    
}

 run=false;
   if(Input.GetKeyUp(KeyCode.W)&&!Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.S))
   {
    runTimeW=1;
    runTimeA=0;
    runTimeS=0;
    runTimeD=0;
   }

   if(Input.GetKeyUp(KeyCode.A)&&!Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.S))
   {
    runTimeW=0;
    runTimeA=1;
    runTimeS=0;
    runTimeD=0;
   }

   if(Input.GetKeyUp(KeyCode.S)&&!Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D))
   {
     runTimeW=0;
    runTimeA=0;
    runTimeS=1;
    runTimeD=0;
   }

   if(Input.GetKeyUp(KeyCode.D)&&!Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.S))
   {
     runTimeW=0;
    runTimeA=0;
    runTimeS=0;
    runTimeD=1;
  
   }


      runTimeW-=5*Time.deltaTime;
      runTimeA-=5*Time.deltaTime;
      runTimeS-=5*Time.deltaTime;
      runTimeD-=5*Time.deltaTime;
       if(runTimeW<=0)
       {
       runTimeW=0;
       } 

       if(runTimeA<=0)
       {
       runTimeA=0;
       } 

       if(runTimeS<=0)
       {
       runTimeS=0;
       } 
       if(runTimeD<=0)
       {
       runTimeD=0;
       } 

/*if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
   {
if(Input.GetKey(KeyCode.LeftShift))
    {
       movespeed=10;
       }
       else
       {
        movespeed=5;
       }

   }*/
if(x1==0&&y1==0)
{

movespeed=0;
}

   if(x1!=0||y1!=0)
   {
if(Input.GetKey(KeyCode.LeftShift))
    {
       movespeed=10;
       }
       else
       {
        movespeed=5;
       }

   }

 if(x1!=0||y1!=0)
   {
if(Input.GetKey(KeyCode.LeftShift))
    {
        runTimeW=-5;
    runTimeA=-5;
    runTimeS=-5;
    runTimeD=-5;
       run=true;
       }
       else
       {
        run=false;
       }

    if(runTimeA>0&&Input.GetKey(KeyCode.A))
    {
        runTimeA+=5*Time.deltaTime;
         run=true;
    movespeed=10;
    }

    if(runTimeW>0&&Input.GetKey(KeyCode.W))
    {
        runTimeW+=5*Time.deltaTime;
         run=true;
    movespeed=10;
    }
  
  if(runTimeS>0&&Input.GetKey(KeyCode.S))
    {
        runTimeS+=5*Time.deltaTime;
         run=true;
    movespeed=10;
    }
  

  if(runTimeD>0&&Input.GetKey(KeyCode.D))
    {
        runTimeD+=5*Time.deltaTime;
         run=true;
    movespeed=10;
    }
  if(run1>0.1f)
  {
    run=true;
  }
  else
  {
    run=false;
  }
  if(run==true)
  {
   movespeed=10;
      runTimeW+=5*Time.deltaTime;
      runTimeA+=5*Time.deltaTime;
      runTimeS+=5*Time.deltaTime;
      runTimeD+=5*Time.deltaTime;
  }
  else
  {
    movespeed=5;
  }

  

  
if(jump1==1)
  {
    Vector3 aaa1=transform.forward*movespeed;//构建Z轴方向速度  向量*键盘输入数值及速度参数
    aaa1.y=transform.GetComponent<Rigidbody>().velocity.y;//取消Y轴方向速度，防止影响重力控制
    transform.GetComponent<Rigidbody>().velocity=aaa1;//将速度向量赋予刚体
   }
   }



  /* if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
   {
if(Input.GetKey(KeyCode.LeftShift))
    {
        runTimeW=-5;
    runTimeA=-5;
    runTimeS=-5;
    runTimeD=-5;
       run=true;
       }
       else
       {
        run=false;
       }

    if(runTimeA>0&&Input.GetKey(KeyCode.A))
    {
        runTimeA+=5*Time.deltaTime;
         run=true;
    movespeed=10;
    }

    if(runTimeW>0&&Input.GetKey(KeyCode.W))
    {
        runTimeW+=5*Time.deltaTime;
         run=true;
    movespeed=10;
    }
  
  if(runTimeS>0&&Input.GetKey(KeyCode.S))
    {
        runTimeS+=5*Time.deltaTime;
         run=true;
    movespeed=10;
    }
  

  if(runTimeD>0&&Input.GetKey(KeyCode.D))
    {
        runTimeD+=5*Time.deltaTime;
         run=true;
    movespeed=10;
    }
  if(run==true)
  {
   movespeed=10;
      runTimeW+=5*Time.deltaTime;
      runTimeA+=5*Time.deltaTime;
      runTimeS+=5*Time.deltaTime;
      runTimeD+=5*Time.deltaTime;
  }
  else
  {
    movespeed=5;
  }

  

    Vector3 aaa1=transform.forward*movespeed;//构建Z轴方向速度  向量*键盘输入数值及速度参数
    aaa1.y=transform.GetComponent<Rigidbody>().velocity.y;//取消Y轴方向速度，防止影响重力控制
    transform.GetComponent<Rigidbody>().velocity=aaa1;//将速度向量赋予刚体
   }
   */
    if(x1!=0||y1!=0)
    {
      moving=true;
      inputSpeed+=2f*Time.deltaTime;
      if(inputSpeed>1)
      {
         inputSpeed=1;
      }

      if(run1>0&&runSpeed<1)
      {
        runSpeed+=2f*Time.deltaTime;
      }
      if(run1==0&&runSpeed>=0)
      {
        runSpeed-=2f*Time.deltaTime;
      }
      if(runSpeed<0)
      {
        runSpeed=0;
      }
   
    

    }
    else
    {
      moving=false;
      inputSpeed-=2f*Time.deltaTime;
     if(inputSpeed<0)
      {
         inputSpeed=0;
      }

      if(run1==0&&runSpeed>=0)
      {
        runSpeed-=2f*Time.deltaTime;
      }
      if(runSpeed<0)
      {
        runSpeed=0;
      }

    }
  
         
           //inputSpeed =Mathf.Clamp01( Mathf.Abs(x1) + Mathf.Abs(y1));
        movespeed1=inputSpeed+runSpeed;
            m_Animator.SetBool(Const.Moving, moving);
          m_Animator.SetFloat(Const.Speed, movespeed1);
        

  
    


a=GetComponent<Transform>().eulerAngles.y;
b=center.GetComponent<Transform>().eulerAngles.y;
if(a<0)
{
    a+=360;
}
if(b<0)
{
    b+=360;
}
  if(a>=b&&a<360)
  {

    angle=a-b;
  }

  if(a>=0&&a<b)
  {

    angle=360-b+a;
  }

  
if(y1>0&&x1==0)
   {
    float s1=angle/180;
float s2=(360-angle)/180;
     if(angle>0.001&&angle<=180)
     {
     transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
     }

    if(angle>180&&angle<359.999)
     {
      transform.Rotate(0,rotateSpeed*s2*Time.deltaTime,0);
     }
    
    }
    
if(y1<0&&x1==0)
   {

    float s1=1-angle/180;
float s2=1-(360-angle)/180;
     if(angle>=0&&angle<179.999)
     {
     transform.Rotate(0,rotateSpeed*s1*Time.deltaTime,0);
     }
   
    if(angle>180.001&&angle<360)
     {
      transform.Rotate(0,-rotateSpeed*s2*Time.deltaTime,0);
     }


    }

    if(x1<0&&y1==0)
   {
    
    float s1=(angle-270)/90;
float s2=(angle+90)/180;
float s3=(270-angle)/180;
     if(angle>=270.001&&angle<360)
     {
     transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
     }

     if(angle>=0&&angle<=90)
     {
     transform.Rotate(0,-rotateSpeed*s2*Time.deltaTime,0);
     }
   
    if(angle>90&&angle<269.999)
     {
      transform.Rotate(0,rotateSpeed*s3*Time.deltaTime,0);
     }


    }

   if(x1>0&&y1==0)
   {
    
    float s1=(angle-90)/180;
float s2=(450-angle)/180;
float s3=(90-angle)/180;
     if(angle>=90.001&&angle<270)
     {
    
      transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
    
      
     
     }

     if(angle>=270&&angle<360)
     {
     transform.Rotate(0,rotateSpeed*s2*Time.deltaTime,0);
     }
   
    if(angle>=0&&angle<89.999)
     {
      
      
    
      transform.Rotate(0,rotateSpeed*s3*Time.deltaTime,0);
    
     }

     /*if(angle>=89.999&&angle<90.001)
     {
      transform.Rotate(0,center.GetComponent<camH>().jsensitivityHor*Time.deltaTime,0);
     }*/


    }

if(y1>0&&x1<0)
   {
    
    float s1=(angle-315)/180;
float s2=(45+angle)/180;
float s3=(315-angle)/180;
     if(angle>=315.001&&angle<360)
     {
     transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
     }

     if(angle>=0&&angle<135)
     {
     transform.Rotate(0,-rotateSpeed*s2*Time.deltaTime,0);
     }
   
    if(angle>=135&&angle<314.999)
     {
      transform.Rotate(0,rotateSpeed*s3*Time.deltaTime,0);
     }


    }

if(y1>0&&x1>0)
   {
    
    float s1=(angle-45)/180;
float s2=(405-angle)/180;
float s3=(45-angle)/180;
     if(angle>=45.001&&angle<225)
     {
     transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
     }

     if(angle>=225&&angle<360)
     {
     transform.Rotate(0,rotateSpeed*s2*Time.deltaTime,0);
     }
   
    if(angle>=0&&angle<44.999)
     {
      transform.Rotate(0,rotateSpeed*s3*Time.deltaTime,0);
     }


    }

if(y1<0&&x1>0)
   {
    
    float s1=(angle-135)/180;
float s2=(495-angle)/180;
float s3=(135-angle)/180;
     if(angle>=135.001&&angle<315)
     {
     transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
     }

     if(angle>=315&&angle<360)
     {
     transform.Rotate(0,rotateSpeed*s2*Time.deltaTime,0);
     }
   
    if(angle>=0&&angle<134.999)
     {
      transform.Rotate(0,rotateSpeed*s3*Time.deltaTime,0);
     }


    }

if(y1<0&&x1<0)
   {
    
    float s1=(angle-225)/180;
float s2=(135+angle)/180;
float s3=(225-angle)/180;
     if(angle>=225.001&&angle<360)
     {
     transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
     }

     if(angle>=0&&angle<45)
     {
     transform.Rotate(0,-rotateSpeed*s2*Time.deltaTime,0);
     }
   
    if(angle>=45&&angle<224.999)
     {
      transform.Rotate(0,rotateSpeed*s3*Time.deltaTime,0);
     }


    }


/*
  
if(Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.S)&&!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D))
   {
    float s1=angle/180;
float s2=(360-angle)/180;
     if(angle>0.001&&angle<=180)
     {
     transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
     }

    if(angle>180&&angle<359.999)
     {
      transform.Rotate(0,rotateSpeed*s2*Time.deltaTime,0);
     }
    
    }
    
if(Input.GetKey(KeyCode.S)&&!Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D))
   {

    float s1=1-angle/180;
float s2=1-(360-angle)/180;
     if(angle>=0&&angle<179.999)
     {
     transform.Rotate(0,rotateSpeed*s1*Time.deltaTime,0);
     }
   
    if(angle>180.001&&angle<360)
     {
      transform.Rotate(0,-rotateSpeed*s2*Time.deltaTime,0);
     }


    }

    if(Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.S)&&!Input.GetKey(KeyCode.D))
   {
    
    float s1=(angle-270)/90;
float s2=(angle+90)/180;
float s3=(270-angle)/180;
     if(angle>=270.001&&angle<360)
     {
     transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
     }

     if(angle>=0&&angle<=90)
     {
     transform.Rotate(0,-rotateSpeed*s2*Time.deltaTime,0);
     }
   
    if(angle>90&&angle<269.999)
     {
      transform.Rotate(0,rotateSpeed*s3*Time.deltaTime,0);
     }


    }

   if(Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.S)&&!Input.GetKey(KeyCode.A))
   {
    
    float s1=(angle-90)/180;
float s2=(450-angle)/180;
float s3=(90-angle)/180;
     if(angle>=90.001&&angle<270)
     {
    
      transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
    
      
     
     }

     if(angle>=270&&angle<360)
     {
     transform.Rotate(0,rotateSpeed*s2*Time.deltaTime,0);
     }
   
    if(angle>=0&&angle<89.999)
     {
      
      
    
      transform.Rotate(0,rotateSpeed*s3*Time.deltaTime,0);
    
     }

     /*if(angle>=89.999&&angle<90.001)
     {
      transform.Rotate(0,center.GetComponent<camH>().jsensitivityHor*Time.deltaTime,0);
     }*/


   /* }

if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.S)&&!Input.GetKey(KeyCode.D))
   {
    
    float s1=(angle-315)/180;
float s2=(45+angle)/180;
float s3=(315-angle)/180;
     if(angle>=315.001&&angle<360)
     {
     transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
     }

     if(angle>=0&&angle<135)
     {
     transform.Rotate(0,-rotateSpeed*s2*Time.deltaTime,0);
     }
   
    if(angle>=135&&angle<314.999)
     {
      transform.Rotate(0,rotateSpeed*s3*Time.deltaTime,0);
     }


    }

if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.S)&&!Input.GetKey(KeyCode.A))
   {
    
    float s1=(angle-45)/180;
float s2=(405-angle)/180;
float s3=(45-angle)/180;
     if(angle>=45.001&&angle<225)
     {
     transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
     }

     if(angle>=225&&angle<360)
     {
     transform.Rotate(0,rotateSpeed*s2*Time.deltaTime,0);
     }
   
    if(angle>=0&&angle<44.999)
     {
      transform.Rotate(0,rotateSpeed*s3*Time.deltaTime,0);
     }


    }

if(Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.A))
   {
    
    float s1=(angle-135)/180;
float s2=(495-angle)/180;
float s3=(135-angle)/180;
     if(angle>=135.001&&angle<315)
     {
     transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
     }

     if(angle>=315&&angle<360)
     {
     transform.Rotate(0,rotateSpeed*s2*Time.deltaTime,0);
     }
   
    if(angle>=0&&angle<134.999)
     {
      transform.Rotate(0,rotateSpeed*s3*Time.deltaTime,0);
     }


    }

if(Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.D))
   {
    
    float s1=(angle-225)/180;
float s2=(135+angle)/180;
float s3=(225-angle)/180;
     if(angle>=225.001&&angle<360)
     {
     transform.Rotate(0,-rotateSpeed*s1*Time.deltaTime,0);
     }

     if(angle>=0&&angle<45)
     {
     transform.Rotate(0,-rotateSpeed*s2*Time.deltaTime,0);
     }
   
    if(angle>=45&&angle<224.999)
     {
      transform.Rotate(0,rotateSpeed*s3*Time.deltaTime,0);
     }


    }

   */

//判断角色是否地面，切换物理摩擦材质

    if(Physics.Raycast(transform.position,Vector3.down,0.05f))
    {
      GetComponent<Collider>().material=haveFriction;
    jump1=0;
    }
    else
    {
      GetComponent<Collider>().material=noFriction;
     jump1=1;
    }

    

//jd=Vector3.SignedAngle(transform.forward,center.GetComponent<Transform>().forward,Vector3.up);

}
}