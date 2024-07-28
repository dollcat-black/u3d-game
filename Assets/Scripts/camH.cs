using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class camH : MonoBehaviour
{
      
    private float _rotationX = 0;
    public float sensitivityHor=3;//鼠标横向旋转速度系数
    public float jsensitivityHor=0.5f; //键盘横向旋转速度系数
    public GameObject playerObject;  //角色物体



    public GameObject look;   //看向的物体
	// Use this for initialization

    private float starTime=0;  //平滑镜头时间
  
    private float delta; //镜头旋转自动分配速度（不修改）
    private int a=0; //判断移动镜头方向及平滑移动方向
    private Vector3 centerTOplayerObjectV; //镜头-角色向量

    private float distant; //镜头-角色间距离

    public float backspeed=1; //镜头返回角色速度系数
      public float maxDistant=2;  //镜头跟随角色最远距离

      private float a1;  //判断镜头方向与镜头与角色方向向量正反
      private float c=0; //确认无操作，镜头可以自行平滑移动

      private float lookRotateY; //看向物体与镜头在Y轴夹角大小
      //public float lookRotateX;

      private Vector3 lookY;  //镜头看向物体的向量

     // public Vector3 lookX;
      public float lookSpeed=1;  //看向物体速度系数

      public Vector3 lookcen;
      
      private Playeraction controls;
   public float lockb=0;
public Vector2 move=Vector2.zero;
public Vector2 arrow=Vector2.zero;
   public float x1=0;
   public float y1=0;

    public float x2=0;
   public float y2=0;
      public float jump=0;
    
   void Awake()
    {
        controls= new Playeraction();
       // controls.GamePlay.Attack.performed += ctx =>Attack();
        controls.GamePlay.Lock.performed += ctx =>lockb=ctx.ReadValue<float>();
        controls.GamePlay.Lock.canceled += ctx =>lockb=0;

        controls.GamePlay.Jump.performed += ctx =>jump=ctx.ReadValue<float>();
        controls.GamePlay.Jump.canceled += ctx =>jump=0;

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




	void Start () {
       
	}
	

	void FixedUpdate () {
           x1=move.x;
   y1=move.y;
   x2=arrow.x;
   y2=arrow.y;
      //镜头平滑跟随角色      
     /*if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.Space))    
    {
        
        centerTOplayerObjectV=playerObject.GetComponent<Transform>().position-transform.position;
       distant=centerTOplayerObjectV.magnitude;
       centerTOplayerObjectV=centerTOplayerObjectV.normalized;

        //transform.position+=po1*l3*l3/100;
       // l3=Mathf.Clamp(l3,0,maxDistant-0.04f);
         
       
       a1=Vector3.Dot(playerObject.GetComponent<Rigidbody>().velocity,centerTOplayerObjectV);
       if(a1<0&&distant>=maxDistant-0.04)
        {
            distant=maxDistant-0.1f;
        }
      /* a1=Vector3.Dot(aaa,po1);
      if(a1>0&&l3>=maxDistant-0.04f)
      {
        l3=po1.magnitude;
        } 
        //l3=Mathf.Clamp(l3,0,maxDistant);
*/

   //  transform.GetComponent<Rigidbody>().velocity=po1*l3*l3/maxDistant;
    /*transform.GetComponent<Rigidbody>().velocity=centerTOplayerObjectV*distant*distant/maxDistant;
    }
       else   //镜头平滑返回角色
       {

       centerTOplayerObjectV=playerObject.GetComponent<Transform>().position-transform.position;
       distant=centerTOplayerObjectV.magnitude;
       centerTOplayerObjectV=centerTOplayerObjectV.normalized;
       //l3=Mathf.Clamp(l3,0,maxDistant);
       //backspeed=backspeed*l3/maxDistant;
       transform.GetComponent<Rigidbody>().velocity=centerTOplayerObjectV*distant*distant*backspeed;
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
    // }
//transform.position=playerObject.GetComponent<Transform>().position;

   if(x1!=0||y1!=0||jump!=0)    
    {
        
        centerTOplayerObjectV=playerObject.GetComponent<Transform>().position-transform.position;
       distant=centerTOplayerObjectV.magnitude;
       centerTOplayerObjectV=centerTOplayerObjectV.normalized;

        //transform.position+=po1*l3*l3/100;
       // l3=Mathf.Clamp(l3,0,maxDistant-0.04f);
         
       
       a1=Vector3.Dot(playerObject.GetComponent<Rigidbody>().velocity,centerTOplayerObjectV);
       if(a1<0&&distant>=maxDistant-0.04)
        {
            distant=maxDistant-0.1f;
        }
      /* a1=Vector3.Dot(aaa,po1);
      if(a1>0&&l3>=maxDistant-0.04f)
      {
        l3=po1.magnitude;
        } 
        //l3=Mathf.Clamp(l3,0,maxDistant);
*/

   //  transform.GetComponent<Rigidbody>().velocity=po1*l3*l3/maxDistant;
    transform.GetComponent<Rigidbody>().velocity=centerTOplayerObjectV*distant*distant/maxDistant;
    }
       else   //镜头平滑返回角色
       {

       centerTOplayerObjectV=playerObject.GetComponent<Transform>().position-transform.position;
       distant=centerTOplayerObjectV.magnitude;
       centerTOplayerObjectV=centerTOplayerObjectV.normalized;
       //l3=Mathf.Clamp(l3,0,maxDistant);
       //backspeed=backspeed*l3/maxDistant;
       transform.GetComponent<Rigidbody>().velocity=centerTOplayerObjectV*distant*distant*backspeed;
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
     }

//键盘移动视角

//键盘移动视角
if(x2!=0&&lockb==0)
        {
           
             if(x2<0)
             {
                delta = -jsensitivityHor;
                c=1;
            a=1;
             starTime=1;
             }
               if(x2>0)
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

/*if((Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow))&&!Input.GetKey(KeyCode.E))
        {
           
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

        */



       //停止移动视角后镜头平滑停止
    /*if( Input.GetAxis("Mouse X")==0&&c==0&&!Input.GetKey(KeyCode.E))
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
        */

         if( Input.GetAxis("Mouse X")==0&&c==0&&lockb==0)
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

//鼠标移动视角
        if((Input.GetAxis("Mouse X")>=0.05||Input.GetAxis("Mouse X")<=-0.05)&&!Input.GetKey(KeyCode.E))
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
            
      
     
     //镜头横向看向物体
/*if(Input.GetKey(KeyCode.E)&&look==true){
    
    lookY=look.GetComponent<Transform>().position-transform.position;
    lookcen=lookY;
     lookY.y=0;
     lookRotateY=Vector3.SignedAngle(transform.forward,lookY,Vector3.up);
    if(lookRotateY>0.01||lookRotateY<-0.01){
     transform.Rotate(0,lookRotateY*lookSpeed*Time.deltaTime,0);
    }
}  */

if(lockb>0.1f&&look==true){
    
    lookY=look.GetComponent<Transform>().position-transform.position;
    lookcen=lookY;
     lookY.y=0;
     lookRotateY=Vector3.SignedAngle(transform.forward,lookY,Vector3.up);
    if(lookRotateY>0.01||lookRotateY<-0.01){
     transform.Rotate(0,lookRotateY*lookSpeed*Time.deltaTime,0);
    }
}

    }
}

