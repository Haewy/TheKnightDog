using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryOn : MonoBehaviour
{
    //private PlayerMove myPlayer;
    //
    public GameObject myRHand;
    //
    private GameObject myCarryON;
    //
    private Weapon myWeapon;
    //
    private Potion myPotion;
    void Start()
    {
        //myPlayer = GetComponent<PlayerMove>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
                
                Debug.Log("Hit!");
                //Cache the object  
                myCarryON = other.gameObject;
                //Cache the pickup position
                myWeapon = myCarryON.GetComponent<Weapon>();

            //}
        }
        if (other.gameObject.tag == "Potion")
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            Debug.Log("Hit2!");
            myCarryON = other.gameObject;
            myPotion = myCarryON.GetComponent<Potion>();
            //play audio clip
            //myPotion.potionAudioGet.Play();
            //}
        }

    }
    void Update()
    {
        if (myCarryON != null && myCarryON.tag == "Weapon")
        {
            //Set the character as partent and weapon as its children
            //myCarryON.transform.parent = this.transform;
            myCarryON.transform.parent = myRHand.transform;
            //Put the weapong in the Right Hand
            //myCarryON.transform.position = myRHand.position;
            //Put the weapon in the Right Hand right
            //myCarryON.transform.localPosition = myRHand.transform.position;
            myCarryON.transform.localPosition = myWeapon.myPickUpWeapon;
            myCarryON.transform.localEulerAngles = myWeapon.myPickUpRotation; ;
        }
        //
        if (myCarryON != null && myCarryON.tag == "Potion")
        {
            Debug.Log("PLAY THE AUDIO!");
            //Potion sound
            myPotion.potionAudioGet.Play();
            //Potion disappear
            myCarryON.SetActive(false);
        }
    }
    //Invoke("Disappear", 1);
    //public void Dissapear()
    //{
    //    myCarryON.SetActive(false);
    //}
}
