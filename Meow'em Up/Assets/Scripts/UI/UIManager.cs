using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public bool isPaused;
    bool gameOver;
    bool wannaLeave;
    bool canLeave;
    bool nameOk;

    public InputField hSN;
    public string highScoreName = "0";
    public Button OKButton;
    public Text HighScoreText;
    int highScore;

    public Text TNUL;

    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public GameObject WannaLeavePanel;
    public GameObject HighScorePanel;
    public GameObject CongratsPanel;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
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

        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            Reload();
        }

        if (!wannaLeave && Input.GetKeyDown(KeyCode.Escape))
            WannaLeave();

        if (wannaLeave && Input.GetKeyDown(KeyCode.Escape))
            LeaveWannaLeave();

        if (wannaLeave && Input.GetKeyDown(KeyCode.Return))
            Application.Quit();

        if (highScoreName.Length > 4)
        {
            nameOk = false;
            OKButton.image.color = new Color(50, 50, 50);
        }
        else if (highScoreName.Length <= 4)
        {
            nameOk = true;
        }

        
            
    }

    public void GameOver()
    {

        GameOverPanel.SetActive(true);
        Time.timeScale = 0.2f;
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
    void Reload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverPanel.SetActive(false);
        gameOver = false;
    }
    int lol = 0;
    public void NewHighScore()
    {
        HighScorePanel.SetActive(true);
        highScore = PlayerPrefs.GetInt("HighScore");
        HighScoreText.text = highScore.ToString();
        lol = 1;
    }
    public void NewHighScore2()
    {
        HighScorePanel.SetActive(true);
        highScore = PlayerPrefs.GetInt("HighScore2");
        HighScoreText.text = highScore.ToString();
        lol = 2;
    }
    public void NewHighScore3()
    {
        HighScorePanel.SetActive(true);
        highScore = PlayerPrefs.GetInt("HighScore3");
        HighScoreText.text = highScore.ToString();
        lol = 3;
    }

    public void SetHighScoreName()
    {
        if (nameOk)
        {
            if(lol == 1)
            {
                highScoreName = hSN.text;
                PlayerPrefs.DeleteKey("HSName");
                PlayerPrefs.SetString("HSName", highScoreName);
                PlayerPrefs.Save();
                HighScorePanel.SetActive(false);
            }
            if (lol == 2)
            {
                highScoreName = hSN.text;
                PlayerPrefs.DeleteKey("HSName2");
                PlayerPrefs.SetString("HSName2", highScoreName);
                PlayerPrefs.Save();
                HighScorePanel.SetActive(false);
            }
            if (lol == 3)
            {
                highScoreName = hSN.text;
                PlayerPrefs.DeleteKey("HSName3");
                PlayerPrefs.SetString("HSName3", highScoreName);
                PlayerPrefs.Save();
                HighScorePanel.SetActive(false);
            }
        }
    }

    public void Congratulation()
    {
        isPaused = true;
        CongratsPanel.SetActive(true);
        Time.timeScale = 0;
    }
}

