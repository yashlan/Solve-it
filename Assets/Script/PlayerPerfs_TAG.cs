using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPerfs_TAG : MonoBehaviour
{

    #region instance Class

    private static PlayerPerfs_TAG instance = null;
    public static PlayerPerfs_TAG Instance
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

    public static string FIRST_LOGIN = "FIRST_LOGIN";

    public static string LEVEL_REACHED = "LEVEL_REACHED";

    public static string SCORE = "SCORE";

    public static string COIN = "COIN";

    public static string BGM_VOLUME = "BGM_VOLUME";

    #endregion
}
