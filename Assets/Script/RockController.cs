using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    [SerializeField] private GameObject rollingRock;
    [SerializeField] private Transform[] generatingPoints;
    [SerializeField] private BoxCollider invisibleWall;

    private bool isEntered;

    // Start is called before the first frame update
    void Start()
    {
        //invisibleWall = GetComponent<BoxCollider>();
        invisibleWall = GetComponentInChildren<BoxCollider>();
        InvokeRepeating("OnGenerate", 2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnGenerate()
    {
        int random = Random.Range(0, 3);
        Instantiate(rollingRock, generatingPoints[random].position, generatingPoints[random].rotation);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            invisibleWall.enabled = false;
            //collider.enabled = false; // can go through the wall 
            InvokeRepeating("OnGenerate", 2f, 3f);
        }
    }

}
