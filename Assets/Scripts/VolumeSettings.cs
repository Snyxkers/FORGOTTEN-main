using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = 1f;
        AudioListener.volume = volumeSlider.value;

        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}