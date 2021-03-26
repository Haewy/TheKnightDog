using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeAttackState : MonoBehaviour
{

    [SerializeField] private Transform player;         // Get all the Partrol points
    [SerializeField] private GameObject enemy;         // Get the Enemy Object 
    [SerializeField] private NavMeshAgent enemyAgent;  // Get Enemy NavMesh

    [SerializeField] GameObject fireball;
    [SerializeField] ParticleSystem Particle;

    public Animator anim;
    // [SerializeField] private SphereCollider attackRange;
    private Vector3 destination;                       // Set current points(current transform)
    private Vector3 dir;
    //[SerializeField] float range;

    private float moveMage;
    public CharacterStats playerState;

    bool isIdle;
    bool isWalk;                                       // control enmey walk  
    bool isAttack;
    bool isRangeAttack;

    float timer;

    private void Awake()
    {
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
      //  TimerCount();
    }

    public void OnRangeAttack()
    {
        TimerCount();
        dir = player.position - enemy.transform.position;
        enemy.transform.rotation = Quaternion.LookRotation(dir);

        destination = player.position;
        enemyAgent.destination = destination;

        moveMage = Mathf.Abs(enemy.transform.position.sqrMagnitude - player.position.sqrMagnitude);
        if (isRangeAttack == true)
        {
            RangeAttack();
        }


        //RangeAttack();



        //ParticleSystem inParticle = Instantiate(Particle);
        //inParticle.transform.position = fireball.transform.position;

        //inParticle.transform.rotation = Quaternion.LookRotation(player.transform.forward * -1f);

        //        if (moveMage >= 100f)
        //        {
        //            //Debug.Log(Mathf.Abs(enemy.transform.position.sqrMagnitude - player.position.sqrMagnitude));
        //            isWalk = true;
        //            anim.SetBool("walk", isWalk);


        //        }
        //        else if (moveMage <= enemyAgent.stoppingDistance)
        //        {
        //            enemyAgent.velocity = Vector3.zero;
        //        }
        //        else
        //        {
        //            isWalk = false;
        //            anim.SetBool("walk", isWalk);
        //        }
        //    }

    }
    public void RangeAttack()
    {
        ParticleSystem inParticle = Instantiate(Particle);
        inParticle.transform.position = fireball.transform.position;

        inParticle.transform.rotation = Quaternion.LookRotation(player.transform.forward * -1f);


        Debug.Log("FIRE!!!!!!!!!");
        ////fireball.transform.position - player.transform.position
        //inParticle.GetComponent<Rigidbody>().AddForce(inParticle.transform.forward * speed * Time.deltaTime);

        //rig.AddForce(inParticle.transform.position.x * speed, 0, 0);

        //Destroy(inParticle, 0.1f);

    }
    public bool TimerCount()
    {

        timer += Time.deltaTime;
        if (timer >= 3)
        {
            timer = 0;
            return isRangeAttack = true;
        }
        else
        {
            return isRangeAttack = false;
        }

    }

}
