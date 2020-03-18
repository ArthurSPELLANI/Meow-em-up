using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDog : MonoBehaviour
{
    public GameObject enemyBigBullet;
    PlayerManager player;
    Rigidbody2D rb;
    Vector3 dogMovement;
    public float speed;
    Quaternion rotation = Quaternion.identity;

    public AnimationCurve moveCurve;

    void Start()
    {
        StartCoroutine(Shoot());
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(-0.5f, Mathf.Sin(Time.timeSinceLevelLoad * 2) * speed);
    }

    IEnumerator Shoot()
    {
        Instantiate(enemyBigBullet, this.transform.position, rotation);               

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(Shoot());
    }
}
