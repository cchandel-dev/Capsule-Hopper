using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicController : MonoBehaviour
{
    AudioSource sourceComponent;

    // Start is called before the first frame update
    void Start()
    {
        sourceComponent = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if (!AudioManager.mute)
            sourceComponent.volume = 0;
        else
            sourceComponent.volume = AudioManager.volume;
    }
}
