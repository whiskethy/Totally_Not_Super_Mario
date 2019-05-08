using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int maxHitCount = 1;
    private int timesHit = 0;

    private AudioSource audioSource;
    public AudioClip breakSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();  
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(timesHit < maxHitCount)
        {
            if(other.gameObject.tag == "Player")
            {
                PlayerHealthManager healthMan = FindObjectOfType<PlayerHealthManager>();
                if(healthMan.state == PlayerHealthManager.PlayerState.big)
                {
                    timesHit += 1;
                    
                    if(timesHit == maxHitCount)
                    {
                        audioSource.PlayOneShot(breakSound);
                        Destroy(this.gameObject.transform.parent.gameObject);
                    }
                }
                
                
            }
        }
        
    }
}
//this is period 4 and this is a sample edit