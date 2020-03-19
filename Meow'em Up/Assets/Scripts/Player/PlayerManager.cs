using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class PlayerManager : MonoBehaviour
{
    public int playerHP;
    public int lives;

    //[HideInInspector]
    public float globalPoints;



    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.lives = 3;
        GameManager.Instance.playerHP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP <= 0)
        {            
            GameManager.Instance.uIM.GameOver();
            Destroy(this.gameObject);
        }
    } 

    public void TakeDamage(int damage)
    {
        GameManager.Instance.RemoveHP();
        playerHP -= damage;
    }

    public void GainPoints(int points)
    {
        globalPoints += points;
        GameManager.Instance.AddScore(points);
    }

}

