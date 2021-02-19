using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private enum EnemyType { Burrow,Log };
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private int hp;
    [SerializeField] private int damage = 10;
    [SerializeField] private int xp = 50; // When the player kills an enemy the player gets xp
    [SerializeField] public Transform target;
    [SerializeField] private BoxCollider attackRage;
    private bool isChase;
    private bool isAttack;
    

    Rigidbody rigid;
    NavMeshAgent nav;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();       
        anim = GetComponent<Animator>();

        Invoke("OnChase", 2);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (nav.enabled)
        {
            nav.SetDestination(target.position);
            nav.isStopped = !isChase;
        }                              
    }
    private void FixedUpdate()
    {
        FreezeVelocity();
    }
    // When the player is in an attack range the enemy starts punching
    void OnTarget()
    {
        float targetRadius = 0;
        float targetRange = 0;

        switch (enemyType)
        {
            case EnemyType.Burrow:
                targetRadius = 0.5f;
                targetRange = 0.2f;
                break;
            case EnemyType.Log:                

                targetRadius = 0.5f;
                targetRange = 50.0f;
                rigid.AddForce(Vector3.up,ForceMode.Impulse);
                break;
            default:
                break;
        }
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
        
        // When the player is in the attack range
        if (hits.Length > 0 && !isAttack) //hits.Length > 0 
        {
            StartCoroutine(OnAttack());
        }
    }
    IEnumerator OnAttack()
    {
        isChase = false;
        isAttack = true;
        anim.SetBool("isAttack", isAttack);

        // Boxcollider attackRage ON
        attackRage.enabled = true;

        yield return new WaitForSeconds(0.3f);
        // Boxcollider attackRange OFF
        attackRage.enabled = false;
        isChase = false;

        yield return new WaitForSeconds(0.3f);
        // End of Attacking then chasing again
        isChase = true;
        isAttack = false;
        anim.SetBool("isAttack", false);       

    }
    void OnChase()
    {
        isChase = true;
        isAttack = false;
        anim.SetBool("isWalk", true);
    }
    // Prevent the enemy from rotating
    void FreezeVelocity() // From googleit
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    // Get attack from the player (Damaging)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider. tag == "Player")  // Can switch with weapon
        {
            StartCoroutine(OnAttack());

            // cache PlayerMove's script
            CharacterStats player = collision.collider.GetComponent<CharacterStats>(); 
            // Get damage Enemy's hp by the player's attack power
            hp -= damage;

            // When Enemy reaches 0 point of hp, Enemy destories
            if (hp <= 0)
            {
                // Chasing and Nav AI stop and when the enemy is dead
                isChase = false;
                nav.enabled = false;
                anim.SetTrigger("doDie");

                // Increase the player's xp
                player.curentXp += xp;
                Destroy(gameObject, 2.0f); // ?? it does not work
                
            }
            
        }
    }

}
