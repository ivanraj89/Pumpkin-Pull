using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    public GameObject playerLocation;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLocation != null)
        {
            enemyRb.AddForce((playerLocation.transform.position - transform.position).normalized * speed);
        }
        else
        {
            gameObject.SetActive(false);
            
        }
               
    }

}
