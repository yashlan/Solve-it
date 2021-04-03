using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yashlan
{
    public class BackSoundManager : MonoBehaviour
    {
        AudioSource bgMusik;


        // Use this for initialization
        private void Start()
        {
            bgMusik = GetComponent<AudioSource>();
            bgMusik.Play();
        }

        private static BackSoundManager instance = null;
        public static BackSoundManager Instance
        {
            get { return instance; }
        }

        void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            else
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
            }
        }


        // Update is called once per frame
        public static void Pause()
        {
            instance.bgMusik.Pause();
        }

        public static void UnPause()
        {
            instance.bgMusik.UnPause();
        }
    }

}
