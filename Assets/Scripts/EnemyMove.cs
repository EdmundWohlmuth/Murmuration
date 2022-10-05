using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject movementPoint;
    public GameObject body;
    Rigidbody rb;

    public float speed;
    float rotationSpeed;
    public int enemyNum;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(4f, 6.5f);
        rotationSpeed = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        SetRules();
        Movement();
    }

    // --------------------- Movement -------------------------------
     void Movement()
     {
        Vector3 reletivePos = movementPoint.transform.position - transform.position; // Get total rotation requierd
        Quaternion rotation = Quaternion.LookRotation(reletivePos);                 // set the nessesary rotation ammount
        Quaternion current = transform.localRotation; //current rotation values

        transform.localRotation = Quaternion.Slerp(current, rotation, rotationSpeed * Time.deltaTime); // turn object over time
        transform.position += transform.forward * speed * Time.deltaTime; // moves character
     }

    void SetRules()
    {
        GameObject[] flock;
        flock = EnemyManager.EM.AllEnemies;
        Vector3 center = Vector3.zero;
        Vector3 avoid = Vector3.zero;
        float distance;

        foreach (GameObject Ei in flock)
        {
            if (Ei != gameObject)
            {
                distance = Vector3.Distance(Ei.transform.position, transform.position);
                if (distance <= EnemyManager.EM.neighborDistance)
                {
                    center += Ei.transform.position;
                    if (distance < 1.0f)
                    {
                        avoid = avoid + (transform.position - Ei.transform.position);
                        Debug.Log(avoid);
                    }
                }
            }
        }
    }

}
