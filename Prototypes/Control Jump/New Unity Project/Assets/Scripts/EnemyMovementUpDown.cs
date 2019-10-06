using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementUpDown : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 7f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    public float maxHeight = 5f;

    private float minUp;
    private float minDown;

    private Rigidbody enemyRb;

    bool facingUp = true;

    Vector3 pos, localScale;

    // Use this for initialization
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        minUp = transform.position.y + maxHeight;
        minDown = transform.position.y - maxHeight;
        pos = transform.position;
        localScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {

        CheckWhereToFace();

        if (facingUp)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
    }

    void CheckWhereToFace()
    {
        if (pos.y < minDown)
        {
            facingUp = true;
        }

        else if (pos.y > minUp)
        {
            facingUp = false;
        }
        /*
        if (((facingUp) && (transform.rotation.x < 0)) || ((!facingUp) && (transform.rotation.x > 180)))
        {
            transform.Rotate(180, 0, 0, Space.Self);
        }
        */
    }

    void MoveUp()
    {
        pos += enemyRb.velocity = new Vector3(transform.position.x, moveSpeed * Time.deltaTime, transform.position.z);
        transform.position = new Vector3(transform.position.x,pos.y , transform.position.z);
        //pos += transform.up * Time.deltaTime * moveSpeed;
        //transform.position = pos + transform.right; 
    }

    void MoveDown()
    {
        pos -= enemyRb.velocity = new Vector3(transform.position.x, moveSpeed * Time.deltaTime, transform.position.z);
        transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);
        //pos -= transform.up * Time.deltaTime * moveSpeed;
        //transform.position = pos + transform.right;
    }
}
