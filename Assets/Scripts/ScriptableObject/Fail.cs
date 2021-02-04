using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Fail", menuName = "Fail Detected", order = 52)]
public class Fail : ScriptableObject
{
    [SerializeField] private bool failed;
    [SerializeField] private float yPosition;
    [SerializeField] private int countLevel;
    [SerializeField] private bool newRecord;

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

    public bool NewRecord
    {
        get => newRecord;
        set => newRecord = value;
    }
}
