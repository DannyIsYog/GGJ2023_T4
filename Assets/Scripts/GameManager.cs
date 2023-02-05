using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public GameObject rootUI;
    public GameObject winUI;
    public GameObject loseUI;
    public string nextScene;
    public AudioSource intro, loop;
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

    public void NextLevel()
    {
        if(over)
            if(won)
                SceneManager.LoadScene(nextScene);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        begin = true;
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Number")) {
            obj.GetComponent<NumberEntity>().StartGame();
        }
    }

    // Update is called once per frame
    float winInterval;
    public bool test = false;
    bool over = false;
    bool won = false;
    void Update()
    {
        if(!intro.isPlaying && !loop.isPlaying)
            loop.Play();
        if(test)    {
            StartGame();
            test = false;
        }
        if(begin && !over) {
            if (targetsOutOfRange == 0) {
                winInterval = Mathf.Max(0, winInterval - Time.deltaTime);
                winText.text = Mathf.CeilToInt(winInterval).ToString();
                if (winInterval <= 0) {
                    over = true;
                    won = true;
                    rootUI.SetActive(true);
                    winUI.SetActive(true);
                }
            } else {
                loseSlider.value = Mathf.Max(0, loseSlider.value - (Time.deltaTime / loseTime));
                if (loseSlider.value <= 0) {
                    over = true;
                    won = false;
                    rootUI.SetActive(true);
                    loseUI.SetActive(true);
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
