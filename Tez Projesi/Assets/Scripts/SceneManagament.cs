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
        NextLevel();
    }

    private void NextLevel()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            _compLevel++;
            Debug.Log("Level Completed Count: " + _compLevel);
            SceneManager.LoadScene(_compLevel);
        }
    }
    public void RestartLevel()
    {
        Debug.Log("Level Completed Count: " + _compLevel);
        SceneManager.LoadScene(_compLevel);
        Time.timeScale = 1.0f;
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
}
