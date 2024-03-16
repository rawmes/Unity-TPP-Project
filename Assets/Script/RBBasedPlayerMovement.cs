using UnityEngine;
using UnityEngine.InputSystem;

public class RBBasedPlayerMovement : MonoBehaviour
{
    [SerializeField]
    Animator m_Animator;
    [SerializeField]
    GroundChecker m_GroundChecker;

    public Rigidbody rb;
    public GameObject camHolder;

    public float jumpValue;

    public float speed, senesitivity,maxForce;
    private Vector2 move;

    bool isMoving, canMove=true;
    [SerializeField]
    float slowFactor;

    


    private void FixedUpdate()
    {
        m_Animator.SetBool("isgrounded", m_GroundChecker.isGrounded);

        //find target velocity
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetvelocity = new(move.x, 0, move.y);
        
        targetvelocity *= speed;

        //Align Direction
        targetvelocity = transform.TransformDirection(targetvelocity);

        //calculate force
        Vector3 velocityChange = (targetvelocity - currentVelocity).normalized;

        //limit force
        Vector3.ClampMagnitude(velocityChange, maxForce);
        velocityChange.y = 0;

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
        
        
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if (!canMove) return;

        if(context.started) { isMoving = true; }
        if(context.canceled) { isMoving = false; }

        
        move = context.ReadValue<Vector2>();
       
        m_Animator.SetFloat("x", move.x);
        m_Animator.SetFloat ("y", move.y);

        move.x *= slowFactor;
        if (move.y < 0) move.y *= slowFactor;
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (m_GroundChecker.isGrounded)
        {
            m_Animator.SetTrigger("jump");
            rb.AddForce(new Vector3(0, jumpValue, 0), ForceMode.Impulse);

        }
    }

}
