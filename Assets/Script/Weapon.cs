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
    public int weaponDamage = 10;
    //public Inventory inventory;
    public bool onWeapon = false;
    public BoxCollider damageCol;
    private void Awake()
    {
        damageCol = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)//to get the weapon, collide with it then...?
    {
        if (other.gameObject.tag == "Player")
        {
            damageCol.isTrigger = false;
            //attach weapon
            weaponAudioGet.Play();
            //Debug.Log("Get the sword");
            Inventory inventory = other.GetComponent<Inventory>();
            inventory.ActivateSlot1();
            onWeapon = true;

        }

        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            //enemy.hp -= weaponDamage;
        }
    }
    public void turnOnOff()
    {
        if (onWeapon)
        {
            this.gameObject.SetActive(false);
            onWeapon = false;
        }
        else
        {
            this.gameObject.SetActive(true);
            onWeapon = true;
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
