using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsound : MonoBehaviour
{
    // Start is called before the first frame update

    public float footHeight=0;
    public GameObject test;

    public float a=0;

    public float b=0.07f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit))
    {
    if(hit.collider.name!="PlayerObject")
     {
test.GetComponent<Transform>().position=hit.point;
footHeight=Mathf.Abs(transform.position.y-hit.point.y);

     }

if(footHeight>b)
{
    a=1;
}


    }


    }
}
