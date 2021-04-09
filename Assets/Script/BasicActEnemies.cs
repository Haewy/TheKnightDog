using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BasicActEnemies : MonoBehaviour
{
    [SerializeField] public Transform myRight;
    [SerializeField] public Transform myLeft;
    [SerializeField] public GameObject enemyRight;
    [SerializeField] public GameObject enemyLeft;
    [SerializeField] public GameObject aWarming;
    [SerializeField] private bool firstTime;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("GetTheAnimator", 0.1f);
        enemyLeft.GetComponent<NavMeshAgent>().enabled = false;
        enemyRight.GetComponent<NavMeshAgent>().enabled = false;
        aWarming.SetActive(false);
        firstTime = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && firstTime)
        {

            if (aWarming.GetComponentInChildren<Text>().text == "You cannot go further")
                aWarming.GetComponentInChildren<Text>().text = "Be Alert";
            aWarming.SetActive(true);
            enemyLeft.SetActive(true);
            enemyRight.SetActive(true);
            enemyLeft.transform.position = myLeft.position;
            enemyRight.transform.position = myRight.position;
            enemyLeft.GetComponent<NavMeshAgent>().enabled = true;
            enemyRight.GetComponent<NavMeshAgent>().enabled = true;
            firstTime = false;
            Invoke("MakeDissappearWarming", 2f);
            Invoke("TurnTRUEFirstTimeAgain", 80f);
        }
    }
    public void GetTheAnimator()
    {
        //
    }

    public void MakeDissappearWarming()
    {
        aWarming.SetActive(false);
    }
    public void TurnTRUEFirstTimeAgain()
    {
        firstTime = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
