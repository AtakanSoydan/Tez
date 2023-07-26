using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagament : MonoBehaviour
{
    private int _compLevel = GameData.completedLevel;
    private bool isPaused = false;
    [SerializeField] private GameObject _object;

    void Update()
    {
        MainMenuEsc();
    }

    public void LoadTestScene()
    {
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void NextLevel()
    { 
        _compLevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _compLevel);
        Time.timeScale = 1.0f;
        
    }
    public void RestartLevel()
    {
        ScoreTimer.currentTime = 0f;
        Time.timeScale = 1.0f;
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync(DataPersistenceManager.instance.GetSavedSceneName());
    }

    public void MainMenu()
    {
        isPaused = !isPaused;
        
        if (isPaused)
        {
            Time.timeScale = 0.0f;
            _object.SetActive(true);

        }
        else
        {
            Time.timeScale = 1.0f;
            _object.SetActive(false);
        }        
    }
    private void MainMenuEsc()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0.0f;
                _object.SetActive(true);

            }
            else
            {
                Time.timeScale = 1.0f;
                _object.SetActive(false);
            }
        }
    }

    public void BackToMainScene()
    {
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Main Menu");
    }

}
