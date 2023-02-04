using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game")]
    public float winTime;
    public float loseTime;
    public int rangeMin, rangeMax;
    [Header("UI")]
    public TextMeshProUGUI winText;
    public TextMeshProUGUI rangeText;
    public Slider loseSlider;
    bool begin = false;

    int targetsOutOfRange;
    // Start is called before the first frame update
    void Start()
    {
        loseSlider.value = 1;
        winInterval = winTime;
        winText.text = Mathf.CeilToInt(winInterval).ToString();
        rangeText.text = "Range: " + rangeMin.ToString() + " -- " + rangeMax.ToString();
    }

    public void StartGame()
    {
        begin = true;
        Debug.Log("S");
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Number")) {
            obj.GetComponent<NumberEntity>().StartGame();
        }
    }

    // Update is called once per frame
    float winInterval;
    public bool test = false;
    void Update()
    {
        if(test)    {
            StartGame();
            test = false;
        }
        if(begin) {
            if (targetsOutOfRange == 0) {
                winInterval = Mathf.Max(0, winInterval - Time.deltaTime);
                winText.text = Mathf.CeilToInt(winInterval).ToString();
                if (winInterval <= 0) {
                    Debug.Log("You win!");
                }
            } else {
                loseSlider.value = Mathf.Max(0, loseSlider.value - (Time.deltaTime / loseTime));
                if (loseSlider.value <= 0) {
                    Debug.Log("You lose!");
                }
            }
        }
    }

    public void OnNumberStart(int number) {
        if (number < rangeMin || number > rangeMax) {
            targetsOutOfRange++;
        }
    }

    public void OnNumberChanged(int from, int to) {
        // Did it just left range?
        if ((from >= rangeMin && from <= rangeMax) && (to < rangeMin || to > rangeMax)) {
            targetsOutOfRange++;
        // Got back in range?
        } else if ((from < rangeMin || from > rangeMax) && (to >= rangeMin && to <= rangeMax)) {
            targetsOutOfRange--;
        }
    }
}
