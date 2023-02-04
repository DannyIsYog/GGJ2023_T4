using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput playerInput;

    //gamepad assignment
    public Gamepad gamepad = null;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        playerInputActions.PlayerActionMap.Movement.performed += Movement_performed;
        playerInputActions.PlayerActionMap.Movement.canceled += Movement_canceled;
    }
    private void Movement_performed(InputAction.CallbackContext obj)
    {
        if (gamepad == null) return;
        if (obj.control.device.deviceId != gamepad.deviceId) return;
        Vector2 movement = obj.ReadValue<Vector2>();
        rb.velocity = movement;
        Debug.Log(obj.control.device.deviceId + " moved");
    }

    private void Movement_canceled(InputAction.CallbackContext obj)
    {
        if (gamepad == null) return;
        if (obj.control.device.deviceId != gamepad.deviceId) return;
        rb.velocity = Vector2.zero;
        Debug.Log(obj.control.device.deviceId + " stopped");
    }
}