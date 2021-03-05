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
    private void Awake()
    {
        hp = 100;
        //dmg = 20;
        isDead = false;
        anim = GetComponent<Animator>();

    }
    private void Start()
    {

    }
    private void Update()
    {
        CheckDead();
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
    private void OnTriggerEnter(Collider other)
    {
        if(weapon!=null)
        {
            other = weapon;
            if (other && player.GetComponent<Locomotion>().isAttack == true)
            {
                hp -= 20;
            }
        }
     
    }

}
