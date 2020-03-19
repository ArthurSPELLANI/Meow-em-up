using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletSpeed;

    int damage = 1;

    public Animator animator;


    void Awake()
    {

    }

    void Start()
    {
        rb.velocity = new Vector2(1,0) * bulletSpeed;
    }

    void Update()
    {

    }
        

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            StartCoroutine(Death());
        }

        if (collision.gameObject.tag == "Boundaries")
        {
            Destroy(this.gameObject);
        }

        IEnumerator Death()
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetBool("isDed", true);

            yield return new WaitForSeconds(1.2f);

            Destroy(this.gameObject);
        }
    }


}
