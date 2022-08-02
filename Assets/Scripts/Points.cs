using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Points : MonoBehaviour
{
    private static Points instance;
    public static Points GetInstance()
    {
        return instance;
    }

    private int points;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highScoreText;
    private TextMeshProUGUI[] scores;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scores = GetComponentsInChildren<TextMeshProUGUI>();
        pointsText = scores[0];
        highScoreText = scores[1];

        Pelican.GetInstance().EatenFish += EatenFish_GetPoints;
        Pelican.GetInstance().OnDie += OnDie_UpdateHighScore;
        highScoreText.text = GetHighScore();
        points = 0;
        AddPoints(0);
    }

    private void OnDie_UpdateHighScore(object sender, EventArgs e)
    {
        if (PlayerPrefs.GetInt("highScore") < points) PlayerPrefs.SetInt("highScore", points);
        highScoreText.text = GetHighScore();
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
    public void OpenHighScoreWindow()
    {

    }
    public string GetHighScore()
    {
        return "HIGHSCORE: " + PlayerPrefs.GetInt("highScore").ToString("D4");
    }
    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt("highScore", score);
    }
}
