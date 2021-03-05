using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
//using UnityEngine.Rabbits;

public class Rabbit : MonoBehaviour
{
    public bool onConversation = false;
    public GameObject textBlock;
    public GameObject pressButton;
    public GameObject missionBlock;

    // Start is called before the first frame update

    private void Start()
    {
        onConversation = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (onConversation)
        {
            pressButton.SetActive(true);
        }
        if (onConversation && (Input.GetKeyDown(KeyCode.E)|| Mouse.current.middleButton.isPressed))
        {
            pressButton.SetActive(false);
            missionBlock.SetActive(true);
            textBlock.SetActive(true);
            //GetComponentsInChildren<Canvas>(true);
        }
        else if (!onConversation)
        {
            pressButton.SetActive(false);
            textBlock.SetActive(false);
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
}
