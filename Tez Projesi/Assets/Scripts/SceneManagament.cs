using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagament : MonoBehaviour
{
    private int _compLevel = GameData.completedLevel;
    [SerializeField] private GameObject _object;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        NextLevel();
        RestartLevel();
        //MainMenu();
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
    private void RestartLevel()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Level Completed Count: " + _compLevel);
            SceneManager.LoadScene(_compLevel);
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 0.0f;
        _object.SetActive(true);
    }
}
