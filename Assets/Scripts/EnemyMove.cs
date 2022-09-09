using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject movementPoint;

    float speed = 5f;
    float rotationSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
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
