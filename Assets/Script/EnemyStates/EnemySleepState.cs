using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySleepState : EnemyBaseState
{
    float sleepTimer = 60f;
    bool isAttack;
    public override void ActionState(FSMStateController enemycontroller, GameObject player, GameObject npc, NavMeshAgent enemyAgent)
    {
        sleepTimer -= Time.fixedDeltaTime;
        
    
     
            enemycontroller.anim.SetBool("sleep", true);
        
        if (sleepTimer <= 15)
        {
            enemycontroller.anim.SetBool("sleep", false);
        }
        
    }

    public override void EnterState(FSMStateController enemycontroller, GameObject player, GameObject npc, NavMeshAgent enemyAgent)
    {
       
    }

    public override void FixedUpdate(FSMStateController enemycontroller, GameObject player, GameObject npc)
    {
        
        if (sleepTimer <=0)
        {
            
            enemycontroller.TransitionToNextState(enemycontroller.enemyPartolState);
            Debug.Log("partrol");
        }
        if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 1000
               && Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) >= 600)
        {
            enemycontroller.TransitionToNextState(enemycontroller.enemyRangeAttackState);
            Debug.Log("RangeAttack");
        }
        if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 600)
        {
            enemycontroller.TransitionToNextState(enemycontroller.enemyFollowState);
            Debug.Log("Chase");
        }
        if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 200)
        {
            enemycontroller.anim.SetBool("sleep", false);
            enemycontroller.TransitionToNextState(enemycontroller.enemyAttackState);
            Debug.Log("Attack");
        }

    }


}
