using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSinLeftRight : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    public float maxWidth = 5f;

    private float minLeft;
    private float minRight;

    bool facingRight = true;

    Vector3 pos, localScale;

    // Use this for initialization
    void Start()
    {
        minLeft = transform.position.x + maxWidth;
        minRight = transform.position.x - maxWidth;
        pos = transform.position;
        localScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {

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
        if (pos.x < minRight)
        {
            facingRight = true;

        }

        else if (pos.x > minLeft)
        {
            facingRight = false;
        }

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))

        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;

    }

    void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
