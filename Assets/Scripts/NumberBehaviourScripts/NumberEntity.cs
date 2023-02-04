using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberEntity : MonoBehaviour
{
    // TO DO: APPLY MULTIPLE SPRITES TOGETHER/REPLACE SPRITE ARRAY WITH TEXT 
    // TO DO: CHANGE SPRITE OR FONT IN ORDER TO DISTINGUISH + OR - 
    // TO DO: CHANGE DIVIDE FUNCTION WITH NEW NUMBER

    // Movement parameters
    [Header("Movement")]
    public float movementSpeed = 200.0f;
    public float newNumberOffset = 1.5f;

    // Sprites
    [Header("Sprites")]
    public Sprite[] usableSprites; // TBD
    public bool activateTest = false;

    // Number Control
    [Header("Number Control")]
    public float timeToIncDec = 10.0f;
    public bool randomizeIncDec = true;
    public bool isIncrementing = false;

    // Auxiliary variables - Movement
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public Vector2 lastVelocity;
    private Vector2 reflectDirection;

    // Auxiliary variables - Number
    public float numberValue;
    private bool isChanging = false;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        ConfigureInitialNumber();

        // Connect rigidbody
        rb = GetComponent<Rigidbody2D>();

        // Get random initial direction
        moveDirection = Random.insideUnitCircle.normalized;
    }

    void FixedUpdate()
    {
        Movement();
        IncrementDecrement();
        PerfectSquareHeadsUp();

        if (activateTest) // TBD
            Divide(0.0f);
    }

    private void ConfigureInitialNumber()
    {
        // Choose random number and assign sprites
        numberValue = Random.Range(0, usableSprites.Length); // TBD
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = usableSprites[(int)numberValue];

        ConfigureTimeChange();
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If shot by a squared projectile...
        if (collision.gameObject.tag == "PowerProjectile")
        {
            numberValue = Mathf.Pow(numberValue, 2);
            SpriteUpdate();
            Debug.Log("Collided with a power projectile");
        }
        // If collided with squared root...
        else if (collision.gameObject.tag == "SquaredRoot")
        {
            Debug.Log("Collided with a squared root");
            numberValue = Mathf.Sqrt(numberValue);

            // Square root of negative number is MATH ERROR (Memes)
            if(numberValue < 0)
            {
                Application.Quit();
            }

            // If it is not a whole number...
            if (numberValue % 1 != 0)
            {
                // Gets largest smaller integer
                float smallerInteger = Mathf.Floor(numberValue);

                // Originate another number (1st decimal digit)
                float decimals = numberValue - smallerInteger;
                decimals = decimals * 10;
                Divide(Mathf.Floor(decimals));

                // Update this number with largest smaller integer
                numberValue = smallerInteger;
                ConfigureTimeChange();
            }

            // Do normal sprite update
            SpriteUpdate();
        }
        // If collided with wall or other number...
        else
        {
            // Gets reflection direction based on current trajectory
            reflectDirection = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            moveDirection = reflectDirection.normalized;
        }
    }

    public void SpriteUpdate()
    {
        // Update sprite
        if ((int)numberValue > 2)
            numberValue = 2;
        if ((int)numberValue < 0)
            numberValue = 0;

        spriteRenderer.sprite = usableSprites[(int)numberValue]; // TBD

        // CHANGE SPRITE OR FONT IN ORDER TO DISTINGUISH + OR -

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
            numberValue += 1;
        else
            numberValue -= 1;

        SpriteUpdate();

        isChanging = false;
    }

    private void Divide(float newNumber)
    {
        activateTest = false; // TBD

        // Copy this number
        GameObject decimalNumber = GameObject.Instantiate(gameObject);
        NumberEntity decimalNumberEntity = decimalNumber.GetComponent<NumberEntity>();

        // Assign new number value, update sprite
        decimalNumberEntity.numberValue = 0.0f;    // CHANGE TO NEW NUMBER
        decimalNumberEntity.ConfigureTimeChange();
        decimalNumberEntity.SpriteUpdate();

        // Offset the new number slightly so we don't have instant collision
        decimalNumber.GetComponent<Rigidbody2D>().position = rb.position - moveDirection * newNumberOffset;
        decimalNumberEntity.moveDirection = -1 * moveDirection;
    }

    private void PerfectSquareHeadsUp()
    {
        // BEWARE: AT CURRENT TIME (16:14) THIS DOESN'T WORK SINCE SPRITE 0 CORRESPONDS TO 1

        // If this number is perfect square...
        if (Mathf.Sqrt(numberValue) % 1 == 0)
        {
            Debug.Log("PerfectSquare!!!");
        }
        // If next number is perfect square... (increasing)
        else if (Mathf.Sqrt(numberValue + 1) % 1 == 0 && isIncrementing)
        {
            Debug.Log("PerfectSquareComingUp");
        }
        // If next number is perfect square... (decreasing)
        else if (Mathf.Sqrt(numberValue - 1) % 1 == 0 && !isIncrementing)
        {
            Debug.Log("PerfectSquareComingUp");
        }
    }


}
