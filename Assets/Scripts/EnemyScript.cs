﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private PlayerHealthManager healthManager;
    public float moveSpeed = -200;
    private Rigidbody2D rb;
    public bool facingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthManager = FindObjectOfType<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed * Time.deltaTime, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            healthManager.DamagePlayer();
        }

        if(other.gameObject.layer == 9)
        {
            moveSpeed = -moveSpeed;
            Flip();
        }

        if(other.gameObject.tag == "Enemy")
        {
            moveSpeed = -moveSpeed;
            Flip();
        }
    }
    
    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}