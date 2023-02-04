using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimIndicatorController : MonoBehaviour
{
    public GameObject AimIndicator;

    public void Aim_performed(InputAction.CallbackContext obj)
    {
        //rotate the bullet indicator according to gamepad obj
        Vector2 aimInput = obj.ReadValue<Vector2>();
        float angle = Mathf.Atan2(aimInput.y, aimInput.x) * Mathf.Rad2Deg;
        angle -= 90;
        AimIndicator.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
    }


}
