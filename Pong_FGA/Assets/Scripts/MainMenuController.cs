using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuController : MonoBehaviour
{

    public void PlyaGame()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Created By Muhammad Benny Fathurrahman-149251970100-88");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //button author
    public void OpenAuthor()
    {
        Debug.Log("Created By Muhammad Benny Fathurrahman-149251970100-88");
    }
}
