using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI nameText;
    public TMP_InputField inputField;
    string nametext;
    int score;
    void Start()
    {
        if (instance == null)
        { instance = this;}
        else Destroy(instance);

        if (inputField != null)
        {
            inputField.onEndEdit.AddListener(OnEndEdit);
        }

    }

    public void OnEndEdit(string text)
    {
        nametext = inputField.text;
        GameDataManager.Instance.SetName(nametext);
        //Debug.Log(nametext);

    }
  
    public void OnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void SetScore(int point)
    {
        scoreText.text = "Score :" + point;
    }
 
   
            
    

}
