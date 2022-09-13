using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    int totalEnemies = 10;
    int waitTime = 2;

    public GameObject Enemey;
    public GameObject movePoint;
    GameObject[] Enemies = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {
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
            Enemies[i] = Instantiate(Enemey);
            Enemies[i].GetComponent<EnemyMove>().movementPoint = movePoint;
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
                    //Debug.Log(i + " " + k);
                    // checks to see if the enemy needs to move away from its peers

                    // X
                    if (Enemies[i].transform.position.x <
                        Enemies[k].transform.position.x + 2 &&
                        Enemies[i].transform.position.x !>
                        Enemies[k].transform.position.x + 2)
                    {
                        //++
                        
                    }
                    else if (Enemies[i].transform.position.x >
                        Enemies[k].transform.position.x - 2 &&
                        Enemies[i].transform.position.x !<
                        Enemies[k].transform.position.x - 2)
                    {
                        //--
                    }

                    // Z
                    if (Enemies[i].transform.position.z >
                        Enemies[k].transform.position.z + 2)
                    {
                        
                        //++
                    }
                    else if (Enemies[i].transform.position.z <
                        Enemies[k].transform.position.z - 2)
                    {
                        //--
                    }
                }
            }
        }
    }
}

