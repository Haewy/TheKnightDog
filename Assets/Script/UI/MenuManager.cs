using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField]GameObject pauseMenu;
    GameObject player;
    Locomotion loco;
    bool menuActive;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        loco = player.GetComponent<Locomotion>();
        pauseMenu.SetActive(false);

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseMenuControl();
        //if (!pauseMenu.activeInHierarchy)
        //{
        //    menuActive = false;
        //}
        //else
        //{
        //    menuActive = true;
        //}
        //if (Input.GetKeyDown("escape"))
        //{
        //    pauseMenu.SetActive(true);
           

        //}

        //BackGame();
    }

    public void PauseMenuControl()
    {
        if (loco.isPause)
        {
            
            pauseMenu.SetActive(true);
           

        }
        else
        {
            
            pauseMenu.SetActive(false);
            

        }
        if (!pauseMenu.activeInHierarchy)
        {
            
            menuActive = false;
            

        }
        else
        {
           
            menuActive = true;
            
        }

        //else
        //{
        //    pauseMenu.SetActive(false);
        //}
       
     
    
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
        loco.isPause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 0;
    }


}
