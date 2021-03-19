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

    [SerializeField] bool isAttack;
    [SerializeField] bool isPatrol;
    [SerializeField] bool isChase;

    string enemyTag = "Enemy";
    string bossEnemyTag = "Boss";
    bool isEmpty;


    private void Awake()
    {
        if (attackState==null)
        {
            attackState = new UnityEvent();
        }
        if (patrolState == null)
        {
            patrolState = new UnityEvent();
        }
        isAttack = false;
        isPatrol = false;
        isChase = false;

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
        
     
    }
    private void FixedUpdate()
    {
        //CheckIdleState(enemy);
        CheckIdleState(bossEnemy);
        CheckAttackState(bossEnemy);
        CheckChaseState(bossEnemy);

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

    private void CheckIdleState(List<GameObject> enemylist)
    {

        foreach (GameObject critter in enemylist)
        {
            if (isEmpty == false || bossEnemy!=null)
            {

                if (Mathf.Abs(critter.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) >= 500)
                {
                    isAttack = false;
                    isPatrol = true;
                    isChase = false;
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
                if (Mathf.Abs(critter.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 100&& isChase==true)
                {
                    isPatrol = false;
                    isChase = false;
                    isAttack = true;
                    RunAttackState();

                    Debug.Log("Run Attack");

                }

            }
        }

    }

    void CheckChaseState(List<GameObject> enemylist)
    {

        foreach (GameObject critter in enemylist)
        {
            if (isEmpty == false)
            {
                if (Mathf.Abs(critter.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 200)
                {
                    isChase = true;
                    isPatrol = false;
                    isAttack = false;
                    RunChaseState();

                    Debug.Log("Run Chase");

                }

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
            }
            else
            {
                isEmpty = false;
            }
        }

    }
}
