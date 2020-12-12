using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsHandler : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if (Input.GetButton("Jump"))
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
