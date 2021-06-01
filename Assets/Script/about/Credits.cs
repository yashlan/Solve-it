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
                           "Muhammad Yashlan Iskandar\n(18312170)\n\n" +
                           "Design Grafis\n\n" +
                           "Devka Savana\n(18312122)\n\n" +
                           "Komposer\n\n" +
                           "Farhan Rosyid\n(18312108)";

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
