using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAsstes : MonoBehaviour
{
    

    private static GameAsstes instance;
    private void Awake()
    {
        instance = this;
    }

    private static GameAsstes GetInstance()
    {
        return instance;
    }
    
    [SerializeField] Transform pfSky;
    [SerializeField] Transform pfWater;
}
