using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    BossBehaviour bossBehaviour;
    public float attackRange = 2f;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb = animator.GetComponent<Rigidbody2D>();

        bossBehaviour = animator.GetComponent<BossBehaviour>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossBehaviour.LookAtPlayer();

        // declare and set the player to a target variable
        Vector2 target = new Vector2(player.position.x, rb.position.y);

        // set the new position for our boss to move to
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, bossBehaviour.speed * Time.deltaTime);

        // tell our boss's rb to move to the new position
        rb.MovePosition(newPos);

        float distance = Vector2.Distance(player.position, rb.position);

        if (distance < bossBehaviour.attackRange && !bossBehaviour.phase2 && !bossBehaviour.phase3)
        {
            Debug.Log("Hit!!");
            animator.SetTrigger("MeleeAttack");
        }
        else if(distance < bossBehaviour.attackRange && bossBehaviour.phase2 && !bossBehaviour.phase3)
        {
            animator.SetTrigger("Phase2Attack");
        }
        else if(distance < bossBehaviour.attackRange && !bossBehaviour.phase2 && bossBehaviour.phase3)
        {
            animator.SetTrigger("Phase3Attack");      
        }
        else if (bossBehaviour.isDead)
        {
            animator.SetTrigger("Death");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
