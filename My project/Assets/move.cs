using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam;
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  Vector3 v=cam.GetComponent<camV>().lookcen;
    //v.x=-v.x;
    //v.z=-v.z;
        transform.position=cam.GetComponent<Transform>().position+v;
    }
}
