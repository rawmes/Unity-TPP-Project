using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public LayerMask ignoreMe;
    public bool isGrounded;
    public float distance;
    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distance,~ignoreMe) ;
        Debug.DrawRay(transform.position, -Vector3.up, Color.green,distance);
    }
}
