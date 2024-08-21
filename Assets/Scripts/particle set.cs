using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleset : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position=particle.GetComponent<Transform>().position;
         transform.rotation=particle.GetComponent<Transform>().rotation;
        // GetComponent<ParticleSystem>().main.startRotation3D=new Vector3();
    }
}
