using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingRock : MonoBehaviour
{
    public CharacterStats playerState;
    private float speed = 3f;

    Rigidbody rig;

    public void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

        rig.velocity = Vector3.right * speed;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            //Debug.Log("Collision with a player");
            Destroy(gameObject,0.5f);
            //layerState.GetDamage(10);
        }

    }

}
