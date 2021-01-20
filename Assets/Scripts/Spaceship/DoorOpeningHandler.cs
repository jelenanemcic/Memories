using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningHandler : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(animator != null)
            {
                animator.SetBool("character_nearby", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (animator != null)
            {
                animator.SetBool("character_nearby", false);
            }
        }
    }
}
