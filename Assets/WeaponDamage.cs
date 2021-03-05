using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{

    Collider damageColider;
    GameObject player;
   
    private void Awake()
    {
        damageColider = GetComponent<Collider>();
        damageColider.isTrigger = false;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //AttackCheck();
    }
    
    void AttackCheck()
    {
        if (player.GetComponent<Locomotion>().isAttack == true)
        {
            damageColider.isTrigger = true;


        }
        else
        {
            damageColider.isTrigger = false;
        }
    }
}
