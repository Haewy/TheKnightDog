using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class border : MonoBehaviour
{
    [SerializeField] public GameObject aWarming;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("You cannot go further");

            if (aWarming.GetComponentInChildren<Text>().text == "Be Alert")
                aWarming.GetComponentInChildren<Text>().text = "You cannot go further";
            aWarming.SetActive(true);
            aWarming.GetComponentInChildren<Text>().fontSize = 14;
            Invoke("MakeItDissappear", 2.2f);
        }
    }
    // Start is called before the first frame update
    void MakeItDissappear()
    {
        aWarming.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
