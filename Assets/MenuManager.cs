using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField]GameObject pauseMenu;
    bool menuActive;
    private void Awake()
    {
       
        pauseMenu.SetActive(false);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            menuActive = false;
        }
        else
        {
            menuActive = true;
        }
        if (Input.GetKeyDown("escape"))
        {
            pauseMenu.SetActive(true);
           

        }

        BackGame();
    }

    public void BackGame()
    {
        if (menuActive==true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void GameContinue()
    {
        pauseMenu.SetActive(false);
    }


}
