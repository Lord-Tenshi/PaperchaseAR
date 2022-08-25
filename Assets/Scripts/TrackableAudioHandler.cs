using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackableAudioHandler : MonoBehaviour
{

    public DefaultObserverEventHandler EventHandler;
    public AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        EventHandler.OnTargetFound.AddListener(OnTrackingFound);    
        EventHandler.OnTargetFound.AddListener(OnTrackingLost);    
    }

    private void OnTrackingLost()
    {
        if (audioS)
        {
            audioS.Play();
        }
    }

    private void OnTrackingFound()
    {
        if (audioS)
        {
            audioS.Stop();
        }
    }

    private void OnMouseDown()
    {
        if (audioS.isPlaying)
        {
            audioS.Pause();

        }
        else
        {
            audioS.Play();
        }
    }
}
