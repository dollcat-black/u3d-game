using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campofollow : MonoBehaviour
{
    // Start is called before the first frame update

   public GameObject cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
     if(!Input.GetKey(KeyCode.F))
     {
    transform.position=cam.GetComponent<Transform>().position;
     }

    }
}
