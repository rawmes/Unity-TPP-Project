using UnityEngine;
using UnityEngine.InputSystem;

public class RBBasedPlayerMovement : MonoBehaviour
{
    [SerializeField]
    Animator m_Animator;

    public Rigidbody rb;
    public GameObject camHolder;

    public float speed, senesitivity,maxForce;
    private Vector2 move, look;

    private float lookRotation;


    private void FixedUpdate()
    {
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

        rb.AddForce(velocityChange,ForceMode.VelocityChange);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        m_Animator.SetFloat("x", move.x);
        m_Animator.SetFloat ("y", move.y);
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

}
