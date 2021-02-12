using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;//in order to use a sound 

public class Potion : MonoBehaviour
{//variables from the potion only.
    [SerializeField] private AudioSource potionAudioGet;   //not sure if it is an audio source or audio clip?
    [SerializeField] private AudioSource potionAudioAttack;//not sure if it is an audio source or audio clip?
    [SerializeField] private int potionHP;// 
    private GameObject gObject;

 //variables to call cache out from other scripts.
    
    private void OnTriggerEnter(Collider other)//to get the weapon, collide with it then...?
    {
        if (other.gameObject.tag == "Player")
        {
            //cache the player (player = other)
            PlayerMove player = other.GetComponent<PlayerMove>();
            
            //recover Hp
            player.hp += potionHP;

            //play audio clip
            //potionAudioGet.Play();


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
