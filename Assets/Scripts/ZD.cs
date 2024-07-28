using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZD : MonoBehaviour
{
    // Start is called before the first frame update
    private float time=3;

    void Start()
    {
      time=3;  
    

    }

    // Update is called once per frame
    void Update()
    {


        Destroy(gameObject,time);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="shootAble"&&other.GetComponent<enemy>()==true)
        {

            other.GetComponent<enemy>().health-=10;
        }
        
      
         Destroy(gameObject);
    }
}
