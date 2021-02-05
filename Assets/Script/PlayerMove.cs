using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Player
    public int hp;
    public int xp;

    // To move player
    private float hAxis; // moving horizontal
    private float vAxis; // moving vertical
    private float speed = 8.0f; // moving speed

    // To damage enemies
    public int damage = 10;

    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // To move direction
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        OnMove();

    }
    void OnMove()
    {
        Vector3 moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed * Time.deltaTime;
        // To make the player to turn direction
        transform.LookAt(transform.position + moveVec); 
    }

}
