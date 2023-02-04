using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public GameObject bulletPrefab;
    public float cooldown = 0.5f;

    private float currentCooldown = 0f;
    public GameObject bulletIndicator;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        playerInputActions.PlayerActionMap.Shoot.started += Shoot_performed;
    }

    private void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        if (currentCooldown > 0) return;
        GameObject bullet = Instantiate(bulletPrefab, bulletIndicator.transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
        currentCooldown = cooldown;
    }
}
