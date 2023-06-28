using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset textAssetData;
    [Serializable]
    public class Player
    {
        public string name;
        public int health;
        public int damage;
        public int defence;
    }

    [Serializable]
    public class PlayerList
    {
        public Player[] player;
    }

    public PlayerList playerList = new PlayerList();

    private void Start()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] {";", "\n" },StringSplitOptions.None);

        int tableSize = data.Length / 4 - 1;
        playerList.player = new Player[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            playerList.player[i] = new Player();
            playerList.player[i].name = data[4 * (i + 1)];
            playerList.player[i].health = int.Parse(data[4 * (i + 1) + 1]);
            playerList.player[i].damage = int.Parse(data[4 * (i + 1) + 2]);
            playerList.player[i].defence = int.Parse(data[4 * (i + 1) + 3]);

        }
    }
}
