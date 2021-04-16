using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camps1counter : CreepCounter
{
    [SerializeField]private int counter;
    private int num;
    [SerializeField] private List<GameObject> creeps;
    [SerializeField] public bool camp1IsEmpty = false;

    [SerializeField] Rabbit mission;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //num = counter + 1;
    }

    private void FixedUpdate()
    {
        CounterCreeps(counter,creeps, camp1IsEmpty);
        if (creeps.Count == 0)
        {
            camp1IsEmpty = true;

        }
        mission.camp1Empty = camp1IsEmpty;
        Debug.Log(camp1IsEmpty);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
