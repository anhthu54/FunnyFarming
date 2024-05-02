using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField]
    private GameObject joystick;

    private PlayerAnimator playerAnimator;

    private Rigidbody rb;



    [Header(" Setting ")]
    [SerializeField]
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement(){
        Vector3 move = joystick.GetComponent<JoystickController>().GetMoveVector() * speed * Time.deltaTime/ Screen.width;
        move.z = move.y;
        move.y = 0;
        rb.MovePosition(transform.position + move);

        playerAnimator.ManageAnimations(move);
    }

}
