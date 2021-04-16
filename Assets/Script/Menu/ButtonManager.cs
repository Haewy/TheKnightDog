using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{


    public void Quit()//-including quit for Unity. Chris-
    {
        Debug.Log("Quit!!!!!!!!");
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//exit the playmode in the editor
#else
        Application.Quit();
#endif
        Application.Quit();


    }
}
