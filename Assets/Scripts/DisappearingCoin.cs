using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingCoin : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveUpSpeed;

    private float startTime = 0;
    public float waitFor = .1f;

    private AudioSource audioSource;
    public AudioClip coinSound;

    private ScoreManager scoreManager;
    public int pointsToGive = 200;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;

        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        audioSource.PlayOneShot(coinSound);

        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f, moveUpSpeed * Time.fixedDeltaTime);

        if(Time.time - startTime > waitFor)
        {
            scoreManager.addPoints(pointsToGive);
            scoreManager.GetCoin();
            Destroy(this.gameObject);
        }
    }
}
