using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    public LevelList lvlList;
    public float speed;
    
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
        for (int i = 0; i < prefablist.Count; ++i)
        {
            prefablist[i].transform.position = prefablist[i].transform.position + speed * Time.deltaTime * Vector3.down;
        }

        for (int i = 0; i < enemyList.Count; ++i)
        {
            enemyList[i].transform.position = enemyList[i].transform.position + speed * Time.deltaTime * Vector3.down;
        }
        
        GameObject delete = prefablist[0];
        if (delete.transform.position.y <= -50f)
        {
            float t = prefablist[prefablist.Count - 1].transform.position.y;
            randomIndex = Random.Range(0, lvlList.Levels.Count);
            level = Instantiate(lvlList.Levels[randomIndex], new Vector3(0f, 
                 t+30, 0), Quaternion.identity);
            prefablist.Add(level);
            
            randomIndex = Random.Range(0, lvlList.EnemyList.Count);
            enemy = Instantiate(lvlList.EnemyList[randomIndex], new Vector3(0f, t+7.5f, 0), Quaternion.identity);
            enemyList.Add(enemy);
            
            prefablist.RemoveAt(0);
            Destroy(delete);
        }
        
        delete = enemyList[0];
        if (delete.transform.position.y <= -30f)
        {
            enemyList.RemoveAt(0);
            Destroy(delete);
        }
    }
}
