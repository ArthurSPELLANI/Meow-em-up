using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public Rigidbody2D rb;
    bool location = false;
    public GameObject[] bulletSpawn;
    public GameObject[] bullets;
    Quaternion rotation = Quaternion.identity;
    public Enemy enemyScript;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (location == false)
        {
            rb.velocity = new Vector2(-1f, 0);
        }
        else if (location == true)
        {
            rb.velocity = new Vector2(0, 0);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            location = true;
        }
    }

    IEnumerator Shoot()
    {
        Instantiate(bullets[1], bulletSpawn[Random.Range(0,3)].transform.position, rotation);

        yield return new WaitForSeconds(1.5f);

        Instantiate(bullets[Random.Range(0, 2)], bulletSpawn[Random.Range(0, 3)].transform.position, rotation);
        Instantiate(bullets[Random.Range(0, 2)], bulletSpawn[Random.Range(0, 3)].transform.position, rotation);

        yield return new WaitForSeconds(1.5f);

        Instantiate(bullets[Random.Range(0, 2)], bulletSpawn[Random.Range(0, 3)].transform.position, rotation);
        Instantiate(bullets[Random.Range(0, 2)], bulletSpawn[Random.Range(0, 3)].transform.position, rotation);

        yield return new WaitForSeconds(4);

        StartCoroutine(Shoot());
    }

    

}
