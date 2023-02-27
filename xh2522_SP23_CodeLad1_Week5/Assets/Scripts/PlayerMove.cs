using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D playerRigidbody2D;
    public float flapStrength = 5;
    public bool playerIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)==true && playerIsAlive==true)
        {
            playerRigidbody2D.velocity = Vector2.up * flapStrength;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.Instance.gameOver();
        playerIsAlive = false;
    }
}
