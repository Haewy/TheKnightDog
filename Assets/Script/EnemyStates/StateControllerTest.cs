using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateControllerTest : MonoBehaviour
{
    [SerializeField] List<GameObject> enemy;
    [SerializeField] GameObject critter;
    [SerializeField] GameObject boss;
    [SerializeField] List<GameObject> bossEnemy;
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
    bool isEmpty;


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

        enemy.AddRange(GameObject.FindGameObjectsWithTag(enemyTag));
        bossEnemy.AddRange(GameObject.FindGameObjectsWithTag(bossEnemyTag));
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemyList(enemy);
        CheckEnemyList(bossEnemy);

        CheckIdleState(enemy);
        CheckAttackState(enemy);

        CheckChaseState(bossEnemy);
        CheckIdleState(bossEnemy);
        CheckAttackState(bossEnemy);
        CheckRangeState(bossEnemy);

    }
    private void FixedUpdate()
    {

        //CheckChaseState(bossEnemy);

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



    private void CheckIdleState(List<GameObject> enemylist)
    {

        foreach (GameObject critter in enemylist)
        {
            if (isEmpty == false)
            {

                if (Mathf.Abs(critter.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) >= 1000) // 500
                {
                    isAttack = false;
                    isPatrol = true;
                    isChase = false;
                    isRange = false;
                    RunPatrolState();
                    Debug.Log("Run Idle");
                }
            }
        }
    }
    void CheckAttackState(List<GameObject> enemylist)
    {

        foreach (GameObject critter in enemylist)
        {
            if (isEmpty == false)
            {
                if (Mathf.Abs(critter.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 100)
                {
                    isPatrol = false;
                    isChase = false;
                    isAttack = true;
                    isRange = false;
                    RunAttackState();

                    Debug.Log("Run Attack");

                }
            }

        }

    }
    void CheckRangeState(List<GameObject> enemylist)
    {

        foreach (GameObject critter in enemylist)
        {
            if (isEmpty == false)
            {
                if (Mathf.Abs(critter.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 500)
                {
                    isChase = false;
                    isPatrol = false;
                    isAttack = false;
                    isRange = true; 
                    RunRangeState();

                    Debug.Log("Range Attack Chase");

                }

            }
            else
            {
                bossEnemy.Clear();
            }
        }

    }
    void CheckChaseState(List<GameObject> enemylist)
    {

        foreach (GameObject critter in enemylist)
        {
            if (isEmpty == false)
            {
                if (Mathf.Abs(critter.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 100) // 200
                {
                    isChase = true;
                    isPatrol = false;
                    isAttack = false;
                    isRange = false;
                    RunChaseState();

                    Debug.Log("Run Chase");

                }

            }
            else
            {
                bossEnemy.Clear();
            }
        }

    }
    void CheckEnemyList(List<GameObject> enemylist)
    {
        for (int i = 0; i < enemylist.Count; i++)
        {
            if (enemylist[i] == null)
            {
                isEmpty = true;
                Destroy(this);
            }
            else
            {
                isEmpty = false;
            }
        }

    }
}
