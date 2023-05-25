using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject mainMenu;


    public void startGame()
    {
        SceneManager.LoadScene("Level1");
    }

   public void exitGame()
    {
        Application.Quit();
    }

    public void backButton()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        
    }

    public void optionsButton()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

}
