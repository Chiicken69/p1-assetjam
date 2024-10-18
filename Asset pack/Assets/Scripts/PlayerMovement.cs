using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float run_speed;
    [SerializeField] Animator animator;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb == null) return;


        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.speed = run_speed/speed;

            movement.x = Input.GetAxis("Horizontal") * run_speed * Time.deltaTime;
            if (movement.x == 0) movement.z = Input.GetAxis("Vertical") * run_speed * Time.deltaTime;
        }
        else
        {
            animator.speed = 1;

            movement.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            if (movement.x == 0) movement.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        }

        

        if (movement == Vector3.zero) animator.SetBool("Moving", false);
        else animator.SetBool("Moving", true);

        animator.SetFloat("x", movement.x);
        animator.SetFloat("z", movement.z);


        rb.MovePosition(transform.position + movement);
    }
}
