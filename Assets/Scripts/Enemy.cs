using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (transform.position.y <= 5f)
        {
            int countChild = transform.childCount;

            for (int i = 0; i < countChild; ++i)
            {
                transform.GetChild(i).GetComponent<Rigidbody2D>().gravityScale = 0.3f;
            }
        }
    }
}
