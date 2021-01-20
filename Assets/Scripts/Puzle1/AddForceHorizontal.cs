using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceHorizontal : MonoBehaviour
{

    [SerializeField] private float thrust = 2000f;
    private Rigidbody rigidbody;

    private bool gotItPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gotItPressed)
        {
            AddForce();
        }
    }

    private void AddForce()
    {
        if (Math.Abs(Input.GetAxis("Horizontal")) > float.Epsilon)
        {
            float force = Time.deltaTime * thrust * Input.GetAxis("Horizontal");
            rigidbody.AddRelativeForce(force, 0, 0);
        }
    }

    public void OnButton()
    {
        gotItPressed = true;
    }
}
