using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDate : MonoBehaviour
{
    public float isknock=0;
    public float knockTime = 1f;
    public float playerHealth = 100;

    public Animator m_Animator;
    // Start is called before the first frame update
    void Awake()
    {

m_Animator = GetComponent<Animator>();   
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isknock > 0.5f)
        {
            isknock = 0f;
           
        }
        knockTime = knockTime - 1*Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.C) && knockTime < 0)
        {
            isknock = 1f;
            knockTime = 1f;
        }
       
            m_Animator.SetFloat("isKnock", isknock);
        m_Animator.SetFloat("knockTime", knockTime);
 
    }
}
