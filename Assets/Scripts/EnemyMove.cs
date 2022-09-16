using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject movementPoint;
    public GameObject body;

    float speed;
    float rotationSpeed;

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

}
