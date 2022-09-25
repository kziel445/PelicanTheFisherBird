using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Transform pauseWindow;
    Transform restartButton;
    private void Awake()
    {
        pauseWindow = transform.GetChild(0).GetChild(1).Find("PauseWindow");
        PauseWindowOff();

        restartButton = transform.GetChild(0).GetChild(1).Find("RestartButton");
        RestartButtonOff();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Pelican.GetInstance().OnDie += OnDie_RestartButton;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDie_RestartButton(object sender, EventArgs e)
    {
        RestartButtonOn();
    }
    public void RestartGame()
    {
        Debug.Log("Restart game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RestartButtonOn()
    {
        restartButton.gameObject.SetActive(true);
    }
    public void RestartButtonOff()
    {
        restartButton.gameObject.SetActive(false);
    }
    public void PauseButton()
    {
        if (pauseWindow.gameObject.activeSelf) PauseWindowOff();
        else PauseWindowOn();
    }
    public void PauseWindowOn()
    {
        pauseWindow.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void PauseWindowOff()
    {
        pauseWindow.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
