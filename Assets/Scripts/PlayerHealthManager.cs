using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{

    public enum PlayerState { little, big, fire, invincible }
    public PlayerState state;

    public GameObject player;
    public Rigidbody2D rb;
    public int playerHealth;

    [Header("Animation")]
    public RuntimeAnimatorController littleAnim;
    public RuntimeAnimatorController bigAnim;
    private Animator anim;

    [Header("Audio")]
    public AudioClip growSound;
    public AudioClip shrinkSound;
    public AudioClip deathSound;
    private AudioSource audioSource;

    [Header("Colliders")]
    public BoxCollider2D boxCollider;
    public GameObject groundChecker;

    // Start is called before the first frame update
    void Start()
    {
        state = PlayerState.little;
        playerHealth = 1;
        anim = player.GetComponent<Animator>();
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    public void DamagePlayer()
    {
        //playerHealth = playerHealth -1;
        playerHealth--;

        if(playerHealth <= 0)
        {
            KillPlayer();
        }
        else
        {
            TransitionLittle();
        }

    }
    public void GiveHealth()
    {
        playerHealth = 2;
        if(state == PlayerState.little)
        {
            TransitionBig();
        }
        
    }

    private void TransitionBig()
    {
        state = PlayerState.big;
        audioSource.PlayOneShot(growSound);

        anim.runtimeAnimatorController = bigAnim as RuntimeAnimatorController;

        boxCollider.size = new Vector2(.75f , 2f);
        groundChecker.transform.position = new Vector2(groundChecker.transform.position.x, groundChecker.transform.position.y -.5f);
    }
    private void TransitionLittle()
    {
        state = PlayerState.little;
        audioSource.PlayOneShot(shrinkSound);

        anim.runtimeAnimatorController = littleAnim as RuntimeAnimatorController;

        boxCollider.size = new Vector2(.75f , 1f);
        groundChecker.transform.position = new Vector2(groundChecker.transform.position.x, groundChecker.transform.position.y +.5f);
    }
    public void KillPlayer()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(deathSound);

        player.gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -5f); //moves forward on Z to be above other things

        rb.velocity = new Vector3(0, 1000f * Time.fixedDeltaTime); //move up

        boxCollider.enabled = false; //turns off collider so it will fall through ground

        anim.SetBool("isDead", true);
        anim.GetComponent<PlayerMovement>().enabled = false;

        StartCoroutine(LoadLevel());
        //Destroy(player);
    }

    IEnumerator LoadLevel()
    {
        //TODO: Add slow down between level changes?
        yield return new WaitForSecondsRealtime(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
