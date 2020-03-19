using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Management;
using UnityEngine.UI;

namespace Game
{
    /// <summary>
    /// General management of the game.
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        public PlayerManager player;
        public int score;
        public int lives;
        public int playerHP;
        public int highScore;
        public Text scoreText;
        public Text livesText;
        public Text hPText;

        public int scoreToLive;
        bool canAddLife;

        public UIManager uIM;

        void Awake()
        {
            MakeSingleton(true);
        }

        void Start()
        {
            player = FindObjectOfType<PlayerManager>();
            scoreText.text = "Score : " + score;
            uIM = FindObjectOfType<UIManager>();

            hPText.text = "HP : " + playerHP;
        }


        void Update()
        {
            AddLife();
        }

        public void AddScore(int points)
        {
            score += points;
            scoreText.text = "Score : " + score;
            canAddLife = true;
        }

        public void RemoveLife()
        {
            lives -= 1;
            livesText.text = "Lives : " + lives;
        }

        public void RemoveHP()
        {
            playerHP -= 1;
            hPText.text = "HP : " + playerHP;
        }
        public void Death()
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
                PlayerPrefs.Save();
                uIM.NewHighScore();
                score = 0;
            }
        }
        int x = 1;
        void AddLife()
        {
            if (canAddLife && (score >= (scoreToLive * x)))
            {
                playerHP += 1;
                hPText.text = "HP : " + playerHP;
                canAddLife = false;
            }
        }
    }
}