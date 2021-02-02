using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class StickMove : MonoBehaviour
{
    private Camera cam;
    private Vector2 mouseDrag;
    void Start()
    {
        cam = Camera.main;
        mouseDrag = new Vector2();
    }

    private void OnMouseDrag()
    {
        mouseDrag.x = cam.ScreenToWorldPoint(Input.mousePosition).x;
        mouseDrag.y = cam.ScreenToWorldPoint(Input.mousePosition).y;
        transform.position = mouseDrag;
    }
}
