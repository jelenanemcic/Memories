﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollZ : MonoBehaviour
{

    [SerializeField] private float scrollSpeed = 20f;

    void Update()
    {
        Vector3 pos = transform.position;

        Vector3 localVectorUp = transform.TransformDirection(0, 1, 0);

        pos += localVectorUp * scrollSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
