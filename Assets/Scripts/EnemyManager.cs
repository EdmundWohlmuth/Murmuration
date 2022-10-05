using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager EM;
    public int totalEnemies = 25;

    public GameObject enemyChar;
    public GameObject movePoint;
    public GameObject[] AllEnemies = new GameObject[10];
    Vector3 startPos;

    [Range(0.5f, 5.0f)]
    public float neighborDistance;

    // Start is called before the first frame update
    void Start()
    {
        AllEnemies = new GameObject[totalEnemies];
        SpawnEnemeis();
    }

    void SpawnEnemeis()
    {
        for (int i = 0; i < totalEnemies; i++)
        {
            startPos = new Vector3(20, 1, 20);
            Vector3 pos = transform.position + new Vector3(Random.Range(-startPos.x, startPos.x),
                                                            startPos.y,
                                                            Random.Range(-startPos.z, startPos.z));
            // instantiate enemy
            AllEnemies[i] = Instantiate(enemyChar);
            AllEnemies[i].transform.parent = transform;
            AllEnemies[i].transform.position = pos;
            AllEnemies[i].GetComponent<EnemyMove>().movementPoint = movePoint;
            AllEnemies[i].GetComponent<EnemyMove>().enemyNum = i;
        }
        EM = this;
    }   
}

