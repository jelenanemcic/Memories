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
            if (forward < 0 && Input.GetKey(KeyCode.LeftShift))
            {
                forward = -1f;
            }
            else if (forward > 0 && Input.GetKey(KeyCode.LeftShift))
            {
                forward = 1f;
            }
            float turn = Input.GetAxis("Horizontal");

            animator.SetFloat("forward", forward);
            animator.SetFloat("turn", turn);
        }
    }
}
