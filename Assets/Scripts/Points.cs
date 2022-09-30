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

    private RectTransform newHighScore;
    private RectTransform currentHighScore;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scores = GetComponentsInChildren<TextMeshProUGUI>();
        pointsText = scores[0];
        highScoreText = scores[1];

        // indexes 4 and 3 becouse 0 is canvas 1 & 2 are texts, first its need to deactivate 4 index
        // becouse otherwise it should take 2 times 3rd index
        currentHighScore = GetComponentsInChildren<RectTransform>()[5];
        currentHighScore.gameObject.SetActive(false);
        newHighScore = GetComponentsInChildren<RectTransform>()[4];
        newHighScore.gameObject.SetActive(false);
        

        Pelican.GetInstance().EatenFish += EatenFish_GetPoints;
        Pelican.GetInstance().OnDie += OnDie_UpdateHighScore;
        highScoreText.text = GetHighScore();
        points = 0;
        AddPoints(0);
    }

    private void OnDie_UpdateHighScore(object sender, EventArgs e)
    {
        if (PlayerPrefs.GetInt("highScore") < points)
        {
            PlayerPrefs.SetInt("highScore", points);
            OpenHighScoreWindow(newHighScore, points);
            
            newHighScore.GetComponent<TextMeshProUGUI>().text.Split("\n")[1] = points.ToString("D4");
        }
        else
        {
            OpenHighScoreWindow(currentHighScore, PlayerPrefs.GetInt("highScore"));
            currentHighScore.GetComponent<TextMeshProUGUI>().text.Split("\n")[1] = points.ToString("D4");
        }
        
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
    public void OpenHighScoreWindow(RectTransform transform, int highScore)
    {
        transform.gameObject.SetActive(true);
        var lines = transform.GetComponent<TextMeshProUGUI>().text.Split("\n");
        lines[1] = highScore.ToString("D4");
        transform.GetComponent<TextMeshProUGUI>().text = string.Join("\n", lines);
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
