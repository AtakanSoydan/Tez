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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void NextLevel()
    { 
        _compLevel++;
        SceneManager.LoadScene(_compLevel);
        Time.timeScale = 1.0f;
        
    }
    public void RestartLevel()
    {
        ScoreTimer.currentTime = 0f;
        Time.timeScale = 1.0f;
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
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
        GameData.levelScore -= QuizManager.gainedScore;
        SceneManager.LoadScene(0);
    }

}
