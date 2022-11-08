using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    
    public CharacterController characterController;
    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    public Transform cam;
    Vector3 moveVector;
    private Animator animator;
    
    MainMenu mainMenu;
    [SerializeField] GameObject gameManager;


    float turnSmoothVelocity;


    // Start is called before the first frame update
    void Start()
    {
        mainMenu = gameManager.GetComponent<MainMenu>();
        //Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        


        if (direction.magnitude >= 0.1f &&  characterController.isGrounded == true)
        {
            //animator.SetFloat("Speed", direction.magnitude);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Abyss") || other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            //Cursor.lockState = CursorLockMode.None;
            mainMenu.GameOver();
        }
    }
}
