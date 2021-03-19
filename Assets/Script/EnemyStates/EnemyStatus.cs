using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] public int hp;
   //[SerializeField] int dmg;
    bool isDead;
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

    private void Awake()
    {
        hp = 100;
        //dmg = 20;
        isDead = false;
        anim = GetComponent<Animator>();
        rend = GetComponentInChildren<Renderer>();
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
            anim.SetBool("death", isDead);
            Destroy(this.enemy);
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

}
