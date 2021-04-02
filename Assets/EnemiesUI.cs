using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Enemy enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)enemies.currentHp / (float)enemies.maxHp;
        
    }
}
