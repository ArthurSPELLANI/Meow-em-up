using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthPoint;
    GameObject player;

    public int points;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(healthPoint <= 0)
        {
            player.GetComponent<PlayerManager>().GainPoints(points);
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
         healthPoint -= damage;
    }
}
