using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockScript : MonoBehaviour
{
    public GameObject spawnItem;
    public int maxHitCount = 1;
    private int timesHit = 0;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponentInParent(typeof(Animator)) as Animator;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(timesHit < maxHitCount)
        {
            if(other.gameObject.tag == "Player")
            {
                timesHit += 1;
                
                Vector3 temp = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);

                Instantiate(spawnItem, temp, this.transform.rotation);

                if(timesHit == maxHitCount)
                {
                    anim.SetBool("isEmpty", true);
                }
                
            }
        }
        
    }
}
