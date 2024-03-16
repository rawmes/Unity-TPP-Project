using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float rotationSpeed;
    public bool isMoving;

    [SerializeField]
    private Transform cameraTransform=>Camera.main.transform;
    
    
    
    private void Update()
    {
        if (!isMoving)
        {
            return;
        }

        float targetAngle = cameraTransform.eulerAngles.y; //find the angle difference

        Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f); //turn it into rotation

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation,  rotationSpeed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        if(value != Vector2.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
}
