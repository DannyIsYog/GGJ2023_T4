using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameName = "BaseScene";
    public void NewGame()
    {
        PlayerPrefs.SetInt("level", 1);
        StartGame();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            Debug.Log("loading " + PlayerPrefs.GetInt("level"));
        }
        else
            PlayerPrefs.SetInt("level", 1);
        StartGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameName);
    }

    public void HowToPlay()
    {

    }

    public void Credits()
    {

    }
}
