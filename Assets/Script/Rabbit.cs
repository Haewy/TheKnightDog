using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//BUNNY
using UnityEngine.AI;//for having bunny as a partner


//using UnityEngine.Rabbits;

public class Rabbit : MonoBehaviour
{
    public bool onConversation = false;
    public GameObject textBlock;
    public GameObject pressButton;
    public GameObject missionBlock;

    //Added by Haewon
    public GameObject textFromBunny;

    //BUNNY
    //for having bunny as a partner
    public Rigidbody bunnyRigid;
    public NavMeshAgent bunnyNav;
    public Animator bunnyAnim;
    public Transform playerDog;

    public float distance;
    public bool bunnyPartner;
    public bool bunnyTalk;
    public bool talk;



    // ---------added by Rui-----------------
    // Added 3 text box for show the mission 

    [SerializeField] private List<GameObject> missions;
    [SerializeField] public GameObject camp1;
    [SerializeField] public GameObject camp2;
   
    public bool camp1Empty;
    public bool camp2Empty;

    //---------------------------------------


    // Start is called before the first frame update
    //BUNNY
    private void Awake()
    {
        bunnyRigid = GetComponent<Rigidbody>();
        bunnyNav = GetComponent<NavMeshAgent>();
        bunnyAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        onConversation = false;
        //BUNNY
        bunnyPartner = false;
        bunnyTalk = false;
        bunnyNav.SetDestination(playerDog.position);
        bunnyNav.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (onConversation)
        {
            pressButton.SetActive(true);
        }//BUNNY
        if (onConversation && !bunnyTalk && talk) //(Input.GetKeyDown(KeyCode.E) || Mouse.current.middleButton.isPressed)
        {
            //pressButton.SetActive(false);
            //missionBlock.SetActive(true);
            textBlock.SetActive(true);
            //BUNNY
            bunnyTalk = true;
            bunnyPartner = true;
            //BUNNY
            //bunnyNav.enabled = true;
            //GetComponentsInChildren<Canvas>(true);
        }
        else if (!onConversation)
        {
            //pressButton.SetActive(false);
            textBlock.SetActive(false);
        }
    }
    //BUNNY
    private void FixedUpdate()
    {

        Missiondisplay();

        distance = Vector3.Distance(this.transform.position, playerDog.position);
        if (bunnyPartner)
        {
            bunnyNav.enabled = true;
            bunnyNav.SetDestination(playerDog.position);
            bunnyAnim.SetBool("PlayerMoving", true);

        }
        if (distance < 3.2)
        {
            bunnyAnim.SetBool("PlayerMoving", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onConversation = true;

            Debug.Log("WTF");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onConversation = false;
            Debug.Log("Wccccccccccc");
        }
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
            talk = context.ReadValueAsButton();
    }


    //----------Add by Rui --------------
    // the function is to show the current mission 

    private void Missiondisplay()
    {

        if (camp1Empty == false)
        {
            missions[0].SetActive(true);
            missions[1].SetActive(false);
            missions[2].SetActive(false);

        }
        else
        {
            
            missions[0].SetActive(false);
            missions[1].SetActive(true);
            missions[2].SetActive(false);
        }
        if (camp2Empty == true)
        {
            missions[1].SetActive(false);
            missions[2].SetActive(true);
        }
    }
    //--------------End --------------------
}
