using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int totalEnemies = 25;
    bool isWaiting;

    public GameObject enemyChar;
    public GameObject movePoint;
    GameObject[] Enemey = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {
        isWaiting = true;
        Enemey = new GameObject[totalEnemies];
        SpawnEnemeis();
    }

    // Update is called once per frame
    void Update()
    {
       // CheckEnemeis();
    }

    void SpawnEnemeis()
    {
        StartCoroutine(SpawnDelay());
    }

    void CheckEnemeis()
    {
        for (int i = 0; i < GetComponent<EnemyManager>().totalEnemies; i++) // List all enemeis
        {
            for (int k = 0; k < GetComponent<EnemyManager>().totalEnemies; k++) // Enemy being checked
            {
                if (i != k) // makes sure to not check against itself
                {
                    if (Vector3.Distance(Enemey[i].transform.position, Enemey[k].transform.position) <= 3.5f)
                    {
                        Vector3 enemyI = new Vector3(Enemey[i].transform.position.x, 0, Enemey[i].transform.position.z);
                        Vector3 enemyK = new Vector3(Enemey[k].transform.position.x, 0, Enemey[k].transform.position.z);

                        Vector3 moveAway = enemyI -= enemyK;
                        Enemey[i].transform.Translate(moveAway * Time.deltaTime);

                        // Debug.Log("Enemy " + i + " Distance to " + "Enemy " + k + " is: " + Vector3.Distance(Enemies[i].transform.position, Enemies[k].transform.position));
                    }
                }
            }
        }
    }

    IEnumerator SpawnDelay()
    {
        while (isWaiting)
        {
            for (int i = 0; i < totalEnemies; i++)
            {
                // set color
                /* red = Random.Range(0f, 255f);
                 green = Random.Range(0f, 255f);
                 blue = Random.Range(0f, 255f);
                 Color color = new Color(red, green, blue); */

                // instantiate enemy
                Enemey[i] = Instantiate(enemyChar);
                Enemey[i].GetComponent<EnemyMove>().movementPoint = movePoint;
                Enemey[i].GetComponent<EnemyMove>().enemyNum = i;
                // Enemey[i].GetComponent<EnemyMove>().body.GetComponent<Renderer>().material.color = color;

                yield return new WaitForSeconds(2);
            }
            isWaiting = false;
        }     
    }


}

