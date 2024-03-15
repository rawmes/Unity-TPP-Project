using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float rotationSpeed;

    [SerializeField]
    private Transform cameraTransform=>Camera.main.transform;
    
    
    
    private void Update()
    {
        if (isStationary())
        {
            return;
        }

        float targetAngle = cameraTransform.eulerAngles.y; //find the angle difference

        Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f); //turn it into rotation

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation,  rotationSpeed);
    }

    public bool isStationary()
    {
        return false;
    }
}
