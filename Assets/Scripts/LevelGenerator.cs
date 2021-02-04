using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class LevelGenerator : MonoBehaviour
{
    public LevelList lvlList;
    public float speed;
    public Fail failDetect;
    public GameObject records;
    public Transform boll;
    
    private int randomIndex;
    private List<GameObject> prefablist;
    private List<GameObject> enemyList;
    private List<GameObject> failList;
    private GameObject level;
    private GameObject enemy;
    private int countLevels;
    private bool detect;
    
    void Start()
    {
        detect = false;
        countLevels = 0;
        
        prefablist = new List<GameObject>();
        enemyList = new List<GameObject>();
        failList = new List<GameObject>();
        
        float yGenerate = 10f;
        
        for (int i = 0; i < 3; ++i)
        {
            randomIndex = Random.Range(0, lvlList.Levels.Count);
            level = Instantiate(lvlList.Levels[randomIndex], new Vector3(0f, yGenerate, 0), Quaternion.identity);
            countLevels++;
            
            randomIndex = Random.Range(0, lvlList.EnemyList.Count);
            enemy = Instantiate(lvlList.EnemyList[randomIndex], new Vector3(0f, yGenerate, 0), Quaternion.identity);
            
            enemyList.Add(enemy);
            prefablist.Add(level);
            yGenerate += 30f;
            
            if (countLevels == failDetect.CountLevel)
            {
                Vector3 rec = boll.position - new Vector3(0, failDetect.YPosition, 0);
                Debug.Log(rec.y);
                Debug.Log(countLevels);
                Instantiate(records, level.transform.position+rec, Quaternion.identity, level.transform);
            }
        }

        if (PlayerPrefs.HasKey("PositionY") && PlayerPrefs.HasKey("Count"))
        {
            failDetect.CountLevel = PlayerPrefs.GetInt("Count");
            failDetect.YPosition = PlayerPrefs.GetFloat("PositionY");
        }
    }

    private void FixedUpdate()
    {
        if (!failDetect.Failed)
        {
            MoveBackground();
            MoveEnemy();
            GenerateLevel();
        }
        else
        {
            if (!detect && failDetect.NewRecord)
            {
                failDetect.YPosition = prefablist[0].transform.position.y;
                detect = true;
                PlayerPrefs.SetFloat("PositionY", failDetect.YPosition);
                PlayerPrefs.SetInt("Count", failDetect.CountLevel);
                PlayerPrefs.Save();
            }
            else if (!detect)
            {
                failList.Add(enemyList[0]);
                failList.Add(enemyList[1]);
                detect = true;
            }
            else
            {
                if (failList.Count > 0)
                {
                    Rigidbody2D rb2d_ = failList[0].transform.GetChild(0).GetComponent<Rigidbody2D>();
                    if (rb2d_.position.y < 20f)
                    {
                        for (int i = 0; i < failList[0].transform.childCount; ++i)
                        {
                            rb2d_  = failList[0].transform.GetChild(i).GetComponent<Rigidbody2D>();
                            rb2d_.MovePosition(rb2d_.position + Vector2.down *speed*Time.deltaTime);
                        }

                        if (rb2d_.position.y <= -30f)
                        {
                            GameObject g = failList[0];
                            failList.RemoveAt(0);
                            Destroy(g);
                        }
                    }

                    if (failList.Count > 1)
                    {
                        rb2d_ = failList[1].transform.GetChild(0).GetComponent<Rigidbody2D>();
                        if (rb2d_.position.y < 20f)
                        {
                            for (int i = 1; i < failList[1].transform.childCount; ++i)
                            {
                                rb2d_  = failList[1].transform.GetChild(i).GetComponent<Rigidbody2D>();
                                rb2d_.MovePosition(rb2d_.position + Vector2.down *speed*Time.deltaTime);
                            }

                            if (rb2d_.position.y <= -30f)
                            {
                                GameObject g = failList[1];
                                failList.RemoveAt(1);
                                Destroy(g);
                            }
                        }
                    }
                }
            }
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
            countLevels++;
            float t = prefablist[prefablist.Count - 1].transform.position.y +30f;
            randomIndex = Random.Range(0, lvlList.Levels.Count);
            level = Instantiate(lvlList.Levels[randomIndex], new Vector3(0f, 
                t, 0), Quaternion.identity);
            prefablist.Add(level);
            
            if (countLevels == failDetect.CountLevel)
            {
                Vector3 rec = boll.position - new Vector3(0, failDetect.YPosition, 0);
                Instantiate(records, level.transform.position+rec, Quaternion.identity, level.transform);
                
            }
            
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
