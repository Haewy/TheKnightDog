using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockController : MonoBehaviour
{
    [SerializeField] private GameObject rollingRock;
    [SerializeField] private Transform[] generatingPoints;
    [SerializeField] public GameObject[] invisibleWalls;
    [SerializeField] private GameObject[] exits;
    [SerializeField] private CharacterStats playerState;

    InvisibleWall wall;
    ExitTheWall exitTheWall;
    PointerArrow arrow;

    public Image warning;
    public Text warningTxt;
    public bool isEntered;
    private int invisiblenumber;

    // For Generating Rocks
    private int rng;
    private float rngTime = 0.5f;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        isEntered = false;
        warning.enabled = false;
        warningTxt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEntered)
        {
            currentTime += Time.deltaTime;
            RNG(invisiblenumber);     
        }
    }
    public void OpenTheWall(InvisibleWall.WallNumber number) //, int randomnumber
    {
        isEntered = true;
        OnWarning();
        invisibleWalls[(int)number].SetActive(false);
        Debug.Log("The Opend Wall: " + number + " Index of the Wall: " + (int)number);
        invisiblenumber = (int)number;
    }
    public void RNG(int number)
    {
        if ((int)number==0)
        {
            int random_01 = Random.Range(6, 9);
            Debug.Log("Random Numbers: " + random_01);
            rng = random_01;
           
        }
        else if ((int)number == 1)
        {
            int random_01 = Random.Range(3, 6);
            Debug.Log("Random Numbers: " + random_01);
            rng = random_01;
        }
        else if ((int)number == 2)
        {
            int random_01 = Random.Range(0, 3);
            Debug.Log("Random Numbers: " + random_01);
            rng = random_01;
        }
        OnGenerate(rng);

        
    }

    public void ExitTheWall(ExitTheWall.ExitWallNumber number)
    {
        isEntered = false;
        exits[(int)number].SetActive(false);
        OffWarning();
        Debug.Log("===== Stop Throwing Rocks =====");
        Debug.Log("The Exit Wall: " + number + " Index of the Wall: " + (int)number);

    }
    public void OnGenerate(int randomPos) //int random
    {       
        if (rngTime < currentTime)
        {
            currentTime = 0;
            GameObject rock = Instantiate(rollingRock, generatingPoints[randomPos].position, generatingPoints[randomPos].rotation);
        }     
    }

    public void OnWarning()
    {
        warning.enabled = true;
        warningTxt.enabled = true;

    }
    public void OffWarning()
    {
        warning.enabled = false;
        warningTxt.enabled = false;

    }
}
