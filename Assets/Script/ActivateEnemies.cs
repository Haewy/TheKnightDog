using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemies : MonoBehaviour
{
    private bool EnemyPhase;
    public GameObject[] enemy;
    public Transform aPlace;
    public Transform aPl;
    private Collider wallCollider;
    public GameObject aWarming;
    // Start is called before the first frame update
    void Start()
    {
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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            aPl = other.GetComponent<Transform>();
            aWarming.SetActive(true);
            foreach (GameObject anEnemy in enemy)
            {
                Instantiate(anEnemy, aPlace.position, aPlace.rotation);
                Debug.Log("el");
                anEnemy.GetComponent<Enemy>().enabled = true;
                anEnemy.GetComponent<Enemy>().target = aPl;
                anEnemy.GetComponent<Enemy>().playerState = other.GetComponent<CharacterStats>();
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
        //EnemyPhase = true;
    }

}
