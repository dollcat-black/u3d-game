using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class dapao : MonoBehaviour
{
    public GameObject palyerObject;
    public GameObject ZD;
    public GameObject quad;
    public GameObject shootPoint;
    public float distance = 100;

    public float attacktime = 0;
    public float attackdistance = 15;

    public float ZDspeed = 1;
    public float waittime = 1;

    private Vector3 lookY;
    public float lookRotateY;
    public float lookSpeed=1;
    // Start is called before the first frame update
    void Start()
    {
        lookSpeed=1;
    }

    // Update is called once per frame
    void Update()
    {
        attacktime = attacktime - waittime * Time.deltaTime;
        if (attacktime <= 0)
        {
            attacktime = 0;
        }
        distance = (transform.position - palyerObject.GetComponent<Transform>().position).magnitude;
        if (distance <= attackdistance && attacktime <= 0&&palyerObject.GetComponent<playerDate>().playerHealth>0)
        {
            attacktime = 1;
            Vector3 po = shootPoint.GetComponent<Transform>().position;
            GameObject obj = Instantiate(ZD, po, GetComponent<Transform>().rotation);
            GameObject obj1 = Instantiate(quad, po, GetComponent<Transform>().rotation);
            obj1.GetComponent<Transform>().eulerAngles = shootPoint.GetComponent<Transform>().eulerAngles;
            Vector3 ZDVelocity = GetComponent<Transform>().right.normalized * -ZDspeed;
            obj.GetComponent<Rigidbody>().velocity = ZDVelocity;

        }

        if (distance <= attackdistance&&palyerObject.GetComponent<playerDate>().playerHealth>0)
        { 
            lookY=palyerObject.GetComponent<Transform>().position-transform.position;
            lookY.y=0;
    lookRotateY=Vector3.SignedAngle(-transform.right,lookY,Vector3.up);
    if(lookRotateY>0.01||lookRotateY<-0.01)
            {
     transform.Rotate(0,lookRotateY*lookSpeed*Time.deltaTime,0);
    }
        }

    }
}
