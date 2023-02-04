using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimIndicatorController : MonoBehaviour
{
    private PlayerInput playerInput;
    public GameObject bulletIndicator;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        playerInputActions.PlayerActionMap.Aim.performed += Aim_performed;
    }

    private void Aim_performed(InputAction.CallbackContext obj)
    {
        //rotate the bullet indicator according to gamepad obj
        Vector2 aimInput = obj.ReadValue<Vector2>();
        float angle = Mathf.Atan2(aimInput.y, aimInput.x) * Mathf.Rad2Deg;
        angle -= 90;
        bulletIndicator.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
    }


}
