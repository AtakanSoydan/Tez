using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;
    public static DataPersistenceManager instance { get; private set; }
    private List<IDataPersistence> dataPersistenceObjects;

    private void Awake()
    {
        if (instance != null) 
        {
            Debug.LogError("Found more than one Data Persistence Manager in scene");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataPersistenceObjects = FindAllPersistencesObjects();
        LoadGame();
    }


    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // TO-DO Load any saved data from a file using the data handler
        if(this.gameData == null)
        {
            Debug.Log("No data was found! Initializing data to defults");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

       // Debug.Log("Loaded info count: " + gameData.collectedInfo);
    }
    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

      //  Debug.Log("Saved info count: " + gameData.collectedInfo);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
    private List<IDataPersistence> FindAllPersistencesObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
