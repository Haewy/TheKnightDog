using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float damage;
    CharacterStats playerStats;
    GameObject player;   

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<CharacterStats>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") // || collision.gameObject.tag == "Ground"  || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Enemy"
        {
            //player = collision.collider.GetComponent<CharacterStats>();

            damage = 5;
            playerStats.curentHp -= damage;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 3f);
        }
        
    }

}
