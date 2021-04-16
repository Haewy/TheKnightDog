using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camps2Counter : CreepCounter
{
    [SerializeField] private int counter;
   
    [SerializeField] private List<GameObject> creeps;
    [SerializeField] public bool camp2IsEmpty = false;

    [SerializeField] Rabbit mission;

    // Start is called before the first frame update
    void Start()
    {

        //num = counter + 1;
    }

    private void FixedUpdate()
    {
        CounterCreeps(counter, creeps, camp2IsEmpty);
        if (creeps.Count == 0)
        {
            camp2IsEmpty = true;

        }
        mission.camp2Empty = camp2IsEmpty;
        Debug.Log(camp2IsEmpty);
    }
}
