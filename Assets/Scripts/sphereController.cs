using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;

    private int count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(Horizontal,0,Vertical);
        
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count++;
        }
        
    }

    // // Start is called before the first frame update
    // void Start()
    // {
    //     
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     
    // }
}
