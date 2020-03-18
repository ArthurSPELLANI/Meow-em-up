using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float playerHP;
    public float lives;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP <= 0)
        {
            Destroy(this.gameObject);
        }
    } 

    public void TakeDamage(float damage)
    {
        playerHP -= damage;
    }
}

