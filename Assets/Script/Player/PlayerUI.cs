using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    [SerializeField]Image playerHealthUI;
    [SerializeField] Image playerMpUI;
    [SerializeField]CharacterStats player;
    
    public float hp=100.0f;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Bind Player health and Mana to the UI 
        playerHealthUI.fillAmount = player.curentHp/100;
        playerMpUI.fillAmount = player.curentmp / 100;

   
    }
}
