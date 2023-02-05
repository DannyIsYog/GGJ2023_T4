using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class VariableEntity : MonoBehaviour
{
    // TO DO: CHANGE SPRITE OR FONT IN ORDER TO DISTINGUISH + OR - 
    const int MAX_VAL = 10000;

    // Movement parameters
    [Header("Movement")]
    public float movementSpeed = 200.0f;
    public float newNumberOffset = 1.5f;

    // Number Control
    [Header("Number Control")]
    public int numSpawn;
    public int rangeMin;
    public int rangeMax;
    public int timeToChange;
    public UnityEvent<int> variableStart;
    public UnityEvent<int> variableSpawned;
    public GameManager manager;
    public GameObject numberPrefab;


    // Auxiliary variables - Movement
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public Vector2 lastVelocity;
    private Vector2 reflectDirection;

    // Auxiliary variables - Number
    private SpriteRenderer spriteRenderer;
    bool begin = false;

    void Awake()
    {
        // Connect rigidbody
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get random initial direction
        moveDirection = Random.insideUnitCircle.normalized;
        variableStart.Invoke(numSpawn);

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
        }
    }

    public void BeginGame()
    {
        begin = true;
        SetEnabled(true);
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
        if (collision.gameObject.tag == "PowerProjectile" || collision.gameObject.tag == "SquaredRoot")
        {
            float val = Random.Range(rangeMin, rangeMax);
            SpawnNumber(val);
            numSpawn -= 1;
            variableSpawned.Invoke(numSpawn);
            if (numSpawn <= 0)
            {
                Destroy(gameObject);
            }
        }
        // If collided with wall or other number...
        else
        {
            // Gets reflection direction based on current trajectory
            reflectDirection = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            moveDirection = reflectDirection.normalized;
        }
    }

    private void SpawnNumber(float newNumber)
    {

        // Copy this number
        GameObject number = GameObject.Instantiate(numberPrefab);
        NumberEntity numberEntity = number.GetComponent<NumberEntity>();

        // Assign new number value, update sprite
        numberEntity.numberStart.AddListener(manager.OnNumberStart);
        numberEntity.numberChanged.AddListener(manager.OnNumberChanged);
        numberEntity.SetValue(newNumber);
        numberEntity.numberStart.Invoke((int)newNumber);
        numberEntity.timeToIncDec = timeToChange;
        numberEntity.ConfigureTimeChange();
        numberEntity.StartGame();

        // Offset the new number slightly so we don't have instant collision
        number.GetComponent<Rigidbody2D>().position = rb.position - moveDirection * newNumberOffset;
        numberEntity.moveDirection = -1 * moveDirection;
        numberEntity.timeSqr = 0;

    }


}
