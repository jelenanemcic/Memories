using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSoundHandler : MonoBehaviour
{
    [SerializeField] private AudioClip walkClip;
    [SerializeField] private AudioClip sprintClip;

    private Animator animator;
    private AudioSource audioSource;
    
    enum State
    {
        Standing,
        Walking,
        Sprinting
    };

    private State previousState = State.Standing;
    private State state = State.Standing;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        GetCurrentState();
        PlaySound();
        //Debug.Log(audioSource.clip.ToString());
    }

    private void GetCurrentState()
    {
        float forward = animator.GetFloat("forward");
        float turn = animator.GetFloat("turn");
        previousState = state;

        if ((Math.Abs(forward) > 0.4f && Math.Abs(forward) < 0.51f) || (Math.Abs(turn) > 0.4f && Math.Abs(turn) < 0.51f))
        {
            state = State.Walking;
        }else if((Math.Abs(forward) > 0.51f) || (Math.Abs(turn) > 0.51f)){
            state = State.Sprinting;
        }
        else
        {
            state = State.Standing;
        }
    }

    private void PlaySound()
    {
        switch (state)
        {
            case State.Standing:
                {
                    audioSource.Stop();
                    break;
                }

            case State.Walking:
                {
                    if(previousState == State.Sprinting)
                    {
                        audioSource.Stop();
                        audioSource.PlayOneShot(walkClip);
                    }
                    else if (!audioSource.isPlaying)
                    {
                        audioSource.PlayOneShot(walkClip);
                    }

                    break;
                }

            case State.Sprinting:
                {
                    if (previousState == State.Walking)
                    {
                        audioSource.Stop();
                        audioSource.PlayOneShot(sprintClip);
                    }
                    else if (!audioSource.isPlaying)
                    {
                        audioSource.PlayOneShot(sprintClip);
                    }

                    break;
                }
        }
    }
}
