using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Test_Number : MonoBehaviour
{
    TextMeshProUGUI text;
    float timestamp;
    public UnityEvent<int> numberStart;
    public UnityEvent<int, int> numberChanged;
    public int number = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        numberStart.Invoke(number);
        text.text = number.ToString();
        timestamp = Time.time;
    }

    // Update is called once per frame
    bool flip = false;
    void Update()
    {
        // Every second, increment or decrement value
        if(timestamp + 1 < Time.time) {
            timestamp = Time.time;
            int oldNumber = number;
            number += flip ? 1 : -1;
            numberChanged.Invoke(oldNumber, number);
            text.text = number.ToString();
            flip = !flip;
        }
    }
}
