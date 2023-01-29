using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static float volume = 1f;
    public static bool mute;
    public static bool soundFX;
    [SerializeField] Toggle MuteToggle;
    [SerializeField] Toggle SoundFXToggle;
    [SerializeField] Slider VolumeSlider;

    private void Start()
    {
        MuteToggle.isOn = mute;
        SoundFXToggle.isOn = soundFX;
        VolumeSlider.value = volume;
    }
    // Update is called once per frame
    void Update()
    {
        mute = MuteToggle.isOn;
        soundFX = SoundFXToggle.isOn;
        volume = VolumeSlider.value;
    }
}
