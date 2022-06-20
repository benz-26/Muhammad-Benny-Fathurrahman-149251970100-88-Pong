using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuController : MonoBehaviour
{


    //ke playgame
    public void PlyaGame()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Created By Muhammad Benny Fathurrahman-149251970100-88");
    }

    //ke credit
    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


    public void Quit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
