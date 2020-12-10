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
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButton("Jump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            animator.SetTrigger("jump");
        }
        else
        {
            float forward = Input.GetAxis("Vertical");
            if (Input.GetKey(KeyCode.LeftShift) && Math.Abs(forward) > float.Epsilon)
            {
                switch(forward > 0)
                {
                    case true:
                        forward = 1f;
                        break;

                    case false:
                        forward = -1f;
                        break;
                }
            }
            else if(Math.Abs(forward) > float.Epsilon)
            {
                switch (forward > 0)
                {
                    case true:
                        forward = 0.5f;
                        break;

                    case false:
                        forward = -0.5f;
                        break;
                }
            }
            float turn = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.LeftShift) && Math.Abs(turn) > float.Epsilon)
            {
                switch (turn > 0)
                {
                    case true:
                        turn = 1f;
                        break;

                    case false:
                        turn = -1f;
                        break;
                }
            }
            else if(Math.Abs(turn) > float.Epsilon)
            {
                switch (turn > 0)
                {
                    case true:
                        turn = 0.5f;
                        break;

                    case false:
                        turn = -0.5f;
                        break;
                }
            }



            animator.SetFloat("forward", forward);
            animator.SetFloat("turn", turn);
        }
    }
}
