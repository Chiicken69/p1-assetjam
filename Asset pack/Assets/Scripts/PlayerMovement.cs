using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float run_speed;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb == null) return;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(transform.position + new Vector3(Input.GetAxis("Horizontal") * run_speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * run_speed * Time.deltaTime));
        }
        else rb.MovePosition( transform.position + new Vector3( Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime) );

    }
}
