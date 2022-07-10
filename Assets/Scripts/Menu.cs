using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    Transform pauseWindow;
    private void Awake()
    {
        pauseWindow = transform.GetChild(0).Find("PauseWindow");
        PauseWindowOff();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
