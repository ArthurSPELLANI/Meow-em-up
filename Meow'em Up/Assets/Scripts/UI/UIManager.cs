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
        TNUL.text = "HIGHSCORE = "+ PlayerPrefs.GetString("HSName") + ":" + PlayerPrefs.GetInt("HighScore").ToString();
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
    public void NewHighScore()
    {
        HighScorePanel.SetActive(true);
        highScore = PlayerPrefs.GetInt("HighScore");
        HighScoreText.text = highScore.ToString();
    }

    public void SetHighScoreName()
    {
        if (nameOk)
        {
            highScoreName = hSN.text;
            PlayerPrefs.SetString("HSName", highScoreName);
            PlayerPrefs.Save();
            HighScorePanel.SetActive(false);
        }
    }
}
