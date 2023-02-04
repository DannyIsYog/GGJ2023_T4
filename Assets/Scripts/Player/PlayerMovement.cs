using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 movementInput;

    private void Update()
    {
        transform.Translate(new Vector2(movementInput.x, movementInput.y) * speed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}