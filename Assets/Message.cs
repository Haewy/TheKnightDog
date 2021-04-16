using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    public GameObject message;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<BoxCollider>();
        message.SetActive(false);

    }
    public void OnTriggerEnter(Collider other)
    {
        message.SetActive(true);
    }
    public void OnTriggerExit(Collider other)
    {
        message.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
