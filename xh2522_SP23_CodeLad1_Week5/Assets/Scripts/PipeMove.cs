using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float pipeMoveSpeed = 2;
    public float deadZone = -10;
    
    //private Vector3 movementVector = Vector3.zero;(question about it)
    
    // Start is called before the first frame update
    void Start()
    {
        //movementVector = Vector3.left * pipeMoveSpeed * Time.deltaTime;(Question about it)
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
        
        transform.position 
            = transform.position + (Vector3.left * pipeMoveSpeed * Time.deltaTime);

    }
}
