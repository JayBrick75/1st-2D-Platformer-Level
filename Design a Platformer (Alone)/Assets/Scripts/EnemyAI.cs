using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // reference for waypoints
    public List<Transform> points;
    // int value for indexed list
    public int nextId;
    // declare an int to help change nextId
    private int idChangeValue = 1;
    // sets the speed of the enemy
    public float speed = 1;
    // gets the player
    public Transform player;
    // sees the player
    bool playerSeen = false;
    // puts the enemy in patrol
    bool enemyPatrol = true;

    void Update()
    {
        if (enemyPatrol == true)
        {
            MoveToNextPoint();
        }

        CheckForPlayer();

        if(playerSeen == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    void MoveToNextPoint()
    {
        // declare and set a transform to the next point
        Transform goalPoint = points[nextId];

        // flip the enemy via the transform to look at the point's direction
        // might need to change based off the sprite's natural face
        if(goalPoint.transform.position.x > transform.position.x)
        {                                   // 5
            transform.localScale = new Vector3(-5, 5, 1);
        }
        else
        {                                  // -5
            transform.localScale = new Vector3(5, 5, 1);
        }

        // move the enemy towards our point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);

        // check the distance between the enemy and the goalPoint to trigger the next point
        if(Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            // check if it's at the end of the line, make the change value -1
            if(nextId == points.Count-1)
            {
                idChangeValue = -1;
            }

            // check if it's at the start of the line, make the change value 1
            if (nextId == 0)
            {
                idChangeValue = 1;
            }
            nextId += idChangeValue;
        }
    }
    void CheckForPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) < 4f)
        {
            playerSeen = true;
            enemyPatrol = false;
        }
        else
        {
            playerSeen = false;
            enemyPatrol = true;
        }
    }
}
