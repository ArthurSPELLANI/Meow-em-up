using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public bool isPaused;
    bool gameOver;
    bool wannaLeave;
    bool canLeave;

    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public GameObject WannaLeavePanel;

    void Start()
    {
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Backspace) && !isPaused)
        {
            GoPause();
        }
        else if (Input.GetKeyDown(KeyCode.Backspace) && isPaused)
        {
            ExitPause();
        }

        if (gameOver && Input.GetKeyDown(KeyCode.Space ))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (!wannaLeave && Input.GetKeyDown(KeyCode.Escape))
            WannaLeave();

        if (wannaLeave && Input.GetKeyDown(KeyCode.Escape))
            LeaveWannaLeave();

        if(wannaLeave && Input.GetKeyDown(KeyCode.Return))
            Application.Quit();
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
        gameOver = true;
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

    void WannaLeave()
    {
        WannaLeavePanel.SetActive(true);
        wannaLeave = true;
        Time.timeScale = 0;
        canLeave = false;
        StartCoroutine(Hu());
    }

    void LeaveWannaLeave()
    {
        if (canLeave)
        {
            WannaLeavePanel.SetActive(false);
            wannaLeave = false;
            Time.timeScale = 1;
            Debug.Log("oui");
        }
        Debug.Log(canLeave);
    }
    IEnumerator Hu()
    {
        yield return new WaitForEndOfFrame();
        canLeave = true;
    }
}