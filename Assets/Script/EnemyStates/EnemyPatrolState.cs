using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyBaseState
{
    bool isWalk;                                       // control enmey walk  
    bool isIdle;                                       // control enmey idle 
    bool isAttack;
    float timer;
    int currentPoint;

    float sleepTimer = 20f;
    int sleepSpot;
    public override void ActionState(FSMStateController enemycontroller, GameObject player, GameObject npc, NavMeshAgent enemyAgent)
    {

    }

    public override void EnterState(FSMStateController enemycontroller, GameObject player, GameObject npc, NavMeshAgent enemyAgent)
    {
        //// set Enemy dirction 
        Vector3 dir = enemycontroller.patrolpoints[currentPoint].position - npc.transform.position;

        npc.transform.rotation = Quaternion.LookRotation(dir);
        Vector3 destination = enemycontroller.patrolpoints[currentPoint].position;
        enemyAgent.destination = destination;

        // if the enmey location - patrolpoints >=0.1, The enemy will play Idle animation 
        if (enemyAgent.destination.magnitude - enemycontroller.patrolpoints[currentPoint].position.magnitude >= 0.1)
        {
            isWalk = false;
            enemycontroller.anim.SetBool("Walk", false);
            isIdle = true;
            enemycontroller.anim.SetBool("idle", true);
            isAttack = false;
            enemycontroller.anim.SetBool("attack", false);


        }
        else
        {
            isWalk = true;
            enemycontroller.anim.SetBool("walk", isWalk);
            isIdle = false;
            enemycontroller.anim.SetBool("idle", isIdle);
            isAttack = false;
            enemycontroller.anim.SetBool("attack", isAttack);
        }
        timer += Time.deltaTime;
        sleepTimer -= Time.deltaTime;
        if (timer >= 5)
        {
            currentPoint += 1;
            Debug.Log(currentPoint);
            timer = 0;
        }
        if (currentPoint >= 4)
        {
            currentPoint = 0;
        }

        if (sleepTimer==0)
        {
            sleepSpot = (int)Random.Range(1, 5);
           //Debug.Log("Sleep Spot" + sleepSpot);
            sleepTimer = 20;
        }
    }



    public override void FixedUpdate(FSMStateController enemycontroller, GameObject player, GameObject npc)
    {
        //if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) >= 1000)
        //{
        //    enemycontroller.TransitionToNextState(enemycontroller.enemyPartolState);
        //    Debug.Log("Patorl");
        //}
        //else if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 600)
        //{
        //    enemycontroller.TransitionToNextState(enemycontroller.enemyFollowState);
        //    Debug.Log("Follow");
        //}

        if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 1000 
                && Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) >= 600)
        {
            enemycontroller.TransitionToNextState(enemycontroller.enemyRangeAttackState);
            Debug.Log("RangeAttack");
        }
        if (sleepTimer <= 1f )
        {
            Vector3 destination = enemycontroller.patrolpoints[sleepSpot].position;
            enemycontroller.TransitionToNextState(enemycontroller.enemySleepState);
        }
    }
}
