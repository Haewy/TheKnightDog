using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardCup : MonoBehaviour
{
    private AudioSource rewardAudio;

    // Start is called before the first frame update
    void Start()
    {
        rewardAudio = GetComponent<AudioSource>();
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            rewardAudio.Play();
            Invoke("OnReward", 0.2f);
        }     
    }
    public void OnReward()
    {
        PlayerPrefs.Save();
        AsyncOperation async = SceneManager.LoadSceneAsync(3);//this line ends the game
        Destroy(gameObject);  
    }
        
}
