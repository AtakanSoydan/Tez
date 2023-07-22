using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class GameData
{
    // Oyundaki ipucular� say�sal olarak tutulmas� i�in...
    public static int totalInfo = 7;
    public static int collectedInfo;
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
    // Objelerin etiketlerinin tutuldu�u yer..
    public string objectTag;
    // Collected data 'tag'leri i�in bir dictionary olu�turuyoruz..
    public Dictionary<string, bool> collectedInfos;
    

    public GameData() 
    {
        collectedInfo2 = 0;
        levelScore2 = 0;
        playerPosition = Vector3.zero;
        objectTag = "Ground";
        collectedInfos = new Dictionary<string, bool>();
    }
}
