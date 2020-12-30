using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameHandler : MonoBehaviour
{

    [SerializeField] private Canvas startGameCanvas;
    private bool gotItPressed = false;

    public bool GetGotIsPressed()
    {
        return gotItPressed;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnButton()
    {
        gotItPressed = true;
        startGameCanvas.enabled = false;
    }
}
