using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, ICtritterBehavior<float>
{
    [SerializeField]public float maxHP= 100.0f;
    [SerializeField]public float curentHp;
    [SerializeField]public float maxMP = 100.0f;
    [SerializeField] public float curentmp;
    [SerializeField]public float maxXp = 100.0f;
    [SerializeField]public float xp;
    public bool isDead { get; private set; }
    public bool isDamage { get; set; }
    private void Awake()
    {
        curentHp = maxHP;
        curentmp = maxMP;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Test Method for Player take damage and death animation  
        DamageTake(curentHp,isDamage);
        Death(curentHp,isDead);
      

        if (Input.GetKeyDown("1"))
        {
            curentmp -= 10;
           
        }
       

    }

    public void DamageTake(float hp,bool hit )
    {
        
        if (Input.GetKeyDown("space"))
        {
            hp -= 20.0f;
            hit = true;
        }
        curentHp = hp;
        isDamage = hit;
        
      
    }

    public void Death(float hp , bool death)
    {
        curentHp = hp;
        if(hp <= 0)
        {
            death = true;
            
           
        }
        isDead = death;
        
    }
}
