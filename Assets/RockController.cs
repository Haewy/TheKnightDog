using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    [SerializeField] private GameObject rollingRock;
    [SerializeField] private Transform[] generatingPoints;
    //[SerializeField] private float time;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("OnGenerate", 2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnGenerate()
    {
        int random = Random.Range(0, 3);
        Instantiate(rollingRock, generatingPoints[random].position, generatingPoints[random].rotation);
    }

}
