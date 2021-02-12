using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int xp = 50; // When the player kills an enemy the player gets xp
    [SerializeField] public Transform target;
    [SerializeField] private BoxCollider attackRage;
    private bool isChase;
    private bool isAttack;


    Rigidbody rigid;
    CapsuleCollider capsuleCollider;
    NavMeshAgent nav;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
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
        if(isChase)
            nav.SetDestination(target.position);                       
    }
    private void FixedUpdate()
    {
        FreezeVelocity();
    }
    // When the player is in an attack range the enemy starts punching
    void OnTarget()
    {
        float targetRadius = 1.0f;
        float targetRange = 2.0f;
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
        
        // When the player is in the attack range
        if (hits.Length > 0 && !isAttack)
        {
            StartCoroutine(OnAttack());
        }
        //OnChase(); ==> Not here
    }
    IEnumerator OnAttack()
    {
        isChase = false;
        isAttack = true;
        anim.SetBool("isAttack", true);

        yield return null;
        // OnChase(); ==> Not here

    }
    void OnChase()
    {
        isChase = true;
        anim.SetBool("isWalk", true);
    }
    // Prevent the enemy from rotating
    void FreezeVelocity() // From googleit
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    // Get attack from the player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")  // Can switch with weapon
        {
            anim.SetBool("isAttack", true);
            // cache PlayerMove's script
            PlayerMove player = collision.collider.GetComponent<PlayerMove>();

            // Get damage Enemy's hp by the player's attack power
            hp -= player.damage;

            // When Enemy reaches 0 point of hp, Enemy destories
            if (hp <= 0)
            {
                // Chasing and Nav AI stop and when the enemy is dead
                isChase = false;
                nav.enabled = false;
                anim.SetTrigger("doDie");

                // Increase the player's xp
                player.xp += xp;
                Destroy(gameObject, 2);
            }
            
        }
    }

}
