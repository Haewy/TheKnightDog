using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour
{
    [SerializeField] Image bossHealthUI;
    [SerializeField]Camera cam;
    [SerializeField] EnemyStatus boss;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        bossHealthUI.fillAmount = (float)boss.hp / 100f;
        bossHealthUI.transform.rotation = cam.transform.rotation;
    }

}
