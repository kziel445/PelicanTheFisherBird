using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int points;

    private void Awake()
    {
        points = 0;
        Pelican.GetInstance().EatenFish += EatenFish_GetPoints;
    }
    private void EatenFish_GetPoints(object sender, Transform e)
    {
        
        var fishComp = e.gameObject.GetComponent<Fish>();
        Debug.Log("Points +" + fishComp.fishValue);
        points += fishComp.fishValue;
    }

    void Update()
    {
        
    }
}
