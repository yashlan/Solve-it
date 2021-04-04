using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

namespace Yashlan
{
    public class Credits : MonoBehaviour
    {
        public AudioClip sound;
        public float delay;
        const string msg = "GAME INI DIBUAT OLEH :\n\n" +
                           "Programmer\n\n" +
                           "Test 123\n\n" +
                           "Design Grafis\n\n" +
                           "Test 123\n\n" +
                           "Komposer\n\n" +
                           "Test 123";

        private TextMeshProUGUI textMesh;
        private AudioSource audio_;

        private void Awake()
        {
            AudioMixerGroup audioMixerGroup = Resources.Load("AudioMixer", typeof(AudioMixerGroup)) as AudioMixerGroup;
            audio_ = gameObject.AddComponent<AudioSource>();
            audio_.outputAudioMixerGroup = audioMixerGroup;

            audio_.clip = sound; textMesh = GetComponent<TextMeshProUGUI>();
        }

        void OnEnable()
        {
            textMesh.text = "";
            StartCoroutine("TypeTextCredits");
        }

        IEnumerator TypeTextCredits()
        {
            foreach (char letter in msg.ToCharArray())
            {
                textMesh.text += letter;
                if (sound != null)
                    audio_.PlayOneShot(sound);
                yield return 0;
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
