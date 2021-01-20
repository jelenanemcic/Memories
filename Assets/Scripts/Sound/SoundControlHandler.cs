using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControlHandler : MonoBehaviour
{
    private AudioSource[] audioSources;
    [SerializeField][Tooltip("Decrease/Increase sound volume factor between 0.05 and 0.5")] private float factor = 0.1f;
    private float currentVolume;

    void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();
        if(audioSources != null) { currentVolume = audioSources[0].volume; }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            RaiseSound(factor);
        }else if (Input.GetKeyDown(KeyCode.L))
        {
            SilenceSound(factor);
        }
    }

    private void SilenceSound(float silenceFactor)
    {
        currentVolume = Mathf.Clamp(currentVolume - silenceFactor, 0f, 1f);
        SetVolume();
    }

    private void RaiseSound(float raiseFactor)
    {
        currentVolume = Mathf.Clamp(currentVolume + raiseFactor, 0f, 1f);
        SetVolume();
    }

    private void SetVolume()
    {
        foreach(var source in audioSources)
        {
            source.volume = currentVolume;
        }
    }
}
