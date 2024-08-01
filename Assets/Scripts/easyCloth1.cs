using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easyCloth1 : MonoBehaviour
{
public GameObject bone1;

public GameObject bone2;
    public GameObject bone;
    public GameObject boneS1;
    public GameObject boneS2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=bone.GetComponent<Transform>().position;
   bone1.GetComponent<Transform>().position=boneS1.GetComponent<Transform>().position;
  bone2.GetComponent<Transform>().position=boneS2.GetComponent<Transform>().position;
    }
}
