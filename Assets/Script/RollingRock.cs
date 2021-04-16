using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingRock : MonoBehaviour
{
    public CharacterStats player;
    RockController rockController;
    private float speed = 20f;
    private int damage = 5;

    Rigidbody rigL;

    public void Awake()
    {
        rigL = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigL.velocity = Vector3.left * speed;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Collision with a player");
            Destroy(gameObject, 0.5f);
            player = collision.collider.GetComponent<CharacterStats>();
            player.curentHp -= damage;
        }
        else
        {
            Destroy(gameObject, 7f);
        }

    }

}
