using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPseudocode : MonoBehaviour
{
    // set your projectile as a prefab
    // make variables for the boss's speed and health (100)
    // make a bool for each phase and set phaseOne to true and phaseTwo and phaseThree to false

    void Update()
    {
        // check if phaseOne is true. If so, shoot a projectile forward every few seconds

        // if bossHealth < 66, set phaseTwo to true

        // check if phaseTwo is true. If so, increase bossSpeed by 5 and utilize the same code for shooting a projectile, but implement force to make it move in an arch

        // if bossHealth < 33, set phaseThree to true

        // check if phaseThree is true. If so, increase bossSpeed by 5 more and make projectiles turn on an explosion trigger hitbox around themselves which damages the player
    }
}
