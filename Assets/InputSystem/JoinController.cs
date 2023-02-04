using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinController : MonoBehaviour
{/*
    private PlayerInput playerInput;

    public GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        playerInputActions.PlayerActionMap.Join.performed += Join_performed;

        // get all of the players
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Join_performed(InputAction.CallbackContext obj)
    {
        // if the player is already joined, return
        if (players[0].GetComponent<PlayerMovement>().gamepad != null) return;
        players[0].GetComponent<PlayerMovement>().gamepad = obj.control.device as Gamepad;
        Debug.Log(obj.control.device.deviceId + " joined");
        players = players[1..];
    }*/
}
