using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipIntroScene : MonoBehaviour
{
    private void Update()
    {
        SkipIntro();
    }
    public void SkipIntro()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadScene(nextSceneIndex);
    }
}
