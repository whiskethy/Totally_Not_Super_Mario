using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMushroom : MonoBehaviour
{
    private PlayerHealthManager healthManager;
    private Rigidbody2D rb;
    public float moveSpeed;

    public AudioSource audioSource;
    public AudioClip appearanceSound;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        audioSource.PlayOneShot(appearanceSound);
        healthManager = FindObjectOfType<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            healthManager.GiveHealth();
            Destroy(this.gameObject);
        }
    }
}
