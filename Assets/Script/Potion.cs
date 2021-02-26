using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;//in order to use a sound 

public class Potion : MonoBehaviour
{//variables from the potion only.
    public AudioSource potionAudioGet;   //not sure if it is an audio source or audio clip?
    public AudioClip potionSFX;
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

    }
    private void OnTriggerEnter(Collider other)//to get the weapon, collide with it then...?
    {
        if (other.gameObject.tag == "Player")
        {
            potionAudioGet.Play();
            //potionAudioGet.PlayOneShot(potionSFX);

            Debug.Log("Is it increasing the HP!?");

            //cache the player (player = other)
            CharacterStats player = other.GetComponent<CharacterStats>();
            
            //recover Hp
            player.curentHp += potionHP;
            //gObject.SetActive(false);

        }
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }
}
