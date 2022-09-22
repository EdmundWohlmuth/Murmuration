using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject movementPoint;
    public GameObject body;

    public float speed;
    float rotationSpeed;
    public int enemyNum;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2.5f, 6.5f);
        rotationSpeed = Random.Range(0.5f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    // --------------------- Movement ---------------------
     void Movement()
     {
        // OLD "SNAP TO ROTATION" CODE
        //transform.LookAt(movementPoint.transform.position);
        //transform.position += transform.forward * speed * Time.deltaTime;

        //NEW QUANTERNIONS
        Vector3 reletivePos = movementPoint.transform.position - transform.position; // Get total rotation requierd
        Quaternion rotation = Quaternion.LookRotation(reletivePos);                 // set the nessesary rotation ammount
        Quaternion current = transform.localRotation; //current rotation values

        transform.localRotation = Quaternion.Slerp(current, rotation, rotationSpeed * Time.deltaTime); // turn object over time
        transform.position += transform.forward * speed * Time.deltaTime; // moves character
     }

    void CheckEnemeis()
    {
        

        /*for (int i = 0; i < GetComponent<EnemyManager>().totalEnemies; i++) // List all enemeis
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
        }*/
    }

}
