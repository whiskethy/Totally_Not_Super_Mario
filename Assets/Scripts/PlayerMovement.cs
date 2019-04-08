using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public AudioSource audioSource;

    public float runSpeed = 1.5f;
    private float horizontalMove;
    private bool jump = false;
    private bool sprint = false;

    public AudioClip littleJumpSound;

    public Animator anim;

    private void Start() {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();    
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //left = -1, right = 1
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(horizontalMove == 0) //if not moving at all
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false);
        }
        else //if moving
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", true);
        }

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("isJumping", true);
            anim.SetBool("isIdle", false);
            
            if(controller.m_Grounded)
            {
                audioSource.PlayOneShot(littleJumpSound);
            }    
        }

        if(Input.GetButtonDown("Sprint"))
        {
            sprint = true;
        }
        if(Input.GetButtonUp("Sprint"))
        {
            sprint = false;
        }

    }

    private void FixedUpdate() {
        controller.Move(horizontalMove, sprint, jump);
        jump = false;
    }

    public void OnLanding()
    {
        anim.SetBool("isJumping", false);
        anim.SetBool("isIdle", true);
    }
}//end of file
