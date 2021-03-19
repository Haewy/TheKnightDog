using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;
    public bool inventoryOn;
    public GameObject inventoryPanel;
    private int allSlots;
    //private bool busySlot;
    private GameObject[] slots;
    public GameObject slotHolder;
    //private CharacterStats player;
    public bool isActive = false;//
    public int potionNumber = 0;
    public Text[] texts;
    public Button[] buttons;
    private GameObject myCharacter;
    public CharacterStats player;
    public ParticleSystem healing;
    //Singleton
    private void Awake()
    {
        if (inventory==null)
        {
            inventory = this;
        }
        else
        {
            Destroy(this);
        }
    }
    //
    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<CharacterStats>();
        //allSlots = slotHolder.transform.childCount;
        //slots = new GameObject[allSlots];
        //texts = new Text[allSlots];
        //for (int i = 0; i < allSlots; i++)
        //{
        //    slots[i] = slotHolder.transform.GetChild(i).gameObject;
        //    texts[i] = slots[i].transform.GetChild(1).GetComponent<Text>();
        //    slots[i].SetActive(false);
        //}
        //inventoryPanel.SetActive(false);
        //inventoryOn = false;
        myCharacter = GetComponent<GameObject>();
        allSlots = slotHolder.transform.childCount;
        slots = new GameObject[allSlots];
        texts = new Text[allSlots];
        buttons = new Button[allSlots];
        for (int i = 0; i < allSlots; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
            texts[i] = slots[i].transform.GetChild(0).GetComponent<Text>();
            buttons[i] = slots[i].transform.GetChild(1).GetComponent<Button>();
            //buttons[i] = slots[i].GetComponent<Button>();
            slots[i].SetActive(false);
        }
        slots[0].SetActive(true);
        inventoryPanel.SetActive(false);
        inventoryOn = false;
        potionNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryOn)
        {
            inventoryPanel.SetActive(true);
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        inventoryOn = !inventoryOn;
    }
    public void ActivateSlot1()
    {
        int index = 1;    
        slots[index].SetActive(true);
    }
    public void ActivateSlot2()
    {
        int index = 2;
        if (!isActive)
        {
            slots[index].SetActive(true);
            isActive = true;
            potionNumber++;
            texts[index].text = " " + potionNumber.ToString("D2");
        }
        else
        {
            potionNumber++;
            texts[index].text = " " + potionNumber.ToString("D2");

        }
        //if (potionNumber==0)
        //{
        //    slots[index].SetActive(false);//
        //}
    }
    public void RecoverHp()
    {
        Debug.Log("RECOVER HP DONE by 20");
        //recover Hp
        player.curentHp += 20;

        Potion myPotion = this.gameObject.transform.GetChild(4).GetComponent<Potion>();
        myPotion.PlayPotion();
        //myCharacter.transform.FindGameObjectWithTag("Potion");
        //this.gameObject.FindGameObjectWithTag("Potion");
        //Potion myPotion = GameObject.FindGameObjectsWithTag("Potion");
    }
    public void LessOneMayTurnOff()
    {
        int index = 2;
        potionNumber--;
        texts[index].text = " " + potionNumber.ToString("D2");
        if (potionNumber==0)
        {
            slots[index].SetActive(false);//
            isActive = false;
        }
    }
}
