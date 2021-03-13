using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public static void PauseBgMenu()
    {
        instance.bgMusik.Pause();
    }

    public static void UnpauseBGMenu()
    {
        AudioListener.pause = false;
        instance.bgMusik.UnPause();
    }
}
