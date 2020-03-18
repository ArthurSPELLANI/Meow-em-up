using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootTest : MonoBehaviour
{
    public GameObject enemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shoot()
    {
        Instantiate(enemyBullet, this.transform);

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(Shoot());
    }
}
