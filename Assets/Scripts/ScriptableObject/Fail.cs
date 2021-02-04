using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Fail", menuName = "Fail Detected", order = 52)]
public class Fail : ScriptableObject
{
    private bool failed;
    private float yPosition;
    private int countLevel;

    public bool Failed
    {
        get => failed;
        set => failed = value;
    }

    public float YPosition
    {
        get => yPosition;
        set => yPosition = value;
    }

    public int CountLevel
    {
        get => countLevel;
        set => countLevel = value;
    }
}
