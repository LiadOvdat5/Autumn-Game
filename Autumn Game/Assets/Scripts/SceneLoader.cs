using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Core Game")
        {
            SoundManager.PlaySound("backgroundSound");
        }
    }

}
