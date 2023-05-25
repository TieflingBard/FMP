using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject menuInterface;
    [SerializeField] GameObject optionsMenu;
    public static bool isPaused;

    private void Start()
    {
        menuInterface.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else if (!isPaused)
            {
                PauseGame();
            }
            
        }
        if (isPaused)
        {
            Cursor.visible = true;
        }
        else if (!isPaused)
        {
            Cursor.visible = false;
        }
    }

    public void PauseGame()
    {
        menuInterface.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    public void ResumeGame()
    {
        menuInterface.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        optionsMenu.SetActive(false);
    }

    public void QuitToDesktop()
    {
        Application.Quit();
        
    }
    public void QuitToMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        TimerHold.instance.destroyThis();
        SceneManager.LoadScene("MainMenu");  
    }


    public void Options()
    {
        menuInterface.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void BackButton()
    {
        menuInterface.SetActive(true);
        optionsMenu.SetActive(false);
    }




}



