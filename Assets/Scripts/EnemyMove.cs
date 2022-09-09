using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject movementPoint;

    float speed = 3f;

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
        transform.LookAt(movementPoint.transform.position);
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 1.2f, transform.position.z);
    }
}
