using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moevscript : MonoBehaviour
{
    public float turnSpeed = 100f;
    public float moveSpeed = 10f;
    public Vector3 point;
    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -1, 0);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 1, 0);
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
    }     
        
        /*float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0, zDirection);

        transform.position += moveDirection * speed;*/
    
}
