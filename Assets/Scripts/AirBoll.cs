﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBoll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            /*здесь у нас должен взываться и уничтожаться шарик
             должно вызываться UI окно, уведомляющее о проигрыше. Количество набранных поинтов заносятся в таблицу рекордов*/
        }
    }
    
    /*В оригинальной игре отмечалась визуально максимальная точка до которой удалось добраться
     Нужно подумать как ее реализовать здесь с постоянной генерацией
     
     Если я все правильно понимаю, в оригинальной игре у нас есть 45 префабов, которые выстраиваются вертикально вверх 
     А шарик поднимается по ним.
     Таким образом удается записать координаты шарика как какой либо рекорд
     
     Здесь же счет идет в секундах. Вопрос. Необходимо ли переделать все и нафиг бесконечную генерацию?
     Или же необходимо найти способ находить и рассчитывать необходимую точку в секундах?
     Нужно ли это вообще?*/
}
