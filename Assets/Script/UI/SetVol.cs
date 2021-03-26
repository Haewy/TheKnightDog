using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Dropdown))]
public class SetVol : MonoBehaviour
{
    [SerializeField] private AudioMixer audioM;
    [SerializeField] private string nameParam;
    private Slider slider;
    private Dropdown dropdown;
   
    enum option { Low = 0, Medium =1, High  =2}
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        float v = PlayerPrefs.GetFloat(nameParam, 0);
        slider.value = v;
        dropdown = GetComponent<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetVolume(float vol)
    {
        audioM.SetFloat(nameParam, vol);
        slider.value= vol;
        PlayerPrefs.SetFloat(nameParam, vol);
    }
    
    public void SetGFX(int i)
    {
        switch (i)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
   
}
