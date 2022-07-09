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
        Debug.Log("Points +1");
        // points += transform
    }

    void Update()
    {
        
    }
}
