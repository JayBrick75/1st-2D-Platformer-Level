using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileBehavior2 : MonoBehaviour
{
    Transform player;
    Transform boss;
    Vector2 shotDirection;
    Rigidbody2D rb;
    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.FindGameObjectWithTag("Boss").transform;
        rb = GetComponent<Rigidbody2D>();

        if (boss.position.x >= player.position.x)
        {
            shotDirection = new Vector2(-1, 1.5f);
        }
        else
        {
            shotDirection = new Vector2(1, 1.5f);
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(shotDirection * speed, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Boss")
        {
            Destroy(gameObject);
        }
    }
}
