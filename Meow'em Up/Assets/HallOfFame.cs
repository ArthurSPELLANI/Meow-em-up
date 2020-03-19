using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallOfFame : MonoBehaviour
{
    public Text HS1;
    public Text HS2;
    public Text HS3;

    public GameObject Menu;

    void Update()
    {
        HS1.text = PlayerPrefs.GetString("HSName") + " : " + PlayerPrefs.GetInt("HighScore").ToString();
        HS2.text = PlayerPrefs.GetString("HSName2") + " : " + PlayerPrefs.GetInt("HighScore2").ToString();
        HS3.text = PlayerPrefs.GetString("HSName3") + " : " + PlayerPrefs.GetInt("HighScore3").ToString();
    }
    public void ToMenu()
    {
        Menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
