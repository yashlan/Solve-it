using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yashlan
{
    public class BGMController : MonoBehaviour
    {
        public enum Bgm { Pause, UnPause }
        public Bgm bgm;

        // Start is called before the first frame update
        void Start()
        {
            switch (bgm)
            {
                case Bgm.Pause:
                    BackSoundManager.Pause();
                    break;

                case Bgm.UnPause:
                    BackSoundManager.UnPause();
                    break;

            }
        }
    }
}

