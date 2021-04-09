
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBaseState 
{
    public abstract void EnterState(FSMStateController enemycontroller, GameObject player, GameObject npc, NavMeshAgent enemyAgent);
    public abstract void ActionState(FSMStateController enemycontroller, GameObject player, GameObject npc, NavMeshAgent enemyAgent);

    public abstract void FixedUpdate(FSMStateController enemycontroller, GameObject player, GameObject npc);
}
