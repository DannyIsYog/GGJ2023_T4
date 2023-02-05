using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour
{
    public GameObject mathMagician;

    public GameObject gameLogo;
    public GameObject mathMagicianFried;

    public GameObject gameLogoFried;

    public float timeToChange = 5f;

    public float timeToChangeFried = 0.1f;

    private float currentTime = 0f;

    private void Start()
    {
        Invoke("ChangeToMathMagicianFried", timeToChange);
    }

    private void ChangeToMathMagician()
    {
        Debug.Log("Change to Math Magician");
        mathMagicianFried.SetActive(false);
        gameLogoFried.SetActive(false);
        mathMagician.SetActive(true);
        gameLogo.SetActive(true);
        Invoke("ChangeToMathMagicianFried", timeToChange);
    }

    private void ChangeToMathMagicianFried()
    {
        Debug.Log("Change to Math Magician Fried");
        mathMagician.SetActive(false);
        gameLogo.SetActive(false);
        mathMagicianFried.SetActive(true);
        gameLogoFried.SetActive(true);
        Invoke("ChangeToMathMagician", timeToChangeFried);
    }

}
