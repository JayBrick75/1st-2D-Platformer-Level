using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager manager = collision.GetComponent<PlayerManager>();

            if (manager)
            {
                bool pickedUp = manager.PickupItem(gameObject);
                if (pickedUp)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
