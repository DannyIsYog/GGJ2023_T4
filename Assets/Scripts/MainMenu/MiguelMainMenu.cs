using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiguelMainMenu : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.SetInt("level",1);
    }

    public void LoadGame()
    {
        if(PlayerPrefs.HasKey("level"))
        {
            Debug.Log("loading " + PlayerPrefs.GetInt("level"));
        }
        else
            PlayerPrefs.SetInt("level",1);
    }
}
