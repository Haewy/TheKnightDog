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
    public bool isActiveMana = false;//
    public int potionNumber = 0;
    public int manaNumber = 0;
    public Text[] texts;
    public Button[] buttons;
    private GameObject myCharacter;
    public CharacterStats player;
    public ParticleSystem healing;
    //Diamond counter
    public int diamondCount;
    public Text diamondCounter;
    public GameObject diamondI;
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
        manaNumber = 0;
        diamondCount = 0;
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
        slots[1].SetActive(true);
    }
    public void ActivateSlot2()
    {
        if (!isActive)
        {
            slots[2].SetActive(true);
            isActive = true;
            potionNumber++;
            texts[2].text = " " + potionNumber.ToString("D2");
        }
        else
        {
            potionNumber++;
            texts[2].text = " " + potionNumber.ToString("D2");

        }
        //if (potionNumber==0)
        //{
        //    slots[index].SetActive(false);//
        //}
    }

    public void ActivateSlot3()
    {
        int index = 3;
        if (!isActiveMana)
        {
            slots[index].SetActive(true);
            isActiveMana = true;
            manaNumber++;
            texts[index].text = " " + manaNumber.ToString("D2");
        }
        else
        {
            manaNumber++;
            texts[index].text = " " + manaNumber.ToString("D2");

        }
    }
    public void RecoverHp()
    {
        Debug.Log("RECOVER HP DONE by 25");
        //recover Hp
        player.curentHp += 25;
        Potion myPotion = this.gameObject.transform.GetChild(4).GetComponent<Potion>();
        foreach (Transform aChild in this.gameObject.transform)
        {
            if (aChild.tag=="Potion")
            {
                myPotion = aChild.GetComponent<Potion>();
                Debug.Log("We got it");
                //we got it
            }
        }

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
    public void RecoverMana()
    {
        Debug.Log("RECOVER Mana  by 25");
        //recover Mana
        player.curentmp += 25;
        Mana myMana = this.gameObject.transform.GetChild(4).GetComponent<Mana>();
        foreach (Transform aChild in this.gameObject.transform)
        {
            if (aChild.tag == "Mana")
            {
                myMana = aChild.GetComponent<Mana>();
                Debug.Log("We got the mana");
                //we got it
            }
        }
        //It may turn off the slot
        int index = 3;
        manaNumber--;
        texts[index].text = " " + manaNumber.ToString("D2");
        if (manaNumber == 0)
        {
            slots[index].SetActive(false);//
            isActiveMana = false;
        }
        myMana.PlayMana(manaNumber);
    }
    public void AddDiamond()
    {
        //add one more diamond
        diamondCount++;
        diamondCounter.text = " " + diamondCount.ToString("D2");
    }
}
