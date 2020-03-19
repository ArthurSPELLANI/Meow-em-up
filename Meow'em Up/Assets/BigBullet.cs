using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletSpeed;

    public int damage = 1;

    GameObject player;


    void Awake()
    {
        
    }

    void Start()
    {
        rb.velocity = new Vector2(-1, 0) * bulletSpeed;
        StartCoroutine(TargetPlayer());
    }

    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInParent<PlayerManager>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Boundaries")
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator TargetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        yield return new WaitForSeconds(2f);

        rb.velocity = new Vector2(-(this.transform.position.x - player.transform.position.x), -(this.transform.position.y - player.transform.position.y)) * bulletSpeed;

    }
}