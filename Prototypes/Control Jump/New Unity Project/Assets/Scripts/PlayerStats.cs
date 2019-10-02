using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int lives = 1;
    public int maxLives = 5;
    public Transform playerPos;
    public bool inAir;

    public float score;
    public float scoreMultiplier = 1f;

    public Rigidbody rb;

    public void Start()
    {
        inAir = false;
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        
        playerPos.position = transform.position;
    }



}
