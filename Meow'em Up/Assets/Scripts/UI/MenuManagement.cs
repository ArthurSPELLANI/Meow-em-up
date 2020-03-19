using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    public GameObject HallOfFame;

    public void ToGame()
    {
        SceneManager.LoadScene("Level01", LoadSceneMode.Single);
    }

    public void LeaveApp()
    {
        Application.Quit();
    }
    public void ToHallOfFame()
    {
        HallOfFame.SetActive(true);
        gameObject.SetActive(false);
    }
}
