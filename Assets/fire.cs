using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public CharacterStats player;
    public float fireTimer = 120;
    public bool burning = false;
    public bool timeout = false;
    // Start is called before the first frame update
    void Start()
    {
        burning = false;
        timeout = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag== "Player")
        //{
        //    player = other.GetComponent<CharacterStats>();
        //    player.GetDamage(1);
        //}
        burning = true;
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player" || timeout)
        { 
            player = other.GetComponent<CharacterStats>();
            player.GetDamage(1);
            timeout = false;
            fireTimer = 125;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        burning = false;
    }




    // Update is called once per frame
    void Update()
    {
        if (burning)
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer==0)
            {
                timeout = true;
            }
        }

    }
}
