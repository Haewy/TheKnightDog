
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectalMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rig;
    [SerializeField] float speed;
    [SerializeField] GameObject player;
    [SerializeField] GameObject fireball;
    [SerializeField] ParticleSystem Particle;
    Locomotion spell;
    CharacterStats mana;
    void Start()
    {
        mana = player.GetComponent<CharacterStats>();
        spell = player.GetComponent<Locomotion>();
        //rig = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (spell.isSpell == true)
        {
            RangeAttack();
            
        }

    }

    public void RangeAttack()
    {
        ParticleSystem inParticle = Instantiate(Particle);
        inParticle.transform.position = fireball.transform.position;

        inParticle.transform.rotation = Quaternion.LookRotation(player.transform.forward * -1f);
        ////fireball.transform.position - player.transform.position
        //inParticle.GetComponent<Rigidbody>().AddForce(inParticle.transform.forward * speed * Time.deltaTime);

        //rig.AddForce(inParticle.transform.position.x * speed, 0, 0);

        //Destroy(inParticle, 0.1f);
        player.GetComponent<CharacterStats>().ManaTake();
    }
}
