using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackState : EnemyBaseState
{
    private float timer;
    public override void ActionState(FSMStateController enemycontroller, GameObject player, GameObject npc, NavMeshAgent enemyAgent)
    {
        
        timer += Time.deltaTime;
        if (timer>=3)
        {
            timer = 0;
        }
        Vector3 dir = player.transform.position - npc.transform.position;
        npc.transform.rotation = Quaternion.LookRotation(dir);

        if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 100)
        {
            enemycontroller.anim.SetBool("attack", true);
            
        }
        else
        {
            enemycontroller.anim.SetBool("attack", false);
        }
    }

    public override void EnterState(FSMStateController enemycontroller, GameObject player, GameObject npc, NavMeshAgent enemyAgent)
    {
        

    }


    public override void FixedUpdate(FSMStateController enemycontroller, GameObject player, GameObject npc)
    {
        if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) >= 100)
        {
            enemycontroller.anim.SetBool("attack", false);
            enemycontroller.TransitionToNextState(enemycontroller.enemyFollowState);
            Debug.Log("Chase");
        }
        if (Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) >= 600
            && Mathf.Abs(npc.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 1000)
        {
            enemycontroller.TransitionToNextState(enemycontroller.enemyRangeAttackState);
            Debug.Log("Range");
        }




    }
}
