using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Yashlan
{
    public class AudioManager : MonoBehaviour
    {
        public AudioMixer audioMixer;
        [Range(0, 1)]
        public float Volume;
        const string Exspose_name = "MusicVol";

        private static AudioManager instance = null;
        public static AudioManager Instance
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

        private void Start()
        {
            if (!PlayerPrefs.HasKey(PlayerPrefs_TAG.VOLUME))
            {
                PlayerPrefs.SetFloat(PlayerPrefs_TAG.VOLUME, 1f);
                //print("first playing");
            }
            else
            {
                Volume = PlayerPrefs.GetFloat(PlayerPrefs_TAG.VOLUME);
                SetVolume(Volume);
                //print("not first playing");
            }

        }

        private void Update()
        {
            if (SceneManager.GetSceneByName("home").isLoaded)
                Volume = PlayerPrefs.GetFloat(PlayerPrefs_TAG.VOLUME);
        }

        public void SetVolume(float sliderValue)
        {
            audioMixer.SetFloat(Exspose_name, Mathf.Log10(sliderValue) * 20);
            PlayerPrefs.SetFloat(PlayerPrefs_TAG.VOLUME, sliderValue);
            //print("volume : " + PlayerPrefs.GetFloat(PlayerPrefs_TAG.VOLUME));
        }
    }
}

