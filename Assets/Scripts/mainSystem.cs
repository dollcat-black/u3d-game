using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mainSystem : MonoBehaviour
{
    public GameObject look;  
   public GameObject[] looks;

    public int currentNum=0;

    public GameObject playerObject;
    public int looksLength;

    public GameObject sq;

public float[] lookDistance;
    // Start is called before the first frame update
    void Awake()
    {
        playerObject=GameObject.FindWithTag("Player");
        looks = new GameObject[50];
        //looks = GameObject.FindGameObjectsWithTag("shootAble");
        looksLength = looks.Length;
        lookDistance = new float[looksLength]; 
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] k;
        k = new GameObject[looksLength];
        int l = 0;

        for (int j = 0; j < looksLength; j++)
        {
            if (looks[j] != null)
            {
                k[l] = looks[j];
                l++;
            }
        }
        looks = k;


        int maxNum = 0;

        for (int i = 0; i < looksLength; i++)
        {
           
            // Debug.Log(lookDistance.Length);
            //  Debug.Log(i);
            if (looks[i] == null && looks[maxNum] != null)
            {
                look = looks[maxNum];
            }


            if (looks[i] != null && looks[maxNum] != null)
                {
                    lookDistance[i] = (looks[i].GetComponent<Transform>().position - playerObject.GetComponent<Transform>().position).magnitude;
                    if (i > 0)
                    {
                        if (lookDistance[i] > lookDistance[maxNum])
                        {
                            look = looks[maxNum];
                           // Debug.Log(1);
                        }
                        else
                        {
                            look = looks[i];
                            maxNum = i;
                            //Debug.Log(2);
                        }
                    }
                }
            
            
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject obj = Instantiate(sq, playerObject.GetComponent<Transform>().position + playerObject.GetComponent<Transform>().up.normalized * 4, GetComponent<Transform>().rotation);
        }

    }
}
