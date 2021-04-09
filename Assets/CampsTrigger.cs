using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampsTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camps;
    [SerializeField] private Transform location;
    [SerializeField] private GameObject thisObject;
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(location.transform.position.sqrMagnitude - player.transform.position.sqrMagnitude) <= 500)
        {

            camps.SetActive(true);
            Debug.Log("Create 1");
            Destroy(thisObject);
        }
    }

    //void CreateCamps()
    //{
    //    Instantiate(camps);
    //}
    //private void DestroyThis()
    //{
    //    Destroy(thisObject);
    //}
}
