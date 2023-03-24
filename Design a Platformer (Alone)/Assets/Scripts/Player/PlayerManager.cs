using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    public int coinCount;
    public int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("Player has died");
            // Player Death
        }
    }
    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Coin":
                coinCount++;
                return true;
            case "Diamond":
                playerMovement.diamondPickedUp = true;
                return true;
            case "Flashlight":
                Destroy(GameObject.FindGameObjectWithTag("Door"));
                return true;
            case "Speed+":
                playerMovement.SpeedPowerUp();
                return true;
            case "Wings":
                playerMovement.JumpPowerUp();
                return true;
            default:
                Debug.Log("No tag on this game object");
                return false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BossProjectile")
        {
            playerHealth -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerDetectionZone")
        {
            playerHealth -= 1;
            Debug.Log("Player got caught");
        }
    }
    public void TakeDamage()
    {
        playerHealth -= 1;
    }
}
