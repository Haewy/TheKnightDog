using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //https://flowtree.tistory.com/19?category=378006

    [SerializeField] private enum EnemyType { Burrow,Log,Mushroom };
    [SerializeField] private EnemyType enemyType;
    [SerializeField] public int hp;
    [SerializeField] public int damage = 10;
    [SerializeField] private int xp; // When the player kills an enemy the player gets xp // Burrow: 20, Log: 40, Boss: 100
    [SerializeField] public Transform target;
    [SerializeField] private BoxCollider attackRange; // Work for the enemy keeps repeating attack and stop in a
    [SerializeField] public GameObject fireBall;

    private float distance;
    //private Transform log;
    private bool isChase;
    private bool isAttack;

    //LogAxe logAxe;
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
     
    }
   
    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        
        if (nav.enabled)
        {
            nav.SetDestination(target.position);
            nav.isStopped = !isChase;
        }
        OnTarget();

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
                targetRadius = 1.5f;
                targetRange = 0.5f;
;                break;
            case EnemyType.Log:
                targetRadius = 1.0f;
                targetRange = 5f;                
                break;
            case EnemyType.Mushroom:
                targetRadius = 0.5f;
                targetRange = 20f;
                break;
            default:
                break;
        }
        // https://blog.naver.com/bsheep91/221486230188
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

        switch (enemyType)
        {
            case EnemyType.Burrow:
                anim.SetBool("isAttack", true);
                yield return new WaitForSeconds(0.3f);
                attackRange.enabled = true;
                yield return new WaitForSeconds(0.3f);
                attackRange.enabled = false;
                yield return new WaitForSeconds(0.3f);

                break;

            case EnemyType.Log:
                this.transform.LookAt(target.transform);

                yield return new WaitForSeconds(0.3f);
                rigid.AddForce(transform.forward * 50f, ForceMode.Impulse);
                attackRange.enabled = true;
                yield return new WaitForSeconds(0.3f);
                rigid.velocity = Vector3.zero;
                attackRange.enabled = false;
                yield return new WaitForSeconds(1f);

                break;
            case EnemyType.Mushroom:
                yield return new WaitForSeconds(0.3f);
                GameObject instanceFireBall = Instantiate(fireBall, transform.position, transform.rotation);
                Rigidbody rigidFireBall = instanceFireBall.GetComponent<Rigidbody>();
                rigidFireBall.velocity = transform.forward * 20;
                yield return new WaitForSeconds(1f);

                break;
            default:
                break;
        }
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
    //IEnumerator OnDamage()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    // cache PlayerMove's script
    //    //CharacterStats player = GetComponent<CharacterStats>();
    //    PlayerMove player1 = GetComponent<PlayerMove>();
    //    // When Enemy reaches 0 point of hp, Enemy destories
    //    if (hp <= 0)
    //    {
    //        // Chasing and Nav AI stop and when the enemy is dead
    //        //isChase = false;
    //        //nav.enabled = false;


    //        // Increase the player's xp
    //        switch (enemyType)
    //        {
    //            case EnemyType.Burrow:
    //                isChase = false;
    //                nav.enabled = false;
    //                anim.SetTrigger("doDie");
    //                xp = 20;
    //                break;
    //            case EnemyType.Log:
    //                isChase = false;
    //                nav.enabled = false;
    //                anim.SetBool("isWalk", false);

    //                //rigid.AddForce(transform.localPosition.x, -0.12f, transform.localPosition.z);
    //                //this.transform.position = this.transform.position + new Vector3(0, -0.2f, 0);
    //                this.transform.position = new Vector3(transform.position.x, -0.2f, transform.position.z);
    //                xp = 40;
    //                break;
    //            default:
    //                break;
    //        }
    //        //player.curentXp += xp;
    //        player1.xp += xp;
    //    }
    //}
    // Prevent the enemy from rotating
    void FreezeVelocity() // From googleit
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        //if (isChase)
        //{
        //    rigid.velocity = Vector3.zero;
        //    rigid.angularVelocity = Vector3.zero;
        //}

    }

    // Get attack from the player (Damaging)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Weapon" || collision.collider.tag == "Player")  // || collision.collider.tag == "Player"
        {
           // hp -= damage;

            // cache PlayerMove's script
            CharacterStats player = collision.collider.GetComponent<CharacterStats>();
            //PlayerMove player1 = collision.collider.GetComponent<PlayerMove>();
            
            // When Enemy reaches 0 point of hp, Enemy destories
            if (hp <= 0)
            {
                // Chasing and Nav AI stop and when the enemy is dead
                isChase = false;
                nav.enabled = false;

                // Increase the player's xp
                switch (enemyType)
                {
                    case EnemyType.Burrow:
                        anim.SetTrigger("doDie");
                        xp = 20;
                        Destroy(gameObject, 3.0f);
                        break;
                    case EnemyType.Log:
                        anim.SetBool("isWalk", false);
                        anim.SetBool("isAttack", false);
                        xp = 40;
                        break;
                    default:
                        break;
                }
                player.curentXp += xp;
                //player1.xp += xp;
                //Destroy(gameObject, 3.0f);
            }

        }
    }

}
