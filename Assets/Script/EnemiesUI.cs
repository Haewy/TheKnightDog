using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Enemy enemies;
    // To fix healthBar to look forward
    // https://blog.naver.com/skwls01/222101972069
    Transform cam = null; 
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.forward = cam.forward;
        healthBar.fillAmount = (float)enemies.currentHp / (float)enemies.maxHp;
        
    }
}
