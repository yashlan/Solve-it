using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppQuit : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("exit game");
    }
}
