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
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform fireBallPos;
    public CharacterStats playerState;
    public GameObject reward;
    public Transform enemyDeadPos;

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
    }

    public void AttackState()
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
                targetRange = 3.0f;                
                break;
            case EnemyType.Mushroom:
                targetRadius = 0.5f;
                targetRange = 10f;
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
                playerState.GetDamage(10);
                yield return new WaitForSeconds(0.3f);
                attackRange.enabled = true;
                yield return new WaitForSeconds(0.3f);
                attackRange.enabled = false;
                yield return new WaitForSeconds(0.3f);

                break;

            case EnemyType.Log:
                this.transform.LookAt(target.transform);
                //playerState.GetDamage(10);
                yield return new WaitForSeconds(0.3f);
                rigid.AddForce(transform.forward * 50f, ForceMode.Impulse);
                attackRange.enabled = true;
                yield return new WaitForSeconds(0.3f);
                rigid.velocity = Vector3.zero;
                attackRange.enabled = false;
                yield return new WaitForSeconds(1f);

                break;
            case EnemyType.Mushroom:
                anim.SetBool("isAttack", true);
                //playerState.GetDamage(10);
                yield return new WaitForSeconds(0.3f);
                GameObject instanceFireBall = Instantiate(fireBall, fireBallPos.position, fireBallPos.rotation);
                instanceFireBall.GetComponent<Rigidbody>().AddForce(fireBallPos.forward * 20f, ForceMode.Impulse);
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

    // Prevent the enemy from rotating
    void FreezeVelocity() // From googleit
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;

    }

    // Get attack from the player (Damaging)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Weapon")  // || collision.collider.tag == "Player"
        {
            hp -= damage;
            
            // When Enemy reaches 0 point of hp, Enemy destories
            if (hp <= 0)
            {
                // Chasing and Nav AI stop and when the enemy is dead
                isChase = false;
                isAttack = false;
                nav.enabled = false;
                
                // Increase the player's xp
                switch (enemyType)
                {
                    case EnemyType.Burrow:                        
                        anim.SetTrigger("doDie");
                        xp = 20;
                        Destroy(gameObject, 2.0f);
                        GameObject rewardInstance = Instantiate(reward,enemyDeadPos.transform.position,Quaternion.identity);
                        // Why many clones ????
                        // Why isn't the position of reward the place where an enemy died ??
                        break;
                    case EnemyType.Log:
                        anim.SetBool("isWalk", false);
                        anim.SetBool("isAttack", false);
                        xp = 30;
                        Destroy(gameObject, 3.0f);
                        break;
                    case EnemyType.Mushroom:
                        anim.SetTrigger("doDie");

                        xp = 50;
                        Destroy(gameObject, 3.0f);
                        break;
                    default:
                        break;
                }
               
                playerState.curentXp += xp;             
                
            }
        }
    }

}
