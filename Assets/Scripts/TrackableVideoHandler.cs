using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TrackableVideoHandler : DefaultObserverEventHandler
{
    public VideoPlayer Video;
    public GameObject obj;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        if (Video)
        {
            Video.Play();
        }
    }


    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();

        if (Video)
        {
            Video.Pause();
        }
    }

}
