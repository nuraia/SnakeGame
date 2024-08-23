using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    public string playerName;
    public int playerScore;
    public int TotalScore = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetName(string nametext)
    {
        playerName = nametext;
    }
    public void SetPlayerData(string name, int score)
    {
        playerName = name;
        playerScore = score;
    }
    public void TotalPointAdd()
    {
        TotalScore = playerScore;
        HighScoreTable highScoreTable = new HighScoreTable();
        highScoreTable.CompareTotalScore(TotalScore);


    }
}
