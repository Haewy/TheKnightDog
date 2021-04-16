using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepCounter : MonoBehaviour
{
    //private int counter = 2;
    //[SerializeField] private List<GameObject> creeps;
    //[SerializeField] int camps1;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }
   public void  CounterCreeps(int counter, List<GameObject> creeps,bool isEmpty)
    {
        //isEmpty = false;
        counter = creeps.Count-1;
        for (int i = 0; i < creeps.Count; i++)
        {
            if (creeps[i] == null)
            {
                creeps.RemoveRange(i, 1);

                
                //Debug.Log(counter);

            }

        }
        if (creeps.Count == 0)
        {
            isEmpty = true;
            //Debug.Log(isEmpty);
        }

    }
}
