using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyObj : MonoBehaviour
{
    [SerializeField] private float TimeToDestroy;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, TimeToDestroy);
    }

}
