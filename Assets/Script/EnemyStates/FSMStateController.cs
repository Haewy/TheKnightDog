using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSMStateController : MonoBehaviour
{
    [SerializeField] private EnemyBaseState currentState;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject bossEnemy;
    [SerializeField] private NavMeshAgent enemyAgent;
    [SerializeField] public GameObject fireball;
    [SerializeField] public ParticleSystem projectile;
    [SerializeField] public Transform[] patrolpoints;
    [SerializeField] public Animator anim;
    public readonly EnemyPatrolState enemyPartolState = new EnemyPatrolState();
    public readonly EnemyAttackState enemyAttackState = new EnemyAttackState();
    public readonly EnemyFollowState enemyFollowState = new EnemyFollowState();
    public readonly EnemyRangeAttackState enemyRangeAttackState = new EnemyRangeAttackState();
    //public readonly EnemySleepState enemySleepState = new EnemySleepState();

    public void Start()
    {
        TransitionToNextState(enemyPartolState);
    }
    private void FixedUpdate()
    {
        currentState.FixedUpdate(this, player, bossEnemy);
        currentState.ActionState(this,player,bossEnemy,enemyAgent);
    }
    public void ActionState()
    {
        currentState.EnterState(this, player, bossEnemy, enemyAgent);
    }

    public void TransitionToNextState(EnemyBaseState state)
    {
        currentState = state;
        currentState.EnterState(this, player, bossEnemy, enemyAgent);
    }

    //public void PartrolPoints(Transform[] newPatrolpoints)
    //{
    //    patrolpoints = newPatrolpoints;
    //}
}
