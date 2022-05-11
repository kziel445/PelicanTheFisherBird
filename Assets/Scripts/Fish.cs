using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish
{
    private Transform prefab;
    private float speedModificator;
    private float leftBorder;
    private float rightBorder;

    public Fish(Transform prefab, float speedModification, float leftBorder, float rightBorder)
    {
        this.prefab = prefab;
        this.speedModificator = speedModification;
        this.leftBorder = leftBorder;
        this.rightBorder = rightBorder;
    }
}
