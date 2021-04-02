using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicActEnemies : MonoBehaviour
{
    public Transform myRight;
    public Transform myLeft;
    public GameObject enemyRight;
    public GameObject enemyLeft;
    public GameObject aWarming;
    // Start is called before the first frame update
    void Start()
    {
        enemyLeft.SetActive(false);
        enemyRight.SetActive(false);
        aWarming.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            aWarming.SetActive(true);
            enemyLeft.SetActive(true);
            enemyRight.SetActive(true);
            enemyLeft.transform.position = myLeft.position;
            enemyRight.transform.position = myRight.position;
            Invoke("MakeDissappearWarming", 2f);
        }
    }
    public void MakeDissappearWarming()
    {
        aWarming.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
