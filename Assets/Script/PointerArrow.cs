using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointerArrow : MonoBehaviour
{
    public Transform[] targets;
    private Vector3 targetPos;
    private Vector3 dir;

    private float hideDistance = 11f;
    //private int howManyDiamond;
    private int arrowTriggerNum;
    private bool isDead;

    private int whichcamp;

    public void Awake()
    {
        SetChildrenActive(false);
        isDead = false;
        whichcamp = 0;
    }


    // Update is called once per frame
    void Update()
    {
        dir = targets[whichcamp].position - transform.position;


        if (dir.magnitude < hideDistance) // Pointer Arrow inactivates when the player is nearby Boss 
        {
            SetChildrenActive(false);
            Debug.Log("You are in the Camp");
        }
        else if (arrowTriggerNum == 1) // Pointer Arrow activates when the player pass the Second exitwall 
        {
            SetChildrenActive(true);
            targetPos = targets[0].transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            whichcamp = 0;
            Debug.Log("Target number index:" + whichcamp);


        }
        else if (arrowTriggerNum == 2) // Third Exitwall
        {
            SetChildrenActive(true);
            targetPos = targets[1].transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            whichcamp = 1;
            Debug.Log("Target number index:" + whichcamp);
        }
        else if (arrowTriggerNum == 3) // Fourth Exitwall
        {
            SetChildrenActive(true);
            targetPos = targets[2].transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            whichcamp = 2;
            Debug.Log("Target number index:" + whichcamp);
        }
        else if (arrowTriggerNum == 4) // Fifth Exitwall where Boss enemy is 
        {
            SetChildrenActive(true);
            targetPos = targets[2].transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            whichcamp = 2;
            Debug.Log("Target number index:" + whichcamp);
        }

    }

    public void TurnOnArrow(ExitTheWall.ExitWallNumber number)
    {
        arrowTriggerNum = (int)number;
        
    }

    public void GetBossStatus(bool value)
    {
        isDead = value;
        Debug.Log("Boss is dead?: " + isDead);
        if (isDead)
        {
            this.enabled = false;
        }
    }

    //https://www.youtube.com/watch?v=U1SdjGUFSAI
    public void SetChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
