using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


namespace Yashlan
{
    public class VolumeController : MonoBehaviour
    {

        Slider slider;

        private void Start()
        {
            slider = GetComponent<Slider>();
            slider.value = AudioManager.Instance.Volume;
        }

        public void SetLevel(float sliderValue)
        {
            AudioManager.Instance.SetVolume(sliderValue);
        }
    }
}

