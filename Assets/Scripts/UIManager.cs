using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        if(instance == null)
            instance = this;
        else Destroy(instance);
    }

    public void SetScore(int point)
    {
        scoreText.text = "Score :" + point;
    }
   
}
