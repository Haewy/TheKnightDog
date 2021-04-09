using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowState : EnemyBaseState
{
    bool isIdle;
    bool isWalk;
    public override void ActionState(FSMStateController enemycontroller, GameObject player, GameObject npc, NavMeshAgent enemyAgent)
    {
        Vector3 dir = player.transform.position - npc.transform.position;
        npc.transform.rotation = Quaternion.LookRotation(dir);
        Vector3 destination = player.transform.position;
        enemyAgent.destination = destination;
        float moveMage = Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude);
        if (moveMage >= 100f)
        {
            //Debug.Log(Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude));
            isWalk = true;
            enemycontroller.anim.SetBool("walk", isWalk);
        }
        else if (moveMage <= enemyAgent.stoppingDistance)
        {
            enemyAgent.velocity = Vector3.zero;
        }
        else
        {
            isWalk = false;
            enemycontroller.anim.SetBool("walk", isWalk);
        }
    }

    public override void EnterState(FSMStateController enemycontroller, GameObject player, GameObject npc, NavMeshAgent enemyAgent)
    {

       
    }


    public override void FixedUpdate(FSMStateController enemycontroller, GameObject player, GameObject npc)
    {
        if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) >= 1000)
        {
            enemycontroller.TransitionToNextState(enemycontroller.enemyPartolState);
            Debug.Log("Patorl");
        }
        if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 1000 
            && Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude)>=600)
        {
            enemycontroller.TransitionToNextState(enemycontroller.enemyRangeAttackState);
            Debug.Log("RangeAttack");
        }
        if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 100)
        {
            enemycontroller.TransitionToNextState(enemycontroller.enemyAttackState);
            Debug.Log("Attack");
        }
    }
}




//Debug.Log("Eneter Attack ");
//Vector3 dir = player.transform.position - npc.transform.position;
//npc.transform.rotation = Quaternion.LookRotation(dir);
//Vector3 destination = player.transform.position;
//enemyAgent.destination = destination;
//float moveMage = Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude);
//if (moveMage >= 100f)
//{
//    Debug.Log(Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude));
//    isWalk = true;
//    enemycontroller.anim.SetBool("walk", isWalk);
//}
//else if (moveMage <= enemyAgent.stoppingDistance)
//{
//    enemyAgent.velocity = Vector3.zero;
//}
//else
//{
//    isWalk = false;
//    enemycontroller.anim.SetBool("walk", isWalk);
//}