using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int totalEnemies = 25;
    int waitTime = 2;

    public GameObject enemyChar;
    public GameObject movePoint;
    GameObject[] Enemey = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {
        Enemey = new GameObject[totalEnemies];
        SpawnEnemeis();
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemeis();
    }

    void SpawnEnemeis()
    {
        for (int i = 0; i < totalEnemies ; i++)
        {
            Enemey[i] = Instantiate(enemyChar);
            Enemey[i].GetComponent<EnemyMove>().movementPoint = movePoint;
        }
    }

    void CheckEnemeis()
    {
        for (int i = 0; i < totalEnemies; i++) // List all enemeis
        {
            for (int k = 0; k < totalEnemies; k++) // Enemy being checked
            {
                if (i != k) // makes sure to not check against itself
                {
                    if (Vector3.Distance(Enemey[i].transform.position, Enemey[k].transform.position) < 2f)
                    {
                        Vector3 moveAway = Vector3.MoveTowards(Enemey[i].transform.position, Enemey[k].transform.position, - 2f);
                        Enemey[i].transform.Translate(moveAway * 0.5f * Time.deltaTime);

                       // Debug.Log("Enemy " + i + " Distance to " + "Enemy " + k + " is: " + Vector3.Distance(Enemies[i].transform.position, Enemies[k].transform.position));
                    }
                }
            }
        }
    }
}

