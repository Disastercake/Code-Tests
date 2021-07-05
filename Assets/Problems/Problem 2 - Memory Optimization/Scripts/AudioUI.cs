using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AudioUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.Audio.AudioMixer _mainMixer = null;

    [SerializeField]
    private UnityEngine.UI.Slider _slider = null;

    private void Awake()
    {
        _slider.value = .5f;
        _slider.onValueChanged.AddListener(OnSliderChange);
        UpdateSound(_slider.value);
    }

    public void OnSliderChange(float value)
    {
        UpdateSound(value);
    }

    private void UpdateSound(float value)
    {
        if (value > 0f)
            _mainMixer.SetFloat("MasterVolume", Mathf.Lerp(-30f, -15f, value));
        else
            _mainMixer.SetFloat("MasterVolume", -80f);
    }
}
