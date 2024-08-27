using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System.IO;




public class HighScoreTable : MonoBehaviour
{
    private const int MaxHighScores = 5;
    private const string fileName = "highscores.json";
    public HighScoreData highScoreData = new HighScoreData();
    public GameObject entryPrefab;
    public Transform entryContainer;

    void Start()
    {
        //Debug.Log($"Persistent Data Path: {Application.persistentDataPath}");
        LoadHighScores();
        PrintHighScores();
        VeiwUITable();
    }

 
    public void CompareTotalScore(string playerName, int totalScore)
    {
        LoadHighScores();
        HighScoreEntry newEntry = new HighScoreEntry { playerName = playerName, score = totalScore };
        highScoreData.highScores.Add(newEntry);

        //sort
        highScoreData.highScores.Sort((x, y) => y.score.CompareTo(x.score));

        

        if (highScoreData.highScores.Count > MaxHighScores)
        {
            highScoreData.highScores.RemoveRange(MaxHighScores, highScoreData.highScores.Count - MaxHighScores);
        }
        SaveHighScores();
        PrintHighScores();
        //VeiwUITable();


    }
    private void LoadHighScores()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        //Debug.Log($"Loading high scores from: {path}"); // Debug log for path
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            highScoreData = JsonConvert.DeserializeObject<HighScoreData>(json);
        }
        else
        {
            Debug.Log("no File");
        }
    }
    private void SaveHighScores()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
       //Debug.Log($"Saving high scores to: {path}");
        string json = JsonConvert.SerializeObject(highScoreData, Formatting.Indented);
        File.WriteAllText(path, json);
      
    }
    public void VeiwUITable()
    {
        LoadHighScores();
      
        for (int i = 0; i < highScoreData.highScores.Count; i++)
        {
            
            var instantiatedEntry = Instantiate(entryPrefab, entryContainer);
            var entryChildren = instantiatedEntry.GetComponentsInChildren<TextMeshProUGUI>();
            entryChildren[0].text = $"{i + 1}"; // Rank
            entryChildren[1].text = $"{highScoreData.highScores[i].playerName}"; // Player Name
            entryChildren[2].text = $"{highScoreData.highScores[i].score}"; // Score
        }
       
    }
    void PrintHighScores()
    {
        LoadHighScores();
        for (int i = 0; i < highScoreData.highScores.Count; i++)
        {
            Debug.Log($"HighScore{i + 1}: {highScoreData.highScores[i].playerName} - {highScoreData.highScores[i].score}");
        }
    }

    [System.Serializable]
    public class HighScoreEntry
    {
        public string playerName;
        public int score;
    }

    [System.Serializable]
    public class HighScoreData
    {
        public List<HighScoreEntry> highScores = new List<HighScoreEntry>();
    }
}
