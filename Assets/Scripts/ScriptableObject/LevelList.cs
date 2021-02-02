using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Levels List", menuName = "Levels List", order = 51)]
public class LevelList : ScriptableObject
{
    [SerializeField] private List<GameObject> levels;
    [SerializeField] private List<GameObject> enemyList;

    public List<GameObject> Levels => levels;
    public List<GameObject> EnemyList => enemyList;
}
