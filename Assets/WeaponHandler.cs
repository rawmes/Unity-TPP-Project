using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField]
    private InputActionReference armedControl;
    [SerializeField]
    private Animator animator;

    public GameObject weapon;
    public Transform holder;
    public Transform hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(armedControl.action.triggered)
        {
            animator.SetTrigger("equip");
        }
    }

    public void WeaponArmed()
    {
        weapon.transform.parent = hand;
        weapon.transform.position.Normalize();
    }
}
