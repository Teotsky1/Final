using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FloatingMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float x;
    [SerializeField] private float z;
    [SerializeField] private float q;
    [SerializeField] private float e;

    [Space]
    public float speed = 5f; 


    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; 
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        q = Input.GetKey(KeyCode.Q) ? 1f : 0f;
        e = Input.GetKey(KeyCode.E) ? 1f : 0f;
    }

    private void FixedUpdate()
    {
        Movement(x, z, q, e);
    }

    void Movement(float x , float y, float up, float down)
    {
        if(x != 0 || y != 0 || up !=0 ||  down != 0)
        {
            Vector3 Direction = (transform.forward * y + transform.right * x + transform.up * (up - down)).normalized;

            rb.velocity = Direction * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }



}
