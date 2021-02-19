using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;


public class Loading : MonoBehaviour
{
    public AsyncOperation asyn;

    [SerializeField] private Image progressBar;
    [SerializeField] private Text txtPercent;

    [SerializeField] private Text txtLoading;
    [SerializeField] private Text txtDone;


    // Start is called before the first frame update
    void Start()
    {
        // Reset timescale to default 
        Time.timeScale = 1.0f;
        //remove button currently held down
        Input.ResetInputAxes();
        System.GC.Collect();
        Scene currentScene = SceneManager.GetActiveScene();
        asyn = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);
        asyn.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (progressBar)
        {
            progressBar.fillAmount = asyn.progress + 0.1f;
        }
        if (txtPercent)
        {
            txtPercent.text = ((asyn.progress + 0.1f)*100).ToString("f2")+"%";
        }
        if(asyn.progress>=0.89 && SplashScreen.isFinished)
        {
            txtLoading.gameObject.SetActive(false);
            txtDone.gameObject.SetActive(true);

            if (Input.anyKey)
            {
                asyn.allowSceneActivation = true;
               
            }
        }
    }
}
