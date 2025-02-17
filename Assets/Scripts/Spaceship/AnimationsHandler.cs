﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsHandler : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if (Input.GetButtonDown("Jump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            animator.SetTrigger("jump");
        }
        else
        {
            float forward = Input.GetAxis("Vertical")/2;
            float turn = Input.GetAxis("Horizontal")/2;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                forward *= 2;
                turn *= 2;
            }
            animator.SetFloat("forward", forward);
            animator.SetFloat("turn", turn);
        }
    }

    
}
