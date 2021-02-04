using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    private Text txt;
    public Fail fail;
    void Start()
    {
        txt = GetComponent<Text>();
    }
    private void FixedUpdate()
    {
        if (!fail.Failed)
        {
            txt.text = Convert.ToString(Convert.ToInt32(Time.time));
        }
    }
}
