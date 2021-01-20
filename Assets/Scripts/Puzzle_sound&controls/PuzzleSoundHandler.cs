using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSoundHandler : MonoBehaviour
{

    [SerializeField] private AudioClip puzzleMusic;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void OnButton()
    {
        audioSource.clip = puzzleMusic;
        audioSource.Play();
        audioSource.loop = true;
    }

}
