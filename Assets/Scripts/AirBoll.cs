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
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("FAIL");
            failDetect.Failed = true;
            /*Уничтожаем объект
             Вызываем  UI
             Сохраняем результат*/
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
