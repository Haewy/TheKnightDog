using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTheWall : MonoBehaviour
{
    public RockController rockController;
    public enum ExitWallNumber { ExitFirst, ExitSecond, ExitThird };
    public ExitWallNumber exitwallNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
                default:
                    break;
            }
            rockController.ExitTheWall(exitwallNum);
            
            
        }
    }
}
