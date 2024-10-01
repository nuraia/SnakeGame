using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        GameDataManager.Instance.IsMoving = true;
        SceneManager.LoadScene(0);
    }
}
