using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=cam.GetComponent<Transform>().position;
        transform.rotation=cam.GetComponent<Transform>().rotation;
    }
}
