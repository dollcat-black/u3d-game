using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject campo;

    public GameObject center;

    public GameObject ZD;
    public float attackTime=-1;
    public float attackSpeed=1;

    public Vector3 ZDVelocity;
    public float ZDspeed=1;

    public GameObject quad;

    private Vector3 po;

    public float y1;
   
   private Playeraction controls;
   //private Vector2 move;

   public float a=-1;
      public float lockb=0;

      public float attackanimation=0;

      public float weapontype=0;

      public GameObject weapon;

      public bool weaponactive=true;

      public float weaponchange=0;

      public GameObject weaponhand;

      public GameObject weaponback;

      public float combo=0;

      public float combocount=0;

      public float attacktime=1f;

      public float speed=1;
      public Vector3 shootFix=Vector3.zero;

      public Vector3 aaa1;

      public Vector3 bbb1;

    


void Awake()
    {
        controls= new Playeraction();
        controls.GamePlay.Attack.performed += ctx =>Attack();
        controls.GamePlay.Attack.performed += ctx =>a=ctx.ReadValue<float>();
        controls.GamePlay.Attack.canceled += ctx =>a=0;

          controls.GamePlay.Lock.performed += ctx =>lockb=ctx.ReadValue<float>();
        controls.GamePlay.Lock.canceled += ctx =>lockb=0;
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
        weapon=GameObject.Find("2Hand-Sword");
        if(weapon.activeSelf==true)
        {
          weaponactive=false;
        }
        else
        {
          weaponactive=true;
        }
         
    }

    // Update is called once per frame
    void FixedUpdate()
    {
   
    //bbb1=transform.GetComponent<Rigidbody>().velocity;
  

    if(Input.GetKeyUp(KeyCode.Q))
    {
    
    if(weapon.activeSelf==true)
    {
     weaponchange=-1;
    }
    else
    {
      weaponchange=1;
    }
    }

if(weapon.activeSelf==true)
{
  
weapontype=weapontype+1f*Time.deltaTime;
if(weapontype>1)
{
  weapontype=1;
}
  
     if(a==1)
     {
      attackanimation=1;
      GetComponent<playermove>().x1=0;
      GetComponent<playermove>().y1=0;
      if(combo<=0)
      {
        combo=1;
        attacktime=1f;
      }

      if(combo>0&&attacktime>0.1f)
      {
        combo=1.1f;
        attacktime=1f;
      }
    





     }

     if(a==0)
     {
      attackanimation=0;
  
     }

     if(GetComponent<playermove>().x1!=0||GetComponent<playermove>().y1!=0)
     {
     attackanimation=-5;

     }
}
else
{
  attackanimation=-5;
  weapontype=weapontype-1f*Time.deltaTime;
if(weapontype<0)
{
  weapontype=0;
}
}

if(weaponchange>0.1)
{
  weaponchange=weaponchange-1f*Time.deltaTime;
}
if(weaponchange<-0.1)
{
  weaponchange=weaponchange+1f*Time.deltaTime;
}

combo=combo-1f*Time.deltaTime;
if(combo<0)
{
  combo=0f;
  //combocount=0;
}

if(combo>0)
{
   
  attacktime=attacktime-2f*Time.deltaTime;
 
}


     GetComponent<playermove>().m_Animator.SetFloat("weaponchange",weaponchange);
     GetComponent<playermove>().m_Animator.SetFloat("Attack",attackanimation);
     GetComponent<playermove>().m_Animator.SetFloat("weapontype",weapontype);
     GetComponent<playermove>().m_Animator.SetFloat("combo",combo);
if(combocount>0)
{
  if(GetComponent<playermove>().x1!=0||GetComponent<playermove>().y1!=0)
  {
    speed=4;
  }
  else
  {
    speed=2;
  }
      Vector3 aaa2=transform.forward*speed;//构建Z轴方向速度  向量*键盘输入数值及速度参数
    aaa2.y=transform.GetComponent<Rigidbody>().velocity.y;//取消Y轴方向速度，防止影响重力控制
    transform.GetComponent<Rigidbody>().velocity=aaa2;
}
combocount=combocount-2f*Time.deltaTime;
if(combocount<0)
{
  combocount=0;
}
     /* if(Input.GetMouseButton(0))
      {
        if(attackTime<0)
        {
            attackTime=1;
        po=center.GetComponent<Transform>().position+shootFix+center.GetComponent<Transform>().forward.normalized*2;
      GameObject obj=Instantiate(ZD,po,center.GetComponent<Transform>().rotation); 
      GameObject obj1=Instantiate(quad,po,center.GetComponent<Transform>().rotation); 
     obj1.GetComponent<Transform>().eulerAngles=center.GetComponent<Transform>().eulerAngles;
     ZDVelocity= campo.GetComponent<Transform>().forward.normalized*ZDspeed;
      if(lockb>0.1f)
      {
     ZDVelocity=center.GetComponent<camH>().lookcen+center.GetComponent<Transform>().position-po;
     ZDVelocity=ZDVelocity.normalized*ZDspeed;
    
      }
    
      obj. GetComponent<Rigidbody>().velocity=ZDVelocity;  
      }
      else
      {
        attackTime=attackTime-attackSpeed*Time.deltaTime;
      }
    }
    */
    attackTime=attackTime-attackSpeed*Time.deltaTime;
    if(attackTime<=0)
    {
      attackTime=0;
    }
    
   }

   void Attack()
   {
        if(attackTime<=0&&weapon.activeSelf==false)
        {
            attackTime=1;
        po=center.GetComponent<Transform>().position+shootFix+center.GetComponent<Transform>().forward.normalized*2;
      GameObject obj=Instantiate(ZD,po,center.GetComponent<Transform>().rotation); 
      GameObject obj1=Instantiate(quad,po,center.GetComponent<Transform>().rotation); 
     obj1.GetComponent<Transform>().eulerAngles=center.GetComponent<Transform>().eulerAngles;
     ZDVelocity= campo.GetComponent<Transform>().forward.normalized*ZDspeed;
      if(lockb>0.1f)
      {
     ZDVelocity=center.GetComponent<camH>().lookcen+center.GetComponent<Transform>().position-po;
     ZDVelocity=ZDVelocity.normalized*ZDspeed;
    
      }
        y1=ZDVelocity.y;
        if(y1<0)
        {
          ZDVelocity=new Vector3(ZDVelocity.x,0,ZDVelocity.z);
        }
      obj. GetComponent<Rigidbody>().velocity=ZDVelocity;  
      }
      else
      {
        attackTime=attackTime-attackSpeed*Time.deltaTime;
      }
    

//github1  gitee222

   }
   public void backweapon(int i)
   {
     if(i==1)
     {
       weaponback.SetActive(false);
       weapon.SetActive(true);
       //Debug.Log(1);
     }

      if(i==0)
     {
       weaponback.SetActive(true);
       weapon.SetActive(false);
        //Debug.Log(2);
     }

   }

   public void combonumber(int k)
   {
     combocount=1f;
   

   }

   public void combozero(int k)
   {
     combocount=k;

   }

   public void ChangeRollCollider(int K)
   {
     GetComponent<CapsuleCollider>().enabled=false;
     GetComponent<BoxCollider>().enabled=true;
   }

   public void ChangeNormalCollider(int K)
   {
     GetComponent<CapsuleCollider>().enabled=true;
     GetComponent<BoxCollider>().enabled=false;
   }
}
