using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    [SerializeField] private bool isFree;

    public bool GetIsFree() { return isFree; }
    public void SetIsFree(bool free) { isFree = free; }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(gameObject.transform.position.ToString());
    }
}
