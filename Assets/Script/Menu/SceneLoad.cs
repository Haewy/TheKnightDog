using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    private AsyncOperation async;
    public void BtnStart()
    {
        if (async == null)
        {
            Scene currScene = SceneManager.GetActiveScene();
            async = SceneManager.LoadSceneAsync(currScene.buildIndex + 1);
            async.allowSceneActivation = true;
        }
    }
    public void BtnStart( int i )
    {
        async = SceneManager.LoadSceneAsync(i);
        async.allowSceneActivation = true;
    }
    public void BtnStart( string s)//-include strings too. Chris-
    {

        async = SceneManager.LoadSceneAsync(s);
        async.allowSceneActivation = true;
    }



}
