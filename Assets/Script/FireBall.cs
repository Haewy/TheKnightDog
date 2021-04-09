using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float damage;
    CharacterStats player;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground" 
            || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            if (collision.gameObject.tag == "Player")
            {
                damage = 5;
                player.GetDamage(damage);
            }
           
        }
        Destroy(gameObject,3f);
    }

}
