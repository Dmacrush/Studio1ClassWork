using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float followSpeed = 10;
    public float followOffset = 0;

    private Transform playerPos;

    private void Start()
    {
        playerPos = target.GetComponent<Transform>();
    }

    private void Update()
    {
        if (playerPos.localPosition.y >= followOffset)
        {
            Vector3 posToFollow = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = new Vector3(target.transform.position.x+3, target.transform.position.y+2, target.transform.position.z-10);
                //Vector3.Lerp(transform.position, posToFollow, followSpeed * Time.deltaTime);
        }
    }
}
