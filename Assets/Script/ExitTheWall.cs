using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTheWall : MonoBehaviour
{
    public RockController rockController;
    public PointerArrow arrow;

    public enum ExitWallNumber { ExitFirst, ExitSecond, ExitThird, ExitFourth, ExitFifth };
    public ExitWallNumber exitwallNum;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Weapon")
        {
            rockController.isEntered = false;
            switch (exitwallNum)
            {
                case ExitWallNumber.ExitFirst:
                    break;
                case ExitWallNumber.ExitSecond:
                    break;
                case ExitWallNumber.ExitThird:
                    break;
                case ExitWallNumber.ExitFourth:
                    break;
                case ExitWallNumber.ExitFifth:
                    break;
                default:
                    break;
            }
            rockController.ExitTheWall(exitwallNum);
            // To know when the player pass the second exit wall 
            arrow.TurnOnArrow(exitwallNum);
            
        }
    }
}
