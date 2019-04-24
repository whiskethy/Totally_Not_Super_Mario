using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int maxHitCount = 1;
    private int timesHit = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(timesHit < maxHitCount)
        {
            if(other.gameObject.tag == "Player")
            {
                timesHit += 1;
                
                if(timesHit == maxHitCount)
                {
                    Destroy(this.gameObject.transform.parent.gameObject);
                }
                
            }
        }
        
    }
}
//this is perio 4 and this is a sample edit