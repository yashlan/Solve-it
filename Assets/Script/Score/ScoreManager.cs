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
            if(Score < 100)
                Score += amount;
        }

        public static void ResetScore()
        {
            Score = 0;
        }

    }

}
