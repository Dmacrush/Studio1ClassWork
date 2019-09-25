using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementUpDownSin : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;


    public float maxHeight = 5f;

    private float minUp;
    private float minDown;

    bool facingUp = true;

    Vector3 pos, localScale;

    // Use this for initialization
    void Start()
    {
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

        if (((facingUp) && (localScale.x < 0)) || ((!facingUp) && (localScale.x > 0)))

        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;

    }

    void MoveUp()
    {
        pos += transform.up * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude; 
    }

    void MoveDown()
    {
        pos -= transform.up * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
