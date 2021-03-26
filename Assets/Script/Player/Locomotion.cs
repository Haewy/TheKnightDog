using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Locomotion : MonoBehaviour
{
    [Header("Character Movement Settings")]
    [Range(100.0f, 250.0f)] [SerializeField] float speed = 200.0f;



    [SerializeField] CharacterStats player;
    //CharacterController controller;
    Vector2 dir = new Vector2();
    Rigidbody rigid;
    Vector3 charpos = new Vector3();
    //Character Animation settings
    Animator anim;
    //bool isInAction = false;
    bool isIdle = false;
    bool isActive = false;
    bool isWalk = false;
    bool run = false;
    bool isRun = false;
    bool attack = false;
    public bool isAttack = false;
    bool defence = false;
    bool isDefence = false;
    bool isDead = false;
    bool isBlockWalk = false;
    bool roll = false;
   bool isRoll = false;
   public  bool pause = false;
   public bool isPause ;
    //bool isDamage = false;
    [Range(1.0f, 50.0f)] [SerializeField]float rollSpeed = 1.0f;


    private void Awake()
    {
        rigid = GetComponentInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
        isPause = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        run = context.ReadValueAsButton();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        attack = context.ReadValueAsButton();
    }
    public void OnDefence(InputAction.CallbackContext context)
    {
        defence = context.ReadValueAsButton();
    }
    public void OnRoll(InputAction.CallbackContext context)
    {
        roll = context.ReadValueAsButton();
    }
    public void InPause(InputAction.CallbackContext context)
    {
        pause = context.ReadValueAsButton();
       
    }

   
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Jump"))
        //{
        //    anim.SetTrigger("roll");
        //}
    }

    //Player Takedamage trigger
    //private void CharGetHit()
    //{
    //    isDamage = (player.isDamage == true) ? true : false;

    //} w

    private void IsInvoke()
    {
        
        if (pause==true)
        {
          isPause= !isPause;
        }
    }
    private void CharRoll()
    {
      isRoll = (roll == true) ? true : false;
        roll = false;
      
    }
    //Player Death trigger
    private void CharDeath()
    {
       // isDead = (player.isDead == true) ? true : false;
    }
    // Player Defence Trigger
    private void CharDefence()
    {
        if (defence == true)
        {
            isRun = false;
            isDefence = true;

        }
        else
        {
            isDefence = false;
        }
    }

    private void CharRun()
    {
        // Set Character Running Speed
        if (run == true)
        {
            speed = 400.0f;
            isDefence = false;
            isWalk = false;
            isAttack = false;

        }
        else
        {
            speed = 200.0f;
        }
    }
    // Player Attack Trigger 
    private void CharAttack()
    {

        isAttack = attack == true ? true : false;

    }
    private void CharMovement()
    {
        
            //Character move in horzontolly 
            Vector2 pos = new Vector2();
          
            pos += (dir.normalized * speed) * Time.fixedDeltaTime;


            //Exchang Vector2 InputAction --> pos to a new Vector3 --> charpos
            charpos.x = pos.x;
            charpos.z = pos.y;

            //Character Movement 
            rigid.velocity = charpos;
            if (dir.x != 0.0f || dir.y != 0.0f)
            {
                /* Reference 1.
                /* Character Rotation           
                */
                transform.rotation = Quaternion.LookRotation(rigid.velocity, Vector3.up);
            }

        



        /* Character basic movement prototype with a capsule
        /* 
        /*controller = GetComponent<CharacterController>();
        /*[Range(100.0f,1000.0f)][Tooltip("Character Rotation has be test")][SerializeField] float rotationSpeed;
        /* Vector3 curLocation = transform.position;
        /* Vector3 newLocation = new Vector3(curLocation.x, 0, curLocation.y);
        /* Get 2 vector add together to get a new vector, this vection will represent the charactor rotation
        /* Vector3 charRotation = curLocation + newLocation;
        /* transform.LookAt(-charpos);
        /* transform.LookAt(charRotation * rotationSpeed * Time.deltaTime);
        /* controller.Move(charpos);
        */
    }

    //Set Character Animation Walk,Run,Attack, Block and Death  
    void SetAnimation()
    {
        isIdle = (dir.x == 0.0f && dir.y == 0.0f) ? true : false;
        anim.SetBool("idle", isIdle);
        isWalk = (dir.x != 0.0f || dir.y != 0.0f) ? true : false;
        anim.SetBool("walk", isWalk);

        isRun = (run && isDefence == false) ? true : false;
        anim.SetBool("run", isRun);


        
            if (isAttack == true && isRun == false)
            {
                isDefence = false;
            // isWalk = false;
            isIdle = false;
               anim.SetTrigger("attack");
            
            }
            anim.SetBool("defence", isDefence);
        
        

        if (isDead == true)
        {
            anim.SetTrigger("death");
        }
        isBlockWalk = (isWalk == true && isDefence == true) ? true : false;
        anim.SetBool("blockwalk", isBlockWalk);

        if (isRoll == true)
        {
            rigid.velocity = rigid.velocity * rollSpeed; // test

            anim.SetTrigger("roll");
            isRoll = false;
            isWalk = false;
           

        }
        //if (isDamage==true)
        //{
        //    anim.SetTrigger("takedamage");

        //}        
    }

    private void FixedUpdate()
    {
        CharMovement();
        CharAttack();
        CharDefence();
        CharRoll();
        CharRun();
        CharDeath();
        IsInvoke();
        SetAnimation();

    }


}
