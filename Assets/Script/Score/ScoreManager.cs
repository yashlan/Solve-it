using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public static int Score 
        { 
            get 
            { 
                return instance.score; 
            } 
            set 
            {
                instance.score = value; 
            }  
        }


        public static void PlusScore(int amount)
        {
            if(instance.score < 100)
                instance.score += amount;
        }

        public static void ResetScore()
        {
            instance.score = 0;
        }

    }

}
