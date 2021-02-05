using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private int hp;
    private int xp = 50; // When the player kills an enemy the player gets xp
    public Transform target;

    Rigidbody rigid;
    CapsuleCollider collider;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        rigid = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.position);
    }

    // Get attack from the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // cache PlayerMove's script
            PlayerMove player = other.GetComponent<PlayerMove>();
            // Get damage Enemy's hp by the player's attack power
            hp -= player.damage;
            // When Enemy reaches 0 point of hp, Enemy destories
            if (hp<=0)
            {
                // Increase the player's xp
                player.xp += xp;
                Destroy(gameObject);
            }
        }
    }
}
