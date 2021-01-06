using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class HintHandler_puzzle4 : MonoBehaviour
{

    [SerializeField] private GameObject hint1;
    [SerializeField] private GameObject hint2;
    [SerializeField] private int secondsForHint1;
    [SerializeField] private int secondsForHint2;

    private MeshRenderer hint1Mesh;
    private MeshRenderer hint2Mesh;
    private bool gotItPressed = false;
    private float accu = 0f;
    private bool hintsDisplayed = false;

    private void Start()
    {
        hint1Mesh = hint1.GetComponentInChildren<MeshRenderer>();
        hint2Mesh = hint2.GetComponentInChildren<MeshRenderer>();
        hint1Mesh.enabled = false;
        hint2Mesh.enabled = false;
    }

    private void Update()
    {
        // Debug.Log(Time.deltaTime.ToString());
        if (gotItPressed && !hintsDisplayed)
        {
            accu += Time.deltaTime;
            // Debug.Log(accu.ToString());
            if(accu > secondsForHint1)
            {
                ActivateHint1(hint1Mesh);
            }
            if(accu > secondsForHint2)
            {
                ActivateHint2(hint2Mesh);
            }
        }
    }

    private void ActivateHint1(MeshRenderer hint1Mesh)
    {
        hint1Mesh.enabled = true;
    }

    private void ActivateHint2(MeshRenderer hint2Mesh)
    {
        hint2Mesh.enabled = true;
        hintsDisplayed = true;
    }

    public void OnButton()
    {
        gotItPressed = true;
    }
}
