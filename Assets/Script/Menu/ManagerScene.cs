using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScene : MonoBehaviour
{
    [SerializeField] private Selectable[] btnMenu;
    [SerializeField] private GameObject[] panels;
    // Start is called before the first frame update
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.01f);
        PannelToggle(0);
    }
    
    public void PannelToggle(int pos)
    {
        Input.ResetInputAxes();
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(pos == i);
            //panels[i - 1].gameObject.SetActive(false);
            if (pos==i)
            {
                btnMenu[i].Select();
            }
        }
    }
  // Menu Enable And Disable 

    public void SavePrefs()
    {
        PlayerPrefs.Save(); 
    }
}
