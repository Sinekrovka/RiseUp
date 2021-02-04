using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    public LevelList lvlList;
    public float speed;
    public Fail failDetect;
    
    private int randomIndex;
    private List<GameObject> prefablist;
    private List<GameObject> enemyList;
    private GameObject level;
    private GameObject enemy;
    
    void Start()
    {
        prefablist = new List<GameObject>();
        enemyList = new List<GameObject>();
        float yGenerate = 10f;
        for (int i = 0; i < 3; ++i)
        {
            randomIndex = Random.Range(0, lvlList.Levels.Count);
            level = Instantiate(lvlList.Levels[randomIndex], new Vector3(0f, yGenerate, 0), Quaternion.identity);
            
            randomIndex = Random.Range(0, lvlList.EnemyList.Count);
            enemy = Instantiate(lvlList.EnemyList[randomIndex], new Vector3(0f, yGenerate, 0), Quaternion.identity);
            
            enemyList.Add(enemy);
            prefablist.Add(level);
            yGenerate += 30f;
        }
    }

    private void FixedUpdate()
    {
        MoveBackground();
        MoveEnemy();
        GenerateLevel();
        if (failDetect)
        {
            /*здесь высчитываем координаты где шарик лопнул и сохраняем их для создания следующего чекпоинта*/
        }
        
    }

    private void MoveBackground()
    {
        for (int i = 0; i < prefablist.Count; ++i)
        { 
            prefablist[i].transform.position = prefablist[i].transform.position + Vector3.down * speed * Time.deltaTime;
        }
    }

    private void MoveEnemy()
    {
        for (int i = 0; i < enemyList.Count; ++i)
        {
            int countChild = enemyList[i].transform.childCount;
            GameObject enemy = enemyList[i].gameObject; 
            for (int j = 0; j < countChild; ++j)
            {
                Rigidbody2D rb2d = enemy.transform.GetChild(j).GetComponent<Rigidbody2D>();
                rb2d.MovePosition(rb2d.position + Vector2.down *speed*Time.deltaTime);
            }
        }
    }

    private void GenerateLevel()
    {
        GameObject delete = prefablist[0];
        if (delete.transform.position.y <= -30f)
        {
            float t = prefablist[prefablist.Count - 1].transform.position.y +30f;
            randomIndex = Random.Range(0, lvlList.Levels.Count);
            
            level = Instantiate(lvlList.Levels[randomIndex], new Vector3(0f, 
                t, 0), Quaternion.identity);
            prefablist.Add(level);
            
            randomIndex = Random.Range(0, lvlList.EnemyList.Count);
            enemy = Instantiate(lvlList.EnemyList[randomIndex], new Vector3(0f, t, 0), Quaternion.identity);
            enemyList.Add(enemy);
            prefablist.RemoveAt(0);
            Destroy(delete);
        }
        
        delete = enemyList[0];
        if (delete.transform.GetChild(0).GetComponent<Rigidbody2D>().position.y <= -30f)
        {
            enemyList.RemoveAt(0);
            Destroy(delete);
        }
    }
}
