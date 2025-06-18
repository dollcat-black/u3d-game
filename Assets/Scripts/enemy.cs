using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float health=100;
    public GameObject mainSystem;
    void Start()
    {
        mainSystem = GameObject.FindWithTag("mainSystem");


    
        for (int i = 0; i <= 50; i++)
        {
            if (i == 50)
            {
                Destroy(gameObject);
                break;
            }
            if (mainSystem.GetComponent<mainSystem>().looks[i] == null)
                {

                    mainSystem.GetComponent<mainSystem>().looks[i] = gameObject;
                    mainSystem.GetComponent<mainSystem>().currentNum = i + 1;
                    break;
                }
           
        }
       
    }

    // Update is called once per frame
        void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
        
    }
}
