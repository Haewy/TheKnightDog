using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //https://flowtree.tistory.com/19?category=378006

    [SerializeField] private enum EnemyType { Burrow, Log, Mushroom };
    [SerializeField] private EnemyType enemyType;
    [SerializeField] public int maxHp;
    [SerializeField] public int currentHp;
    [SerializeField] public int damage = 50;
    [SerializeField] private int xp; // When the player kills an enemy the player gets xp // Burrow: 20, Log: 40, Boss: 100
    [SerializeField] public Transform target;
    [SerializeField] private BoxCollider attackRange; // Work for the enemy keeps repeating attack and stop in a
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform fireBallPos;
    public CharacterStats playerState;
    public Locomotion locomotion;
    public GameObject reward;
    public Transform enemyDeadPos; // For a position where will place a reward 
    private float speedForColor = 1f;

    private float distance;
    //private Transform log;
    private bool isChase;
    private bool isAttack;
    private bool isDamage;
    private bool isDead;

    //LogAxe logAxe;
    Rigidbody rigid;
    NavMeshAgent nav;
    Animator anim;
    Renderer rend; 

    // From Rui's code
    Color startColor = Color.white;
    Color endColor = Color.red; // to change color of enemy when it gets damage

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rend = GetComponentInChildren<Renderer>();

        currentHp = maxHp;

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
    // Prevent the enemy from rotating
    void FreezeVelocity() // From googleit
    {
        if (isChase || isDead || isAttack)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }


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
        //OnChase();
        //FreezeVelocity();   
       if (Mathf.Abs(transform.position.sqrMagnitude - target.transform.position.sqrMagnitude) <850)
        {           
            AttackState();   
        }
    }
    void PartrolState()
    {

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
                break;
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
                anim.SetBool("attack", true);
                playerState.GetDamage(5);
                yield return new WaitForSeconds(0.3f);
                attackRange.enabled = true;
                yield return new WaitForSeconds(0.3f);
                attackRange.enabled = false;
                yield return new WaitForSeconds(0.3f);

                break;

            case EnemyType.Log:
                anim.SetBool("attack", true);
                playerState.GetDamage(5);
                yield return new WaitForSeconds(0.3f);
                attackRange.enabled = true;
                yield return new WaitForSeconds(0.3f);
                rigid.velocity = Vector3.zero;
                attackRange.enabled = false;
                yield return new WaitForSeconds(1f);

                break;
            case EnemyType.Mushroom:
                anim.SetBool("attack", true);;
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
        anim.SetBool("attack", false);
    }

    void OnChase()
    {
        isChase = true;
        isAttack = false;
        anim.SetBool("walk", true);
    }

    IEnumerator OnDamageEffect()
    {
        //currentHp -= damage;
        Debug.Log(currentHp);
        if (isDamage) // && locomotion.isAttack==true 
        {
            currentHp -= damage;
            float lerp = Mathf.PingPong(Time.time, speedForColor) / speedForColor;
            rend.material.color = Color.Lerp(startColor, endColor, lerp);
        }
        yield return new WaitForSeconds(0.5f);
    }

    // Get attack from the player (Damaging)
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Weapon"|| collision.collider.tag == "Spell")  // || collision.collider.tag == "Player"
        {

            StartCoroutine(OnDamageEffect());
            isDamage = true;

            // When Enemy reaches 0 point of hp, Enemy destories
            if (currentHp <= 0)
            {
                // Chasing and Nav AI stop and when the enemy is dead
                isChase = false;
                isAttack = false;
                nav.enabled = false;
                isDamage = false;
                currentHp = 0;
                
                // Increase the player's xp
                switch (enemyType)
                {
                    case EnemyType.Burrow:                        
                        anim.SetTrigger("doDie");
                        xp = 20;
                        Destroy(gameObject, 0.5f); // How can a reward make to appear after Destory
                        isDead = true;

                        break;
                    case EnemyType.Log:
                        anim.SetBool("walk", false);
                        anim.SetBool("attack", false);
                        xp = 30;
                        Destroy(gameObject, 0.5f);
                        isDead = true;
                        break;
                    case EnemyType.Mushroom:
                        anim.SetTrigger("doDie");
                        xp = 50;
                        Destroy(gameObject, 0.5f);
                        isDead = true;

                        break;
                    default:
                        break;
                }
                //isDead = true;
                if (isDead)
                {
                    GameObject rewardInstance = Instantiate(reward, enemyDeadPos.transform.position, Quaternion.identity);
                }

                playerState.curentXp += xp;             
                
            }
        }
    }

}
