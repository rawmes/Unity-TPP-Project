using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
   
    [SerializeField] private Animator animator;
    [SerializeField] private CinemachineInputProvider inputProvider;

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
   
    [SerializeField]
    private float rotationSpeed=4f;

    private CharacterController characterController;
    private Vector3 playerVelocity;
    public bool groundedPlayer=true;
    public Vector3 moveDirection;

    private Transform cameraMainTransform => Camera.main.transform;
    [SerializeField] private GroundChecker groundChecker;


    private void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = groundChecker.isGrounded;


        
        
        //Vector2 movement = movementControl.action.ReadValue<Vector2>();

        //Vector3 move = new Vector3(movement.x,0,movement.y);
        //move = cameraMainTransform.forward * move.z + cameraMainTransform.right*move.x; 
        //move.y = 0f;

        //animator.SetFloat("x", movement.x);
        //animator.SetFloat("y", movement.y);
        //characterController.Move(move * Time.deltaTime * playerSpeed);

        

        // Changes the height position of the player..
      

        
        characterController.Move(playerVelocity * Time.deltaTime);

        //if(movement !=  Vector2.zero)
        //{


        //    float targetAngle = Mathf.Atan2(movement.x,movement.y) * Mathf.Rad2Deg +cameraMainTransform.eulerAngles.y;
        //    Quaternion rotation = Quaternion.Euler(0f,targetAngle,0f);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        //}
    }
    private void FixedUpdate()
    {

        if (rb.velocity != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();

        Vector3 move = new Vector3(value.x, 0, value.y);
        moveDirection = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x;
        move.y = 0f;

        animator.SetFloat("x", value.x);
        animator.SetFloat("y", value.y);
        rb.AddForce(moveDirection * playerSpeed, ForceMode.Impulse);
        //characterController.Move(move * Time.deltaTime * playerSpeed);

       
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!groundChecker.isGrounded) return; 

       
    }

}
