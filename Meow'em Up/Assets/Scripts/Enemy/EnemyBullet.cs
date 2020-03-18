using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletSpeed;

    float damage = 1f;


    void Awake()
    {

    }

    void Start()
    {
        rb.velocity = new Vector2(-1, 0) * bulletSpeed;
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
}
