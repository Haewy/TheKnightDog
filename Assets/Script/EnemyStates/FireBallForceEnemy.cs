using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallForceEnemy : MonoBehaviour
{
    Rigidbody rig = null;
    [SerializeField] float speed;
    GameObject player;
    CharacterStats characterStats;



    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        speed = Mathf.Lerp(200f, 500f, 1f);
        player = GameObject.FindGameObjectWithTag("Player");
        characterStats = player.GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.AddForce(transform.forward * speed * Time.deltaTime * -1f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //characterStats.curentHp -= 10;

        }
        Destroy(gameObject);
    
    }
}
