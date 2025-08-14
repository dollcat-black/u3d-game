using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class movetable : MonoBehaviour
{

    public Vector3 startPo;
    public Vector3 endPo;

    public float lenth=5;

    public float speed = 5;

    public float speedset;

    public float fx = 0;

    public GameObject rotatoTable;
    // Start is called before the first frame update
    void Start()
    {
        startPo = transform.position;
       
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 a = new Vector3(startPo.x, startPo.y, startPo.z + lenth);
        endPo = a;
        if (transform.position.z - startPo.z <= 0)
        {
            fx = 1;

        }

        if (fx > 0)
        {
            if (transform.position.z - (startPo.z + lenth / 2) <= 0)
            { speedset = Mathf.Abs(transform.position.z - startPo.z) / (lenth / 2); }
            else
            {
                speedset = Mathf.Abs(transform.position.z - endPo.z) / (lenth / 2);
            }

            if (speedset < 0.2)
            {
                speedset = 0.2f;
            }
            transform.position = Vector3.MoveTowards(transform.position, endPo, speed * speedset * Time.deltaTime);
        }

        if (transform.position.z - endPo.z >= 0)
        {
            fx = -1;
        }

        if (fx < 0)
        {
            if (transform.position.z - (endPo.z - lenth / 2) >= 0)
            { speedset = Mathf.Abs(transform.position.z - endPo.z) / (lenth / 2); }
            else
            {
                speedset = Mathf.Abs(transform.position.z - startPo.z) / (lenth / 2);
            }


            if (speedset < 0.2)
            {
                speedset = 0.2f;
            }
            transform.position = Vector3.MoveTowards(transform.position, startPo, speed * speedset * Time.deltaTime);
        }

    

    }
}
