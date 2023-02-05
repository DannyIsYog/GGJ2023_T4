using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour
{
    public Sprite mathMagician;
    public Sprite mathMagicianFried;

    public Image background;

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
        background.sprite = mathMagician;
        Invoke("ChangeToMathMagicianFried", timeToChange);
    }

    private void ChangeToMathMagicianFried()
    {
        Debug.Log("Change to Math Magician Fried");
        background.sprite = mathMagicianFried;
        Invoke("ChangeToMathMagician", timeToChangeFried);
    }

}
