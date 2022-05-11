using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private float SKY_MOVE_SPEED = 2;
    [SerializeField] private float WATER_MOVE_SPEED = 2;

    private static Level instance;

    public static Level GetInstance()
    {
        return instance;
    }


}
