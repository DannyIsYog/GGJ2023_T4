using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstScene;
    public void Play()
    {
        SceneManager.LoadScene(firstScene);
    }

    public void HowToPlay()
    {

    }

    public void Credits()
    {

    }
}
