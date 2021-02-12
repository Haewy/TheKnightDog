using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryOn : MonoBehaviour
{
    private PlayerMove myPlayer;
    void Start()
    {
        myPlayer = GetComponent<PlayerMove>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")//or Potion
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
                Debug.Log("Hit!");
                myPlayer.myCarryON = other.gameObject;
            //}
        }
        if (other.gameObject.tag == "Potion")//or Potion
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            Debug.Log("Hit2!");
            myPlayer.myCarryON = other.gameObject;
            //}
        }
    }

}
