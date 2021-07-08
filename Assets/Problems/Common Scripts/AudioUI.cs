using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CommonScripts
{
    public class AudioUI : MonoBehaviour
    {
        private static float _globalVolume = 0.5f;

        [SerializeField]
        private UnityEngine.Audio.AudioMixer _mainMixer = null;

        [SerializeField]
        private UnityEngine.UI.Slider _slider = null;

        private void Awake()
        {
            _slider.value = _globalVolume;
            _slider.onValueChanged.AddListener(OnSliderChange);
            UpdateSound(_slider.value);
        }

        public void OnSliderChange(float value)
        {
            UpdateSound(Mathf.Clamp01(value));
        }

        private void UpdateSound(float value)
        {
            _globalVolume = value;

            if (_globalVolume > 0f)
                _mainMixer.SetFloat("MasterVolume", Mathf.Lerp(-30f, -15f, _globalVolume));
            else
                _mainMixer.SetFloat("MasterVolume", -80f);
        }
    }
}
