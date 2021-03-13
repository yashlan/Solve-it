using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{


    public void pindahScene(string NamaScene)
    {
        SceneManager.LoadScene(NamaScene);
    }

}
