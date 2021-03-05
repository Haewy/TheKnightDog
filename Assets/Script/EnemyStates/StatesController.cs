using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatesController : MonoBehaviour
{
    [SerializeField] List<GameObject> enemy;
    [SerializeField] GameObject critter;
    [SerializeField] GameObject boss;
    [SerializeField] List<GameObject> bossEnemy;
    [SerializeField] GameObject player;


    string enemyTag = "Enemy";
    string bossEnemyTag = "Boss";

    bool isEmpty = false;
    private void Awake()
    {
        enemy.AddRange(GameObject.FindGameObjectsWithTag(enemyTag));
        bossEnemy.AddRange(GameObject.FindGameObjectsWithTag(bossEnemyTag));
        player = GameObject.FindGameObjectWithTag("Player");


    }
    // Start is called before the first frame update
    void Start()
    {
        //AddEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemyList(bossEnemy);
        AttackState(enemy);
        IdleState(enemy);
        AttackState(bossEnemy);
        IdleState(bossEnemy);
    }

    void IdleState(List<GameObject> enemylist)
    {
      
            foreach (GameObject critter in enemylist)
        {
            if (isEmpty == false)
            {

                if (Mathf.Abs(critter.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) >= 120)
                {
                    //Debug.Log("in Idle State");
                    //Debug.Log(Mathf.Abs(critter.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude));
                    critter.GetComponent<AttackState>().enabled = false;
                    critter.GetComponent<PatrolState>().enabled = true;
                }
            }
        }
        





    }
    void AttackState(List<GameObject> enemylist)
    {
        
            foreach (GameObject critter in enemylist)
        {
            if (isEmpty == false)
            {
                if (Mathf.Abs(critter.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 70)
                {
                    //Debug.Log(Mathf.Abs(critter.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude));
                    //Debug.Log("in Attack State");
                    critter.GetComponent<AttackState>().enabled = true;
                    critter.GetComponent<PatrolState>().enabled = false;
                }

            }
        }
        
    }
    void CheckEnemyList(List<GameObject> enemylist)
    {

        for (int i = 0; i < enemylist.Count; i++)
        {
            if (enemylist[i]==null)
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
