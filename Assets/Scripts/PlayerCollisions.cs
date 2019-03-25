using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bounceOnEnemy = 50f;
    public AudioClip stompSound;
    private AudioSource audioSource;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();   
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "EnemyHitBox")
        {
            audioSource.PlayOneShot(stompSound);
            rb.velocity = new Vector2 (rb.velocity.x, bounceOnEnemy);

            EnemyScript enemy = other.gameObject.GetComponentInParent(typeof(EnemyScript)) as EnemyScript;
            scoreManager.addPoints(100);
            Destroy(enemy.gameObject);
        }
       
    }
}
