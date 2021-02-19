using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;//in order to use a sound 

public class Weapon : MonoBehaviour
{
    [SerializeField] private AudioSource weaponAudioGet;   //not sure if it is an audio source or audio clip?
    //[SerializeField] private AudioSource weaponAudioAttack;//
    public Vector3 myPickUpWeapon;
    public Vector3 myPickUpRotation;
    private void OnTriggerEnter(Collider other)//to get the weapon, collide with it then...?
    {
        if (other.gameObject.tag == "Player")
        {
            //weaponAudioGet.
            //            
            //attach weapon
            weaponAudioGet.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        weaponAudioGet = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
