using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    private ScoreManager scoreManager;
    private AudioSource audioSource;
    public AudioClip coinPickup;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            scoreManager.addPoints(100);
            scoreManager.GetCoin();
            audioSource.PlayOneShot(coinPickup);
            Destroy(this.gameObject);
        }
    }
}
