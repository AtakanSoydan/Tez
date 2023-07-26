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
        if (other.gameObject.CompareTag("Player"))
        {
            takenInfo = true;
        }
    }

    private void Start()
    {
        // Define loaded data...
        if(tagName == "")
        {
            gameObject.tag = "Ground";
        }
        gameObject.tag = tagName;
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
            //Debug.Log("collected info arttýrýlmadan önce: " + GameData.collectedInfo);
            GameData.collectedInfo++;
            GameData.levelScore += 100;
            //Debug.Log("Local Score: " + GameData.levelScore);
            infoScoreText.text = GameData.collectedInfo.ToString();
            progressBarGreen.transform.GetChild(GameData.collectedInfo - 1).gameObject.SetActive(true);
            //Debug.Log("collected info arttýrýldýktan sonra: " + GameData.collectedInfo);
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
            //Debug.Log("Toplanan tüm info: " + GameData.collectedInfo);
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
