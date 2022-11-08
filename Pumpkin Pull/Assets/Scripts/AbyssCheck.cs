using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssCheck : MonoBehaviour
{
    MainMenu mainMenu;
    [SerializeField] GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu = gameManager.GetComponent<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Keybox"))
        {
            mainMenu.NextScene();
        }
    }
}
