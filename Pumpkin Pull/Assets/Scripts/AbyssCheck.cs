using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssCheck : MonoBehaviour
{
    // this script controls winning couldron that is pushed down 

    private MainMenu mainMenu;
    [SerializeField] private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu = gameManager.GetComponent<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // move to next scene when correct couldron is pushed down 
    {
        if (other.CompareTag("Keybox"))
        {
            mainMenu.NextScene();
        }
    }
}
