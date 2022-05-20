using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAsstes : MonoBehaviour
{
    private static GameAsstes instance;

    public static GameAsstes GetInstance()
    {
        return instance;
    }

    public Transform pfSky;
    public Transform pfWater;
    public List<Transform> pfFish;

    private void Awake()
    {
        instance = this;
    }

    
}
