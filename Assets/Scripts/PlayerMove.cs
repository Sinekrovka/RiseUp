using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + speed * Time.deltaTime * Vector3.down;
    }
}
