using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Distr : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
