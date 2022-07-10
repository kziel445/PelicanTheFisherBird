using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour, IBackgroundElements
{
    private float speedModificator;
    private Vector3 moveDirection;
    public int fishValue;

    public void FishInit(float speedModification, int fishValue, bool goRight)
    {
        this.speedModificator = speedModification;
        if (goRight) moveDirection = new Vector3(1, 0, 0);
        else moveDirection = new Vector3(-1, 0, 0);
        this.fishValue = fishValue;
    }
    
    public void Move()
    {
        transform.position += moveDirection * speedModificator * Time.deltaTime;
    }
}
