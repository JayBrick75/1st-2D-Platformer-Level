using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    Transform player;
    PlayerManager playerManager;
    public bool isFlipped;
    public float bossHealth = 10f;
    public bool phase2 = false;
    public bool phase3 = false;
    public bool isDead = false;
    public int attackRange;
    public float speed;
    public Transform shotLocation;
    public float timer;
    public float cooldown;
    public GameObject projectile;
    public GameObject projectile2;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    void Update()
    {
        if(bossHealth < 7 && bossHealth > 3)
        {
            phase2 = true;
            attackRange = 6;
            speed = 3;
            Debug.Log("Phase2");
        }
        else if(bossHealth < 4 && bossHealth >= 1)
        {
            phase2 = false;
            phase3 = true;
            attackRange = 8;
            speed = 1;
            Debug.Log("Phase3");
        }
        else if(bossHealth <= 0)
        {
            phase3 = false;
            isDead = true;
            Debug.Log("Boss has sadly passed away");
        }

        timer += Time.deltaTime;
    }

    public void ProjectileShoot()
    {
        if (timer > cooldown)
        {
            if (phase2)
            {
                GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
            else if (phase3)
            {                                 //change object to a different one
                GameObject clone = Instantiate(projectile2, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Projectile"))
        {
            bossHealth -= 0.2f;
        }
    }
}
