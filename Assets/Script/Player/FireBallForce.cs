using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallForce : MonoBehaviour
{
    Rigidbody rig = null;
    [SerializeField] float speed;
    GameObject bossEnemy;
    EnemyStatus bossHP;
    public bool onDamage=false;



    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        speed = Mathf.Lerp(200f, 500f, 1f);
        bossEnemy = GameObject.FindGameObjectWithTag("Boss");
        bossHP = bossEnemy.GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.AddForce(transform.forward * speed * Time.deltaTime*-1f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.tag == "Boss")
            {
                onDamage = true;
                bossHP.hp -= 10;
            }
            Destroy(gameObject);

        }

    }

}
