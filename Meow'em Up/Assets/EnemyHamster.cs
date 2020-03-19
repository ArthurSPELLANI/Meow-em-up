using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHamster : MonoBehaviour
{

    public GameObject enemyBullet;
    PlayerManager player;
    Rigidbody2D rb;
    Vector3 dogMovement;
    Quaternion rotation = Quaternion.identity;
    bool location = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody2D>();

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

    IEnumerator Shoot()
    {
        Instantiate(enemyBullet, this.transform.position, rotation);

        yield return new WaitForSeconds(0.8f);

        StartCoroutine(Shoot());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            location = true;
        }
    }
}
