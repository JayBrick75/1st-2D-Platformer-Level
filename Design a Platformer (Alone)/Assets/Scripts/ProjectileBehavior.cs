using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 4.5f;
    private void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Destroyable" || col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
            Destroy(gameObject);
    }
   
}
