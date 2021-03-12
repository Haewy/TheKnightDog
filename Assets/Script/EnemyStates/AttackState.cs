using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[System.Serializable]
public class AttackState : MonoBehaviour
{
    [SerializeField] private Transform player;         // Get all the Partrol points
    [SerializeField] private GameObject enemy;         // Get the Enemy Object 
    [SerializeField] private NavMeshAgent enemyAgent;  // Get Enemy NavMesh
    public Animator anim;
    [SerializeField]private SphereCollider attackRange;
    private Vector3 destination;                       // Set current points(current transform)
    private Vector3 dir;
    [SerializeField] float range;

    private float moveMage;
    public CharacterStats playerState;

    bool isIdle;
    bool isWalk;                                       // control enmey walk  
    bool isAttack;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAgent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        //AttackChase();
    }
    public void AttackChase()
    {
        if (enemy != null)
        {
            //dir = player.position - enemy.transform.position;
            //enemy.transform.rotation = Quaternion.LookRotation(dir);

            //destination = player.position;
            //enemyAgent.destination = destination;

            moveMage = Mathf.Abs(enemy.transform.position.sqrMagnitude - player.position.sqrMagnitude);



            if (moveMage >= enemyAgent.stoppingDistance)
            {

                //Debug.Log(Mathf.Abs(enemy.transform.position.sqrMagnitude - player.position.sqrMagnitude));
                //isWalk = true;
                //anim.SetBool("walk", isWalk);
                //if (isAttack)
                //{
                //    playerState.GetDamage(10);
                //}
                //isAttack = false;
                //anim.SetBool("attack", isAttack);

            }

            else if (moveMage <= enemyAgent.stoppingDistance)
            {
                enemyAgent.velocity = Vector3.zero;

            }
            else
            {

                //Debug.Log(Mathf.Abs(enemy.transform.position.sqrMagnitude - player.position.sqrMagnitude));
                isWalk = false;
                anim.SetBool("walk", isWalk);

                isAttack = true;
                anim.SetBool("attack", isAttack);
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (enemy != null)
        {
            isIdle = false;
            anim.SetBool("idle", isIdle);
            isAttack = true;
            anim.SetBool("attack", isAttack);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (enemy != null)
        {

            isAttack = false ;
            anim.SetBool("attack", isAttack);
        }
    }


}
