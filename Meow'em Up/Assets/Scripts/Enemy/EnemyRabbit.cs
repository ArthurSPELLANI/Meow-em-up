using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRabbit : MonoBehaviour
{
    private Rigidbody2D EnemyRb;
    public int speed;
    public int speedDash;

    public int damage = 2;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(TimedDestroy());
        EnemyRb.velocity = new Vector2(-1, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        yield return new WaitForSeconds(2f);

        EnemyRb.velocity = new Vector2(-(this.transform.position.x - player.transform.position.x), -(this.transform.position.y - player.transform.position.y)).normalized * speedDash;

        yield return new WaitForSeconds(10f);

        Destroy(gameObject);
    }
}
