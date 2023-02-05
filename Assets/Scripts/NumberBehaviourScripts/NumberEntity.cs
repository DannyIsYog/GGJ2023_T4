using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NumberEntity : MonoBehaviour
{
    // TO DO: APPLY MULTIPLE SPRITES TOGETHER/REPLACE SPRITE ARRAY WITH TEXT 
    // TO DO: CHANGE SPRITE OR FONT IN ORDER TO DISTINGUISH + OR - 
    // TO DO: CHANGE DIVIDE FUNCTION WITH NEW NUMBER
    const int MAX_VAL = 10000;

    // Movement parameters
    [Header("Movement")]
    public float movementSpeed = 200.0f;
    public float newNumberOffset = 1.5f;

    // Number Control
    [Header("Number Control")]
    public float timeToIncDec = 10.0f;
    public float playerSqrChangeCooldown = 5.0f;
    public float playerPowerChangeCooldown = 5.0f;
    public bool randomizeIncDec = true;
    public bool isIncrementing = false;
    public UnityEvent<int> numberStart;
    public UnityEvent<int, int> numberChanged;
    public GameObject preGlow;
    public GameObject glow;

    // Text
    [Header("Text")]
    public TextMeshProUGUI text;

    // Auxiliary variables - Movement
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public Vector2 lastVelocity;
    private Vector2 reflectDirection;

    // Auxiliary variables - Number
    public float numberValue;
    private float timeSqr;
    private float timePower;
    private bool isChanging = false;
    private SpriteRenderer spriteRenderer;
    bool begin = false;

    void Awake()
    {
        // Connect rigidbody
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        ConfigureInitialNumber();

        // Get random initial direction
        moveDirection = Random.insideUnitCircle.normalized;
        numberStart.Invoke((int)numberValue);

        // Initialize numbers with no cooldown
        timePower = playerPowerChangeCooldown;
        timeSqr = playerSqrChangeCooldown;

        SetEnabled(false);
    }

    void SetEnabled(bool enabled)
    {
        Debug.Log("SetEnabled: " + enabled);
        transform.GetChild(0).gameObject.SetActive(enabled);
        GetComponent<SpriteRenderer>().enabled = enabled;
        GetComponent<Collider2D>().enabled = enabled;
    }

    void FixedUpdate()
    {
        if(begin) {
            Movement();
            IncrementDecrement();
            PerfectSquareHeadsUp();

            // Keep track of time
            timePower += Time.deltaTime;
            timeSqr += Time.deltaTime;
        }
    }

    private void SetValue(float value)
    {
        numberChanged.Invoke((int)numberValue, (int)value);
        if (value > MAX_VAL)
            value = MAX_VAL;
        else if (value < -MAX_VAL)
            value = -MAX_VAL;
        numberValue = (int)value;
        text.text = numberValue.ToString();
    }

    private void ConfigureInitialNumber()
    {
        // Choose random number and assign sprites
        SetValue(numberValue);

        ConfigureTimeChange();
    }

    public void BeginGame()
    {
        begin = true;
        SetEnabled(true);
    }

    private void ConfigureTimeChange()
    {
        if(randomizeIncDec)
        {
            // Roll 50/50 for the number to be incrementing or decrementing
            if (Random.Range(0, 2) == 1)
            {
                isIncrementing = true;
            }
        }

        // Visual hints 
        if (!isIncrementing)
            spriteRenderer.color = new Color(0.8f, 0.0f, 0.0f);
        else
            spriteRenderer.color = new Color(0.0f, 0.8f, 0.0f);

    }

    private void Movement()
    {
        // Movement - manipulation of rigidbody
        rb.velocity = moveDirection * movementSpeed * Time.deltaTime;
        lastVelocity = rb.velocity;
    }

    public void StartGame()
    {
        begin = true;
        SetEnabled(true);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If shot by a squared projectile...
        if (collision.gameObject.tag == "PowerProjectile" && timePower >= playerPowerChangeCooldown)
        {
            float val = numberValue > MAX_VAL ? MAX_VAL : Mathf.Pow(numberValue, 2);
            val = val > MAX_VAL ? MAX_VAL : val;
            SetValue(val);
            Debug.Log("Collided with a power projectile");

            // Variable for cooldown
            timePower = 0;
        }
        // If collided with squared root...
        else if (collision.gameObject.tag == "SquaredRoot" && timeSqr >= playerSqrChangeCooldown)
        {
            Debug.Log("Collided with a squared root");
            if(numberValue < 0)
            {
                Debug.Log("MATH ERROR");
                Application.Quit();
                return;
            }

            float value = Mathf.Sqrt(numberValue);
            SetValue(value);

            // Square root of negative number is MATH ERROR (Memes)

            // If it is not a whole number...
            if (value % 1 != 0)
            {
                // Gets largest smaller integer
                float smallerInteger = Mathf.Floor(value);

                // Originate another number (1st decimal digit)
                float decimals = value - smallerInteger;
                decimals = decimals * 10;
                Divide(Mathf.Floor(decimals));

                // Update this number with largest smaller integer
                SetValue(smallerInteger);
                ConfigureTimeChange();
            }

            // Variable for cooldown
            timeSqr = 0;
        }
        // If collided with wall or other number...
        else
        {
            // Gets reflection direction based on current trajectory
            reflectDirection = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            moveDirection = reflectDirection.normalized;
        }
    }

    private void IncrementDecrement()
    {
        // After a given time, increment/decrement number
        StartCoroutine(ChangeNumberAfterTime(timeToIncDec));
    }

    IEnumerator ChangeNumberAfterTime(float time)
    {
        if (isChanging)
            yield break;
        else
            isChanging = true;

        // Cooldown for changing number
        yield return new WaitForSecondsRealtime(time);

        // Change number value and update sprite
        if (isIncrementing)
            SetValue(numberValue + 1);
        else
            SetValue(numberValue - 1);


        isChanging = false;
    }

    private void Divide(float newNumber)
    {

        // Copy this number
        GameObject decimalNumber = GameObject.Instantiate(gameObject);
        NumberEntity decimalNumberEntity = decimalNumber.GetComponent<NumberEntity>();

        // Assign new number value, update sprite
        decimalNumberEntity.SetValue(newNumber);
        decimalNumberEntity.ConfigureTimeChange();

        // Offset the new number slightly so we don't have instant collision
        decimalNumber.GetComponent<Rigidbody2D>().position = rb.position - moveDirection * newNumberOffset;
        decimalNumberEntity.moveDirection = -1 * moveDirection;
        decimalNumberEntity.timeSqr = 0;

    }

    private void PerfectSquareHeadsUp()
    {
        // BEWARE: AT CURRENT TIME (16:14) THIS DOESN'T WORK SINCE SPRITE 0 CORRESPONDS TO 1

        // If this number is perfect square...
        glow.SetActive(Mathf.Sqrt(numberValue) % 1 == 0);
        // If next number is perfect square... (increasing)
        preGlow.SetActive((Mathf.Sqrt(numberValue + 1) % 1 == 0 && isIncrementing) ||
            (Mathf.Sqrt(numberValue - 1) % 1 == 0 && !isIncrementing));
    }


}
