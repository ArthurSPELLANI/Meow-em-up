using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool isPaused;

    public GameObject GameOverPanel;
    public GameObject PausePanel;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            GoPause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            ExitPause();
        }
            
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }

    void GoPause()
    {
        isPaused = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    void ExitPause()
    {
        isPaused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
