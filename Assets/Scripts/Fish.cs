using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour, IBackgroundElements
{
    private float speedModificator;
    private Vector3 moveDirection;
    public event EventHandler OnFishDie;

    public void FishParameters(float speedModification, bool goRight)
    {
        this.speedModificator = speedModification;
        if (goRight) moveDirection = new Vector3(1, 0, 0);
        else moveDirection = new Vector3(-1, 0, 0);
    }
    
    public void Move()
    {
        transform.position += moveDirection * speedModificator * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnFishDie?.Invoke(this, EventArgs.Empty);
        Debug.Log($"Die!");
        //Destroy(gameObject);
    }
}
