using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;



public class StateControllerEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject player;
    [Space]
    [Header("Events")]
    [Space]
    public UnityEvent attackState;
    public UnityEvent patrolState;
    public UnityEvent chaseState;
    public UnityEvent rangeState;

    [SerializeField] bool isAttack;
    [SerializeField] bool isPatrol;
    [SerializeField] bool isChase;
    [SerializeField] bool isRange;
    string enemyTag = "Enemy";
    string bossEnemyTag = "Boss";
    public bool isEmpty;


    private void Awake()
    {
        if (attackState == null)
        {
            attackState = new UnityEvent();
        }
        if (patrolState == null)
        {
            patrolState = new UnityEvent();
        }
        if (rangeState == null)
        {
            rangeState = new UnityEvent();
        }
        isAttack = false;
        isPatrol = false;
        isChase = false;
        isRange = false;

        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // CheckEvent();


    }
    private void FixedUpdate()
    {
        //CheckEnemyList(enemy);
        //CheckEnemyList(bossEnemy);

        CheckIdleState(enemy);
        //CheckAttackState(enemy);

        //CheckChaseState(enemy);
        //CheckRangeState(enemy);

        //CheckChaseState(bossEnemy);
        //CheckIdleState(bossEnemy);
        //CheckAttackState(bossEnemy);

    }
    public void RunAttackState()
    {
        if (isAttack == true)
        {

            attackState.Invoke();

        }

    }
    public void RunPatrolState()
    {
        if (isPatrol == true)
        {

            patrolState.Invoke();

        }
    }
    public void RunChaseState()
    {
        if (isChase == true)
        {

            chaseState.Invoke();

        }
    }
    public void RunRangeState()
    {
        if (isRange == true)
        {

            rangeState.Invoke();

        }

    }



    private void CheckIdleState(GameObject enemy)
    {
                if (Mathf.Abs(enemy.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <=600) // 500
                {
                    isAttack = false;
                    isPatrol = true;
                    isChase = false;
                    isRange = false;
                    RunPatrolState();
                    Debug.Log("Run Idle");
                }
    }
    void CheckAttackState(GameObject enemy)
    {
                if (Mathf.Abs(enemy.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 100)
                {
                    isPatrol = false;
                    isChase = false;
                    isAttack = true;
                    isRange = false;
                    RunAttackState();

                    // Debug.Log("Run Attack");
                }

    }
    void CheckRangeState(GameObject enemy)
    {
           
                if (Mathf.Abs(enemy.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 500&& Mathf.Abs(enemy.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude)>=200)
        {
                    isChase = false;
                    isPatrol = false;
                    isAttack = false;
                    isRange = true;
                    RunRangeState();
                    // Debug.Log("Range Attack Chase");
                }
    }
    void CheckChaseState(GameObject enemy)
    {
                if (Mathf.Abs(enemy.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 200) // 200
                {
                    isChase = true;
                    isPatrol = false;
                    isAttack = false;
                    isRange = false;
                    RunChaseState();
                    //Debug.Log("Run Chase");
                }
    }
    //void CheckEnemyList(GameObject enemy)
    //{
       
    //        if (enemy == null)
    //        {
    //            isEmpty = true;
                
    //            isAttack = false;
    //            isPatrol = false;
    //            isChase = false;
    //            isRange = false;

    //            //enemy.Clear();
    //        }
    //        else
    //        {
    //            Debug.Log("IsNOTEmpty");

    //            isEmpty = false;
    //        }
        

    //}

    //void CheckEvent()
    //{
    //    for (int i = 0; i < attackState.GetPersistentEventCount(); i++)
    //    {
    //        if (attackState.GetPersistentTarget(i) == null)
    //        {
    //            attackState.RemoveListener(null);
    //        }
    //    }
    //    for (int i = 0; i < rangeState.GetPersistentEventCount(); i++)
    //    {
    //        if (rangeState.GetPersistentTarget(i) == null)
    //        {


    //            Debug.Log("DElete Event");
    //        }
    //    }
    //}
}
