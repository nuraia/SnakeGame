using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;




public class HighScoreTable : MonoBehaviour
{
    private const int MaxHighScores = 5;
    private List<int> highScores = new List<int>();
    int count = 0;
    bool IsUpdated = false;

    void Start()
    {

        if (!PlayerPrefs.HasKey("HighScore1")) PlayerPrefs.SetInt("HighScore1", 0);
        else if (!PlayerPrefs.HasKey("HighScore2")) PlayerPrefs.SetInt("HighScore2", 0);
        else if (!PlayerPrefs.HasKey("HighScore3")) PlayerPrefs.SetInt("HighScore3", 0);
        else if (!PlayerPrefs.HasKey("HighScore4")) PlayerPrefs.SetInt("HighScore4", 0);
        else if (!PlayerPrefs.HasKey("HighScore5")) PlayerPrefs.SetInt("HighScore5", 0);
        //PrintHighScores();
    }

 
    public void CompareTotalScore(int TotalScore)
    {
        for (int i = 1; i <= MaxHighScores; i++)
        {
            if (PlayerPrefs.GetInt($"HighScore{i}") <= TotalScore)
            {
                int temp = PlayerPrefs.GetInt($"HighScore{i}");
                PlayerPrefs.SetInt($"HighScore{i}", TotalScore);
                TotalScore = temp;
            }
        }

  
        
            PrintHighScores();
        

    }
    void PrintHighScores()
    {
       
        for (int i = 1; i <= MaxHighScores; i++)
        {
            Debug.Log($"HighScore{i}: {PlayerPrefs.GetInt($"HighScore{i}")}");
        }
    }
}
