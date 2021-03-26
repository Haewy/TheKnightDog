using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallForce : MonoBehaviour
{
    Rigidbody rig = null;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        speed = Mathf.Lerp(200f, 500f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        rig.AddForce(transform.forward * speed * Time.deltaTime*-1f);
    }
}
