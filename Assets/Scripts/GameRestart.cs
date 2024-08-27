
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    public CameraShake cameraShake;
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("BodyPart"))
        {
            cameraShake.ShakeCamera();
            GameDataManager.Instance.IsMoving = false;
            GameDataManager.Instance.TotalPointAdd();
            StartCoroutine(cameraShaking());

        }
    }

    IEnumerator cameraShaking()
    {
        
        yield return new WaitForSeconds(3);

        cameraShake.StopShake();
        SceneManager.LoadScene(1);
    }
}
