using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class GameData
{
    // Oyundaki ipucularý sayýsal olarak tutulmasý için...
    public static int totalInfo = 7;
    public static int collectedInfo;
    public int collectedInfo2;
    // Oyundaki skorun sayýsal olarak tutulmasý için...
    public static int levelScore = 0;
    public int levelScore2 = 0;
    public static int necessaryScore = 100;
    // Tamamlanan level sayýsýnýn tutulmasý için...
    public static int completedLevel = 0;
    // Test için...
    public static bool isFailed;
    // Karakter konumu
    public Vector3 playerPosition;
    

    public GameData() 
    {
        collectedInfo2 = 0;
        levelScore2 = 0;
        playerPosition = Vector3.zero;
    }
}
