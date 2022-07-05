using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour, IBackgroundElements
{
    public Transform prefab;
    private float speedModificator;
    private Vector3 moveDirection;

    public Fish(Transform prefab, float speedModification, bool goRight)
    {
        this.prefab = prefab;
        this.speedModificator = speedModification;
        if (goRight) moveDirection = new Vector3(1, 0, 0);
        else moveDirection = new Vector3(-1, 0, 0);
    }
    
    public void Move()
    {
        prefab.position += moveDirection * speedModificator * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Die!");
    }
}
