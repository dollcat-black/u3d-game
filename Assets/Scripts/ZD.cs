using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZD : MonoBehaviour
{
    // Start is called before the first frame update
    private float time=3;
    public GameObject MainCam;
    public float VibrateTime=0.2f;
    void Start()
    {
      time=3;
        MainCam = GameObject.FindWithTag("cam1");
VibrateTime=0.2f;
    }

    // Update is called once per frame
    void Update()
    {


        Destroy(gameObject,time);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && transform.gameObject.tag != "playerBullet")
        {
            if (other.GetComponent<playerDate>().playerHealth > 0 && other.GetComponent<playerDate>().knockTime <= 0)
            {
                MainCam.GetComponent<camVibrate>().camVibrateTime = VibrateTime;

            }
        }


        if (other.tag == "shootAble" && other.GetComponent<enemy>() == true)
        {

            other.GetComponent<enemy>().health -= 10;
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {
            if (other.GetComponent<playerDate>().knockTime <= 0)
            {
                other.GetComponent<playerDate>().isknock = 1f;
                other.GetComponent<playerDate>().playerHealth -= 10;
                Destroy(gameObject);
            }

        }



        if (other.tag != "shootAble" && other.tag != "Player" )
        {
            Destroy(gameObject);
        }


        if (other.tag == "playerBullet")
        {

            if (transform.gameObject.tag == "bullet")
                Destroy(gameObject);
        }
        
         if (other.tag =="bullet")
        { 

        if(transform.gameObject.tag=="playerBullet")
         Destroy(gameObject);
        }
        
    }
}
