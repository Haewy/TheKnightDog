using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour, ICtritterBehavior<float>
{
    // Player HP and CurentHP
    [Header("Character Stats Settings")]
    [SerializeField]public float maxHP= 100.0f;
    [SerializeField]public float curentHp;
    
    // Player MP and CurentMP
    [SerializeField]public float maxMP = 100.0f;
    [SerializeField]public float curentmp;

    // Player XP and CurentXP
    [SerializeField] public int maxXP = 100;
    [SerializeField] public int curentXp= 0;

    //Player Level 
    [SerializeField] public int curentlevel = 1;
    [SerializeField] public int maxLvl=3;
    
    private bool isLvlUp = false;
    private bool isLvlMax = false;

    //Player State //-including for show State. Chris-
    [SerializeField] public Button characterState;
    public bool isDead { get; private set; }
    public bool isDamage { get; set; }

    [SerializeField]public GameObject inputManager;
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
    void Update()//-comment on the DamageTake() and introduce GetDamage(float). Chris-
    {
        // Test Method for Player take damage and death animation  
        //DamageTake(curentHp,isDamage);        
        //ManaTake();
        //Check Player Level up 
        CheckXP();
        CheckLvl();
        Death(curentHp,isDead);
    }
    public void GetDamage(float damage)//-including for hit. Chris-
    {
        curentHp -= damage;
    }
    public void DamageTake(float hp, bool hit)
    {
        if (Input.GetKeyDown("1"))
        {
            hp -= 20.0f;
            hit = true;
        }
        curentHp = hp;
        isDamage = hit;
    }
    public void ManaTake()//-modification for consume mana after using power. Chris-
    {
        //if (Input.GetKeyDown("2"))
        //{
            curentmp -= 20;

        //}
    }

    public void Death(float hp, bool death)
    {
        curentHp = hp;
        if (curentHp>60)
        {
            characterState.image.color = Color.white;
        }
        else if (curentHp <= 60 && curentHp > 40)
        {
            characterState.image.color = Color.yellow;
        }
        if (curentHp <= 40)
        {
            characterState.image.color = Color.red;
        }
        if (hp <= 0)
        {
            death = true;

            //Destroy(inputManager);
            AsyncOperation async = SceneManager.LoadSceneAsync(4);//-including GameOver Scene. Chris-
        }
        isDead = death;
        
    }
    public void CheckXP()
    {
        if (isLvlMax==false)
        {
            if (Input.GetKeyDown("3"))
            {
                if (curentXp != maxXP)
                {
                    curentXp += 10;
                }
                else
                {
                    curentXp = 0;
                    isLvlUp = true;
                }
            }

            //Debug.Log("in Check XP  -------> " + " CurentXP===== " + curentXp);
        }
      
    }
    public void CheckLvl()
    {
        if (isLvlUp==true)
        {
            isLvlUp = false;
            maxXP += 100;
            curentlevel += 1;
            if(curentlevel == maxLvl)
            {
                curentXp = maxXP;
                isLvlMax = true;
            }
            //Debug.Log("in Check Level  -------> " + " curentlevel===== " + curentXp);
            //Debug.Log("in Check Level  -------> " + " maxXP===== " + curentXp);

        }
    }
}
