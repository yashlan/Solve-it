using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yashlan
{
    public class PlayerPrefs_TAG : MonoBehaviour
    {

        #region instance Class

        private static PlayerPrefs_TAG instance = null;
        public static PlayerPrefs_TAG Instance
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

        #endregion of instance class


        #region ALL PLAYERPREFS DATA

        public static string SCORE = "SCORE";

        public static string VOLUME = "VOLUME";

        #endregion
    }

}
