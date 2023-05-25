using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;


public class PlayerDeath : MonoBehaviour
{
    public Transform currentRespawnPoint;
    [SerializeField] Transform playerPos;
    public bool playerHasDied = false;
    public static PlayerDeath instance;
    public Scene currentScene;
    public string sceneName;

    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    private void Update()
    {
        if (playerHasDied)
        {
            playerDeath();
        }
    }

    public void playerDeath()
    {
        playerPos.position = currentRespawnPoint.position;
        PlayerController.instance.stopMovement(0.1f);
        TimerHold.instance.deaths += 1;
        if (sceneName == "Level2")
        {
            GlobalLightCheckV2.instance.resetLight();
        }
        else if (sceneName == "Level3")
        {
            TentacleTwo.mantaHasDied = true;
        }
          
       
        playerHasDied = false;
    }

}
