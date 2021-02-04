using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    private Text txt;
    void Start()
    {
        txt = GetComponent<Text>();
    }
    private void FixedUpdate()
    {
        txt.text = Convert.ToString(Convert.ToInt32(Time.time));
    }
}
