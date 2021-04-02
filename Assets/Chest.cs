using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject rewardCup;

    private bool chestIsOpen;

    Animator anim;

    public void Awake()
    {
        anim = GetComponentInChildren<Animator>();   

    }
    // Start is called before the first frame update
    void Start()
    {
        chestIsOpen = false;
        anim.SetBool("isOpen", false);
        rewardCup.SetActive(chestIsOpen);
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Player")
        {
            Debug.Log("Collided with Player!!!!!");
            chestIsOpen = true;           
            anim.SetBool("isOpen", true);
            //OnTada();
            Invoke("OnTada", 1f);
        }
    }
    public void OnTada()
    {
        if (chestIsOpen)
        {
            rewardCup.SetActive(chestIsOpen);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
