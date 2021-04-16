using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public ParticleSystem effectMana;
    public AudioSource manaAudioGet;   //not sure if it is an audio source or audio clip?
    CharacterStats player;
    public void CollectMana()
    {  
        Transform potionShader = this.transform.Find("Potion_Generic");
        Transform ballShader = this.transform.Find("Sphere");
        potionShader.GetComponent<MeshRenderer>().enabled = false;
        ballShader.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        manaAudioGet = GetComponent<AudioSource>();
        effectMana = GetComponent<ParticleSystem>();
        effectMana.Pause();
    }
    public void OnTriggerEnter(Collider other)//to get the weapon, collide with it then...?
    {
        if (other.gameObject.tag == "Player")
        {
            manaAudioGet.Play();
            //cache the player (player = other)
            player = other.GetComponent<CharacterStats>();
            Inventory inventory = other.GetComponent<Inventory>();

            CollectMana();
            this.transform.SetParent(other.transform);
            inventory.ActivateSlot3();
            this.transform.GetComponent<Collider>().enabled = false;
        }
    }
    public void PlayMana(int mana)
    {
        effectMana.Play();
        //if (mana == 0)
        //{
        //    Invoke("Leave", 2);
        //}

    }
    //public void Leave()
    //{
    //    this.transform.parent = null;
    //    Destroy(this);
    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
