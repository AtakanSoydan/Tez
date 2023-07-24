using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPressNewGame()
    {
        DataPersistenceManager.instance.NewGame();

        SceneManager.LoadSceneAsync("1. Bölüm");
    }

    public void OnPressContinueGame()
    {
        SceneManager.LoadSceneAsync("1. Bölüm");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
 
}
