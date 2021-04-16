using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemies : MonoBehaviour
{
    [SerializeField] private bool EnemyPhase;
    [SerializeField] public GameObject[] enemy;
    [SerializeField] public Transform aPlace;
    [SerializeField] public Transform aPlayer;
    [SerializeField] private Collider wallCollider;
    [SerializeField] public GameObject aWarming;
    [SerializeField] public GameObject rewardDiamond;
    //[SerializeField] public Transform   patrol;
    //[SerializeField] public Transform[] patrolpoints;

    // Start is called before the first frame update
    void Start()
    {
        //int points = patrol.GetChildCount();
        EnemyPhase = false;
        aWarming.SetActive(false);
        wallCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyPhase)
        {
            wallCollider.enabled = false;
            //Time.deltaTime;
            EnemyPhase = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //aWarming.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            aPlayer = other.GetComponent<Transform>();
            aWarming.SetActive(true);
            foreach (GameObject anEnemy in enemy)
            {
                Instantiate(anEnemy, aPlace.position, aPlace.rotation);
                Debug.Log("el");

                //anEnemy.GetComponent<Enemy>().enemyType = Burrow;
                anEnemy.GetComponent<Enemy>().target = aPlayer;
                anEnemy.GetComponent<Enemy>().playerState = other.GetComponent<CharacterStats>();
                anEnemy.GetComponent<Enemy>().reward = rewardDiamond;
                anEnemy.GetComponent<Enemy>().enabled = true;
                //PatrolState patrol = anEnemy.GetComponent<PatrolState>();
                
                //patrol.enabled = true;
                //patrol.patrolpoints[0] = aPlace;
                //patrol.patrolpoints[1] = aPlayer;
            }
            EnemyPhase = true;
            Invoke("ActivateCounter", 2);
            Debug.Log("exitwall");
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    public void ActivateCounter()
    {
        Debug.Log("destroywall");
        Destroy(this);
        aWarming.SetActive(false);
        //EnemyPhase = true;
    }

}
