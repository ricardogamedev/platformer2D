using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayHelper : MonoBehaviour
{
    public KeyCode keyCode;
    public AudioSource audioSource;

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            Play();
        }
    }

    public void Play()
    {
       if(audioSource != null) audioSource.Play();
    }
}
