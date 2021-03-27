using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yashlan
{
    public class ScoreManager : MonoBehaviour
    {

        #region instance Class

        private static ScoreManager instance = null;
        public static ScoreManager Instance
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

        [SerializeField]
        private int score;

        // Start is called before the first frame update
        void Start()
        {
            PlayerPrefs.GetInt(PlayerPerfs_TAG.SCORE, score);
        }

        public static void AddScore(int amount)
        {
            instance.score += amount;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
