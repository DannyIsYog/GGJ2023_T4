using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 movementInput;

    private Rigidbody2D rb;

    GameManager gameManager;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }


    private void Update()
    {
        rb.velocity = movementInput * speed;
        //transform.Translate(movementInput * speed * Time.deltaTime);

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        Debug.Log(movementInput);
    }

    public void StartGame(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        if (context.performed) return;

        if (gameManager.isTutorial)
            gameManager.NextTutorialHint();

        gameManager.StartGame();


    }

    public void AdvanceLevel(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        if (context.performed) return;
        gameManager.NextLevel();
    }

    public void AdvanceTutorial(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        if (context.performed) return;
        gameManager.NextTutorialHint();
    }


}