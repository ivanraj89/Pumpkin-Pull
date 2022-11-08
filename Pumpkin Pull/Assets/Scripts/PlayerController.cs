using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private Transform cam;
    [SerializeField] private Vector3 moveVector;
    [SerializeField] GameObject gameManager;

    private MainMenu mainMenu;


    float turnSmoothVelocity;


    // Start is called before the first frame update
    void Start()
    {
        mainMenu = gameManager.GetComponent<MainMenu>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        


        if (direction.magnitude >= 0.1f &&  characterController.isGrounded == true) // script for movement, rotation and smoothened rotation  
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            characterController.Move(direction * speed * Time.deltaTime);

            
        }
        else
        {
            moveVector += Physics.gravity;
            characterController.Move(moveVector * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other) // destroy player when it hits the bottom
    {
        if (other.CompareTag("Abyss") || other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            mainMenu.GameOver();
        }
    }
}
