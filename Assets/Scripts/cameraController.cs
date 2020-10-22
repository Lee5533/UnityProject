using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject sphere;
    public Vector3 offset;
    void Start()
    {
        offset = transform.position - sphere.transform.position;
    }

    void LateUpdate()
    {
        transform.position = offset + sphere.transform.position;
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
