using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void startGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
    

}
