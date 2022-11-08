using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    //this script controls the pumpkin

    [SerializeField] private GameObject playerLocation;
    [SerializeField] private float speed = 3.0f;

    private Rigidbody enemyRb;

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
            enemyRb.AddForce((playerLocation.transform.position - transform.position).normalized * speed); // adding force to the pumpkin to continuously move towards player
        }
        else
        {
            gameObject.SetActive(false);
            
        }
               
    }

}
