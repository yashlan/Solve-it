
using System.Collections.Generic;
using UnityEngine;


namespace Yashlan
{
    public class SFX_MANAGER : MonoBehaviour
    {

        public static SFX_MANAGER i;

        public AudioClip bg_musik;

        private AudioSource bgm_source;
        private AudioSource source;

        [Range(0, 1)]
        public float volume_BG;


        private void Awake()
        {
            if (i == null)
            {
                i = this;
            }

            volume_BG = 1f;
            bgm_source = gameObject.AddComponent<AudioSource>();
            bgm_source.clip = bg_musik;
            bgm_source.volume = volume_BG;
            bgm_source.playOnAwake = true;
            bgm_source.loop = true;
            bgm_source.Play();


            source = gameObject.AddComponent<AudioSource>();
            source.volume = 1f;
            source.playOnAwake = false;
            source.loop = false;
        }


        private void Start()
        {
            AudioListener.pause = false;
        }

        public static void PlaySfx(AudioClip clip)
        {
            i.PlaySound(clip, i.source);
        }

        private void PlaySound(AudioClip clip, AudioSource source)
        {
            if (clip == null)
            {
                Debug.Log("There are no audio file to play", gameObject);
            }

            source.pitch = 1f;
            source.PlayOneShot(clip, 1f);
        }

        public static void StopBGMSound()
        {
            if (i.bgm_source.isPlaying)
            {
                i.bgm_source.Stop();
                return;
            }
        }

    }

}
