using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRabbit : MonoBehaviour
{
    private Rigidbody2D EnemyRb;
    public int speed;

    public int damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody2D>();
        StartCoroutine(TimedDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        EnemyRb.velocity = new Vector2(-1,0) * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInParent<PlayerManager>().TakeDamage(damage);
            GetComponent<Enemy>().healthPoint = 0;
        }
    }

    IEnumerator TimedDestroy()
    {
        yield return new WaitForSeconds(10f);

        Destroy(gameObject);
    }
}
