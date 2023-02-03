using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game")]
    public float winTime;
    public float loseTime;
    public int rangeMin, rangeMax;
    [Header("UI")]
    public Slider winSlider;
    public Slider loseSlider;

    int targetsOutOfRange;
    // Start is called before the first frame update
    void Start()
    {
        winSlider.value = 0;
        loseSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetsOutOfRange == 0) {
            winSlider.value += Time.deltaTime / winTime;
            if (winSlider.value >= 1) {
                Debug.Log("You win!");
            }
        } else {
            loseSlider.value += Time.deltaTime / loseTime;
            if (loseSlider.value >= 1) {
                Debug.Log("You lose!");
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
        Debug.Log("From: " + from + ", To: " + to);
        Debug.Log("Targets out of range: " + targetsOutOfRange);
    }
}
