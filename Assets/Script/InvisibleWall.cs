using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    public RockController rockController;

    public enum WallNumber { First, Second, Third };
    public WallNumber wallNum;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Weapon")
        {
            Debug.Log("====== The player entered the wall ======");

            switch (wallNum)
            {
                case WallNumber.First:
                    break;
                case WallNumber.Second:
                    break;
                case WallNumber.Third:
                    break;
                default:
                    break;
            }
            rockController.OpenTheWall(wallNum); 

        }
        
    }

}
