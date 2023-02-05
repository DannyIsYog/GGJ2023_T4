using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstScene;

    public string tutorialScene;
    public void Play()
    {
        SceneManager.LoadScene(firstScene);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(tutorialScene);
    }

    public void Credits()
    {

    }
}
