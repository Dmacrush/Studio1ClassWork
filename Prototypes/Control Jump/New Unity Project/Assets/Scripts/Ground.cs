using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Transform playerPos;
    private Transform groundPos;

    void Start()
    {
        groundPos = GetComponent<Transform>();
    }
    public void Update()
    {
        groundPos.position = new Vector3(playerPos.position.x, transform.position.y, transform.position.z);
    }

}
