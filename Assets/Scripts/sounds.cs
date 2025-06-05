using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip[] a;
    public float b=1f;
     public float c=1f;

     public float d=1f;
  public float s=1f;

    public GameObject jiaoR;
     public GameObject jiaoL;
    public GameObject player;

    public GameObject footsoundR;

    public GameObject footsoundL;

     public AudioClip[] bgm;

     public AudioClip[] jiaobusound;

  public AudioClip[] taban;
     public GameObject bgm1;

     public int bg=1;

     public int maxbgmnumber=63;

     public int minbgmnumber=0;

     public float bgmtime=0;

     public int bt=0;

  public GameObject taban1;


 public AudioClip[] backsounds;
     public GameObject weaponsounds;

    void Start()
    {
        
    }

  // Update is called once per frame
  void Update()
  {

    if (player.GetComponent<playerattack>().weaponsound == 1)
    {
      //Debug.Log(1);
      player.GetComponent<playerattack>().weaponsound = 0;
      GetComponent<AudioSource>().clip = a[0];
      GetComponent<AudioSource>().Play();
      GetComponent<AudioSource>().time = b;
    }

    if (player.GetComponent<playermove>().sprintingSound==1f&&player.GetComponent<playermove>().catchwall==0&&player.GetComponent<playermove>().crouchisTrue==0f)
    {
      player.GetComponent<playermove>().sprintingSound = 0f;
       GetComponent<AudioSource>().clip = a[1];
      GetComponent<AudioSource>().Play();
      GetComponent<AudioSource>().time=s;
      Debug.Log(1);
    }


    if (footsoundR.GetComponent<footsound>().footHeight < 0.07 && footsoundR.GetComponent<footsound>().a > 0.5)
    {
      jiaoR.GetComponent<AudioSource>().clip = jiaobusound[Random.Range(0, 4)];
      jiaoR.GetComponent<AudioSource>().Play();
      jiaoR.GetComponent<AudioSource>().time = d;
      footsoundR.GetComponent<footsound>().a = 0;

    }


    if (footsoundL.GetComponent<footsound>().footHeight < footsoundR.GetComponent<footsound>().b && footsoundL.GetComponent<footsound>().a > 0.5)
    {
      jiaoL.GetComponent<AudioSource>().clip = jiaobusound[Random.Range(0, 4)];
      jiaoL.GetComponent<AudioSource>().Play();
      jiaoL.GetComponent<AudioSource>().time = d;
      footsoundL.GetComponent<footsound>().a = 0;

    }

    if (player.GetComponent<playerattack>().weaponback1 == 1)
    {
      weaponsounds.GetComponent<AudioSource>().clip = backsounds[Random.Range(0, 2)];
      weaponsounds.GetComponent<AudioSource>().Play();
      player.GetComponent<playerattack>().weaponback1 = 0;
    }




    if (bgm1.GetComponent<AudioSource>().isPlaying == false && bt == 1)
    {
      bgmtime = Random.Range(30, 120);
      bt = 0;
    }
    bgmtime = bgmtime - 1 * Time.deltaTime;

    if (bgm1.GetComponent<AudioSource>().isPlaying == false && bgmtime <= 0)
    {
      bg = Random.Range(minbgmnumber, maxbgmnumber);
      bgm1.GetComponent<AudioSource>().clip = bgm[bg];
      bgm1.GetComponent<AudioSource>().Play();
      //Debug.Log(1);
      bt = 1;
    }
       
if(taban1.GetComponent<jumpBox>().tabanSound==1f)
        {
            //Debug.Log(1);
            taban1.GetComponent<jumpBox>().tabanSound=0f;
            taban1.GetComponent<AudioSource>().clip=taban[0];
             taban1.GetComponent<AudioSource>().Play();
            taban1. GetComponent<AudioSource>().time=b;
    }     



        }
 

        
        //Debug.Log( GetComponent<AudioSource>().time);
    }


