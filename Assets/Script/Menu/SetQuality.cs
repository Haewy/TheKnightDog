using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class SetQuality : MonoBehaviour
{
    //enum option { Low = 0, Medium = 1, High = 2 }
    private Dropdown dropdown;
    float g;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        g = QualitySettings.GetQualityLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetGFX(int i)
    {
        int index = (int)Mathf.Floor(g);

        if (i == 0)
        {
            QualitySettings.SetQualityLevel(i, true);
            Debug.Log("Low");

        }

        if (i == 1)
        {
            QualitySettings.SetQualityLevel(i, true);
            Debug.Log("mediem");

        }
        if (i == 2)
        {
            QualitySettings.SetQualityLevel(i, true);
            Debug.Log("High");

        }
        if (i == 3)
        {
            QualitySettings.SetQualityLevel(i, true);
            Debug.Log("Ultra");

        }


    }
}
