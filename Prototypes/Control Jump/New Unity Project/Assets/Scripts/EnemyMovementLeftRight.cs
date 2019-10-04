using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementLeftRight : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    public float maxWidth = 15f;

    private float minLeft;
    private float minRight;

    private Rigidbody enemyRb;

    bool facingRight;

    Vector3 pos;

    
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        maxWidth = 5f;
        pos = transform.position;
        minLeft = transform.position.x + maxWidth;
        minRight = transform.position.x - maxWidth;
        moveSpeed = 5f;
        facingRight = true;
    }


    void Update()
    {
        
        //enemyRb.velocity = new Vector3(moveSpeed * Time.deltaTime ,transform.position.y, transform.position.z);
        /*
        if (pos.x >= minRight)
        {
            MoveLeft();
            //moveSpeed = -50f;
        }

        if(pos.x <= minLeft)
        {
            MoveRight();
            //moveSpeed = 50f;
        }
        */
        CheckWhereToFace();
        
        if (facingRight)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
        
    }

    void CheckWhereToFace()
    {

        if (pos.x <= minRight)
        {
            facingRight = true;


        }

        else if (pos.x >= minLeft)
        {
            facingRight = false;
        }        
        
        if (((facingRight) && (transform.rotation.y < 0)) || ((!facingRight) && (transform.rotation.y > 180)))
        {
            transform.Rotate(0, 180, 0, Space.Self);
        }
        
        

    }

    void MoveRight()
    {
        //enemyRb.velocity = new Vector3(moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up; 
    }

    void MoveLeft()
    {
        //enemyRb.velocity = new Vector3(-moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up; 
    }

}
