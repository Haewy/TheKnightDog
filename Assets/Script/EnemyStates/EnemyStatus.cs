using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] public int hp;
   //[SerializeField] int dmg;
   public bool isDead;
    [SerializeField] Collider weapon;
    [SerializeField] GameObject damageColider;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    Animator anim;

    Renderer rend;
    float speed=1f;
    Color startColor = Color.white;
    Color endColor = Color.red;
    bool getHit;
    FireBallForce spellDamage;

    // Added by Haewon
    // For reward Chest 
    [SerializeField] GameObject chest;
    [SerializeField] Transform bossDeadPos;
    // For inactivating Pointer Arrow
    [SerializeField] public PointerArrow arrow;

    private void Awake()
    {
        hp = 100;
        //dmg = 20;
        isDead = false;
        anim = GetComponent<Animator>();
        rend = GetComponentInChildren<Renderer>();
        spellDamage = GetComponent<FireBallForce>();

    }
    private void Start()
    {

    }
    private void Update()
    {
        CheckDead();
        GetHit();
      
    }

    void CheckDead()
    {
        if (hp <= 0)
        {
            isDead = true;
            //anim.SetBool("death", isDead);
            Destroy(this.enemy);
            enemy.SetActive(false);

            //Added by Haewon
            GameObject rewardInstance = Instantiate(chest, bossDeadPos.transform.position, Quaternion.LookRotation(bossDeadPos.forward));
            arrow.GetBossStatus(isDead);



        }
    }
    void GetHit()
    {
        if (getHit == true)
        {
            // Enemy color change when it get hit 
            // Reference 5
            float lerp = Mathf.PingPong(Time.time, speed) / speed;
            rend.material.color = Color.Lerp(startColor, endColor, lerp); 
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(weapon!=null)
        {
            other = weapon;
            if (other && player.GetComponent<Locomotion>().isAttack == true)
            {
                hp -= 20;
                

                getHit = true;
          
               
            }
            else
            {
                getHit = false;
            }
        }
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spell")
        {
            hp -= 20;
        }
    }
}
