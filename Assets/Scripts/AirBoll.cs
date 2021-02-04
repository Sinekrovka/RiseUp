using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBoll : MonoBehaviour
{
    private int countLevel;
    public Fail failDetect;
    // Start is called before the first frame update
    void Start()
    {
        countLevel = 0;
        failDetect.Failed = false;
        failDetect.NewRecord = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && !failDetect.Failed )
        {
            failDetect.Failed = true;
            if (failDetect.CountLevel < countLevel)
            {
                failDetect.NewRecord = true;
                failDetect.CountLevel = countLevel + 1;
            }
            /*Уничтожаем объект
             Вызываем  UI*/
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Level")
        {
            countLevel += 1;
        }
    }
}
