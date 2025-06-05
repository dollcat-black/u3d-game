using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpBox : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpSpeed=5f;
    public float tabanSound = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        /*RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.up, out hit, 0.1f))
                {
                    Debug.Log(1);
                   Vector3 aaa1 = new Vector3(hit.collider.GetComponent<Rigidbody>().velocity.x, 5, hit.collider.GetComponent<Rigidbody>().velocity.z);
                   hit.collider.GetComponent<Rigidbody>().velocity = aaa1;
                    transform.GetComponent<Animation>().Play("123");

            }*/

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(1);
            Vector3 aaa1 = new Vector3(collision.collider.GetComponent<Rigidbody>().velocity.x, jumpSpeed, collision.collider.GetComponent<Rigidbody>().velocity.z);
            collision.collider.GetComponent<Rigidbody>().velocity = aaa1;
            transform.GetComponent<Animation>().Play("123");
            tabanSound = 1f;
        }
    }
}

