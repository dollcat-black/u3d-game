using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDate : MonoBehaviour
{
    public float isknock=0;
    public float knockTime;
     public float knockTimeSet = 1f;
    public float playerHealth;
    public float playerHealthSet = 100;

    public Animator m_Animator;

    public GameObject spawnPoint;
    public float spawnTime;
    public float spawnTimeSet=2;
    // Start is called before the first frame update
    void Awake()
    {

m_Animator = GetComponent<Animator>();   
    }
    void Start()
    {
        knockTime = 0f;
        spawnTime = spawnTimeSet;
        playerHealth = playerHealthSet;
        knockTime = knockTimeSet;
    }

    // Update is called once per frame
    void Update()
    {




       

        m_Animator.SetFloat("isKnock", isknock);
        m_Animator.SetFloat("knockTime", knockTime);
        m_Animator.SetFloat("playerHealth", playerHealth);

         if (isknock > 0.5 && knockTime < 0)
        {
            isknock = 0f;
            knockTime = knockTimeSet;
        }
        
        knockTime = knockTime - 1 * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.M))
        {
            playerHealth = 0f;
        }
        if (playerHealth <= 0)
        {
            GetComponent<playermove>().freeze = true;
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0)
            {
                spawnTime = spawnTimeSet;
                playerHealth = playerHealthSet;
                GetComponent<playermove>().freeze = false;
                transform.position = spawnPoint.GetComponent<Transform>().position;
                GetComponent<Animator>().Play("walk&run");
            }
        }
    }
}
