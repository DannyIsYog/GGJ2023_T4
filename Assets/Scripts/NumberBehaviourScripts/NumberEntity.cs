using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberEntity : MonoBehaviour
{
    // TO SOLVE: APPLY MULTIPLE SPRITES TOGETHER
    // TO SOLVE: COLLISION DONE WITH TAGS
    // TO SOLVE: REMOVE TEST

    // Movement parameters
    [Header("Movement")]
    public float movementSpeed = 200.0f;

    // Sprites
    [Header("Sprites")]
    public Sprite[] usableSprites;
    public bool activateTest = false;

    // Auxiliary variables - Movement
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 lastVelocity;
    private Vector2 reflectDirection;

    // Auxiliary variables - Number
    private float numberValue;

    void Start()
    {
        ChooseInitialNumber();

        // Connect rigidbody
        rb = GetComponent<Rigidbody2D>();

        // Get random initial direction
        moveDirection = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        Movement();

        TEST();
    }

    void TEST()
    {
        if (activateTest)
            SpriteUpdate();
    }

    private void ChooseInitialNumber()
    {
        // Choose random number and assign sprites
        numberValue = Random.Range(0, usableSprites.Length);
        GetComponent<SpriteRenderer>().sprite = usableSprites[(int)numberValue];
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
        if (collision.gameObject.tag == "SquareProjectile")
        {
            numberValue = Mathf.Pow(numberValue, 2);
            SpriteUpdate();
        }
        // If collided with squared root...
        else if (collision.gameObject.tag == "SquaredRoot")
        {
            numberValue = Mathf.Sqrt(numberValue);
            SpriteUpdate();
        }
        else
        {
            // Gets reflection direction based on current trajectory
            reflectDirection = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            moveDirection = reflectDirection.normalized;
        }
    }

    private void SpriteUpdate()
    {
        // Update sprite value
        //currentSprite = usableSprites[(int)numberValue];

        GetComponent<SpriteRenderer>().sprite = usableSprites[0];
    }

}
