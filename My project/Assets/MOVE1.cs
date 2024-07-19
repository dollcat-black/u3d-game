using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVE1 : MonoBehaviour
{
    // Start is called before the first frame update
 public GameObject cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=cam.GetComponent<Transform>().position+cam.GetComponent<Transform>().forward*10;
    }
    }
