using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PatrolState : MonoBehaviour
{
    
    [SerializeField] private Transform[] patrolpoints; // Get all the Partrol points
    [SerializeField] public int currentPoint = 0;      // Get current points the enemy should go 
    [SerializeField] private GameObject enemy;         // Get the Enemy Object 
    [SerializeField] private NavMeshAgent enemyAgent;  // Get Enemy NavMesh

    private Vector3 destination;                       // Set current points(current transform)
    private Vector3 dir;                               // Set Enemy current Rotation 

    float timer;                                       // Count the time for the enemy for how long the enemy move to next partrol points

        
    public Animator anim;                              // Get the Animator control the current animation
    
    bool isWalk;                                       // control enmey walk  
    bool isIdle;                                       // control enmey idle 
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAgent = GetComponent<NavMeshAgent>();

    }
    public void Reaction()
    {
        TimeCounter();
    }

    public void CurrentSate()
    {
        // Timer equal to 0, the enemy will move
        if (timer == 0)
        {
            // set Enemy dirction 
            dir = patrolpoints[currentPoint].position - enemy.transform.position;
            enemy.transform.rotation = Quaternion.LookRotation(dir);
            destination = patrolpoints[currentPoint].position;
            enemyAgent.destination = destination;
            
            // if the enmey location - patrolpoints >=0.1, The enemy will play Idle animation 
            if (enemyAgent.destination.magnitude - patrolpoints[currentPoint].position.magnitude >= 0.1)
            {
                isWalk = false;
                anim.SetBool("walk", isWalk);
                isIdle = true;
                anim.SetBool("idle", isIdle);
              
            }
            else
            {
                isWalk = true;
                anim.SetBool("walk", isWalk);
                isIdle = false;
                anim.SetBool("idle", isIdle);
            }

            /* count the currentPoints 
            /* if the currentpoint is higher than the Patrol List size 
            /* the Currenrtpoints will reset to 0              
             */

            currentPoint += 1;
            if (currentPoint >= patrolpoints.Length)
            {
                currentPoint = 0;
            }
        }
    }
    // TimeCouter will count how long the enemy will move to the next point 
    void TimeCounter()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            timer = 0;
        }
    }
    private void FixedUpdate()
    {
        Reaction();
        CurrentSate();
    }

    void Update()
    {

    }
}
