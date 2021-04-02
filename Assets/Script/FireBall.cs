using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public int damage;
    CharacterStats player;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Boss")
        {
            //player.GetDamage(damage);
            Destroy(gameObject);
        }
        //Destroy(gameObject,1f);
    }

}
