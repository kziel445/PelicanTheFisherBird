using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    private static Points instance;
    public static Points GetInstance()
    {
        return instance;
    }

    private int points;
    public TextMeshProUGUI pointsText;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        points = 0;
        // pointsText = GetComponentInChildren<TextMeshProUGUI>();
        Pelican.GetInstance().EatenFish += EatenFish_GetPoints;
    }
    private void EatenFish_GetPoints(object sender, Transform e)
    {
        
        var fishComp = e.gameObject.GetComponent<Fish>();
        AddPoints(fishComp.fishValue);
        
    }
    public void AddPoints(int pointValue)
    {
        points += pointValue;
        pointsText.text = points.ToString("D4");
    }

    void Update()
    {
    }
}
