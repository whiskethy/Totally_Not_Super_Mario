using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int health = 1;

    private PlayerHealthManager healthManager;
    public float moveSpeed = -150;
    private Rigidbody2D rb;
    public bool facingRight = false;

    private Animator anim;

    public float downCheckDistance = .6f;
    public float wallCheckDistance = .6f;
    public bool touchingWall;
    public bool forwardIsGround;
    public LayerMask whatIsGround;
    public RaycastHit2D forwardCheck;
    public RaycastHit2D wallCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthManager = FindObjectOfType<PlayerHealthManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed * Time.deltaTime, rb.velocity.y);
        DoChecks();
        if(touchingWall || !forwardIsGround)
        {
            Flip();
        }
    }


    public virtual void DoChecks()
    {
        if(facingRight)
        {
            wallCheck = Physics2D.Raycast(transform.position, Vector2.right, wallCheckDistance, whatIsGround);
            forwardCheck = Physics2D.Raycast(transform.position + new Vector3(.5f,0,0), Vector2.down, downCheckDistance, whatIsGround);
        }
        else
        {
            wallCheck = Physics2D.Raycast(this.transform.position, Vector2.left, wallCheckDistance, whatIsGround);
            forwardCheck = Physics2D.Raycast(transform.position + new Vector3(-.5f,0,0), Vector2.down, downCheckDistance, whatIsGround);
        }

        if(wallCheck.collider != null){ touchingWall = true;}else{touchingWall = false;}
        if(forwardCheck.collider != null){ forwardIsGround = true;}else{forwardIsGround = false;}
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            healthManager.DamagePlayer();
        }

        if(other.gameObject.tag == "Enemy")
        {
            Flip();
        }
    }
    
    private void Flip()
    {

        moveSpeed = -moveSpeed;

        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void takeDamage()
    {
        health = health - 1;  

        if(health <= 0)
        {
            anim.SetBool("isDead", true);
            moveSpeed = 0f;
            this.GetComponent<Collider2D>().enabled = false;
            //Destroy(this.gameObject);
        }
    }
}
