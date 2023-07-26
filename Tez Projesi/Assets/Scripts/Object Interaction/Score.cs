using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour, IDataPersistence
{
    [SerializeField] private TMP_Text infoScoreText;
    [SerializeField] private GameObject progressBarGreen;
    [SerializeField] private GameObject testButtonActivation;

    [SerializeField] private string tagName;
    [SerializeField] private string objectID;
    [ContextMenu("Generate Object ID")]
    private void GenerateObjectID()
    {
        objectID = Guid.NewGuid().ToString();
    }

    private bool takenInfo = false;
    private void OnTriggerEnter(Collider other)
    {
        //If game object detected Player tag, boolen value return true...
        if (other.gameObject.CompareTag("Player"))
        {
            takenInfo = true;
        }
    }

    private void Start()
    {
        // Define and showing loaded data...
        if(tagName == "")
        {
            gameObject.tag = "Ground";
        }
        gameObject.tag = tagName;
        //UI sprites and texts loading on start...
        infoScoreText.text = GameData.collectedInfo.ToString();
        if (GameData.collectedInfo >= 4)
        {
            testButtonActivation.SetActive(true);
        }
        for (int i = 0; i < GameData.collectedInfo; i++)
        {
            progressBarGreen.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if (takenInfo && Input.GetKeyDown(KeyCode.F) && gameObject.CompareTag("Ground") && GameData.collectedInfo < 7)
        {
            //Updating GameData class objects...
            GameData.collectedInfo++;
            GameData.levelScore += 100;
            //Show on UI our datas...
            infoScoreText.text = GameData.collectedInfo.ToString();
            progressBarGreen.transform.GetChild(GameData.collectedInfo - 1).gameObject.SetActive(true);
            //Change layer of gameObject.
            tagName = "Collected";
            gameObject.tag = tagName;
            
            if (GameData.collectedInfo >= 4)
            {
                testButtonActivation.SetActive(true);
            }

            if (GameData.collectedInfo == 7)
            {
                GameData.levelScore += 100;
            }
        }
        else
        {
            Debug.Log("Toplanan tüm info: " + GameData.collectedInfo);
            Debug.Log("Level Score on Exploration Chapter");
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            takenInfo = false;
        }
    }

    public void LoadData(GameData gameData)
    {
        GameData.collectedInfo = gameData.collectedInfo2;
        GameData.levelScore = gameData.levelScore2;
        gameData.collectedInfos.TryGetValue(objectID, out tagName);
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.collectedInfo2  = GameData.collectedInfo;
        gameData.levelScore2 = GameData.levelScore;

        if (gameData.collectedInfos.ContainsKey(objectID))
        {
            gameData.collectedInfos.Remove(objectID);
        }
        gameData.collectedInfos.Add(objectID, tagName);
    }
}
