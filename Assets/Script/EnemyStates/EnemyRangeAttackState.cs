using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRangeAttackState : EnemyBaseState
{
    float timer;

    public override void ActionState(FSMStateController enemycontroller, GameObject player, GameObject npc, NavMeshAgent enemyAgent)
    {
        timer += Time.deltaTime;
        Vector3 dir = player.transform.position - npc.transform.position;
        npc.transform.rotation = Quaternion.LookRotation(dir);

        if (timer >= 3)
        {
            timer = 0;
            //isRangeAttack = true;
            Vector3 particalPosition = enemycontroller.fireball.transform.position;
            Quaternion particalRotation = Quaternion.LookRotation(npc.transform.forward * -1f);
            ParticleSystem inParticle = UnityEngine.Object.Instantiate(enemycontroller.projectile, particalPosition, particalRotation);
            enemycontroller.anim.SetBool("fire", true);
        }
        else
        {
            enemycontroller.anim.SetBool("fire", false);
            // isRangeAttack = false;
        }
    }

    public override void EnterState(FSMStateController enemycontroller, GameObject player, GameObject npc, NavMeshAgent enemyAgent)
    {
        Vector3 destination = player.transform.position;
        //enemyAgent.destination = destination + new Vector3(300,300,300);
        enemyAgent.destination = npc.transform.position;
        float moveMage = Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude);
        if (moveMage <= 500)
        {
            //Debug.Log("Fire!!!!");
            enemyAgent.velocity = Vector3.zero;
        }

    }
    public override void FixedUpdate(FSMStateController enemycontroller, GameObject player, GameObject npc)
    {

        if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) >= 1000)
        {
            enemycontroller.TransitionToNextState(enemycontroller.enemyPartolState);
            Debug.Log("Patorl");
        }

        if ((Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 1000)&& 
            (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) >= 100))
        {
            enemycontroller.TransitionToNextState(enemycontroller.enemyFollowState);
            Debug.Log("Chase");
        }
        if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 100)
        {
            enemycontroller.TransitionToNextState(enemycontroller.enemyAttackState);
            Debug.Log("Attack");
        }
    }

}



//if (moveMage <=500 )
//{
//    //Debug.Log("Fire!!!!");
//    enemyAgent.velocity = Vector3.zero;
//}
//else
//{

//}
