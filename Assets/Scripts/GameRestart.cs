using CodeMonkey;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("BodyPart"))
        {
            GameDataManager.Instance.TotalPointAdd();
            SceneManager.LoadScene(1);
        }
    }
}
