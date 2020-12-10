using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceVertical : MonoBehaviour
{
    [SerializeField] private float thrust = 2000f;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(Input.GetAxis("Vertical")) > float.Epsilon)
        {
            float force = Time.deltaTime * thrust * Input.GetAxis("Vertical");
            rigidbody.AddRelativeForce(-force, 0, 0);
        }
        
    }
}
