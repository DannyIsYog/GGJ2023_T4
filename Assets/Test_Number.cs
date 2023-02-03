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
    public UnityEvent<int, int> numberChanged;
    public int _number = 0;
    public int number {
        get {
            return _number;
        }
        set {
            numberChanged.Invoke(_number, value);
            _number = value;
            text.text = value.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
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
            number += flip ? 1 : -1;
            Debug.Log("Number changed to " + number);
            flip = !flip;
        }
    }
}
