using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Oyundaki ipucularý sayýsal olarak tutulmasý için...
    public static int totalInfo = 7;
    public static int collectedInfo = 0;
    // Oyundaki skorun sayýsal olarak tutulmasý için...
    public static int levelScore = 0;
    public static int necessaryScore = 100;
    // Tamamlanan level sayýsýnýn tutulmasý için...
    public static int completedLevel = 0;
    // Test için...
    public static bool isFailed;

}
