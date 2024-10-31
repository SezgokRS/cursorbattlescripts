using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScene : MonoBehaviour
{

    public void Retry()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1.0f;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1.0f;
    }

}
