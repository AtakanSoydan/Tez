using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class GameData
{
    // Oyundaki ipucular� say�sal olarak tutulmas� i�in...
    public static int totalInfo = 7;
    public static int collectedInfo = 0;
    public int collectedInfo2;
    // Oyundaki skorun say�sal olarak tutulmas� i�in...
    public static int levelScore = 0;
    public int levelScore2 = 0;
    public static int necessaryScore = 100;
    // Tamamlanan level say�s�n�n tutulmas� i�in...
    public static int completedLevel = 0;
    // Test i�in...
    public static bool isFailed;
    // Karakter konumu
    public Vector3 playerPosition;
    // Collected data 'tag'leri i�in bir dictionary olu�turuyoruz..
    public SerializableDictionary<string, string> collectedInfos;
    

    public GameData() 
    {
        collectedInfo2 = 0;
        levelScore2 = 0;
        playerPosition = Vector3.zero;
        collectedInfos = new SerializableDictionary<string, string>();
    }
}
