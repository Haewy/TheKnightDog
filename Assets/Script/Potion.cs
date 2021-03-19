using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;//in order to use a sound 

public class Potion : MonoBehaviour
{//variables from the potion only.
    public AudioSource potionAudioGet;   //not sure if it is an audio source or audio clip?
    public AudioClip potionSFX;
    public ParticleSystem effectHealing;
    CharacterStats player;
    //private bool okToPlay = false;
    public void CollectPotion()
    {
        //potionAudioGet.Play();
        //potionAudioGet.transform.DetachChildren();//parent = null;   
        Transform potionShader = this.transform.Find("Potion_Generic");
        potionShader.GetComponent<MeshRenderer>().enabled = false;
        //Destroy(potionShader);
        //potionAudioGet.Play();
    }

    [SerializeField] private int potionHP;// 
    //GameObject gObject;

    //variables to call cache out from other scripts.
    void Start()
    {
        //gObject = GetComponent<GameObject>();
        potionAudioGet = GetComponent<AudioSource>();
        potionHP = 20;
        //effectHealing = GetComponent<ParticleSystem>();
        effectHealing.Pause();
    }
    public void OnTriggerEnter(Collider other)//to get the weapon, collide with it then...?
    {
        if (other.gameObject.tag == "Player")
        {
            potionAudioGet.Play();
            //potionAudioGet.PlayOneShot(potionSFX);

            Debug.Log("Got the HP!?");

            //cache the player (player = other)
            player = other.GetComponent<CharacterStats>();
            Inventory inventory = other.GetComponent<Inventory>();
            //recover Hp
            //player.curentHp += potionHP; //
            //gObject.SetActive(false);
            this.transform.SetParent(other.transform);
            inventory.ActivateSlot2();

        }
    }
    public void PlayPotion()
    {
        effectHealing.Play();
    }
    // Start is called before the first frame update
    //Debug.Log("Is it increasing the HP!?");

    // Update is called once per frame
    void Update()
    {

    }
}
