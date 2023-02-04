using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{
    public enum AttackType
    {
        Melee,
        Ranged
    }
    public GameObject bulletPrefab;
    public float cooldown = 0.5f;

    private float currentCooldown = 0f;
    public GameObject bulletIndicator;

    public AttackType currentAttackType = AttackType.Melee;

    private void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (currentCooldown > 0) return;
        if (currentAttackType == AttackType.Melee)
        {
            Attack_performed(context);
        }
        else if (currentAttackType == AttackType.Ranged)
        {
            Shoot_performed(context);
        }
    }

    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletIndicator.transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
        currentCooldown = cooldown;
    }

    private void Attack_performed(InputAction.CallbackContext obj)
    {
        //attack
        currentCooldown = cooldown;
    }
}
