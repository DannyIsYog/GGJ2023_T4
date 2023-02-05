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

    public Collider2D swordCollider;
    public float cooldown = 3f;

    public float currentCooldown = 0f;
    public GameObject bulletIndicator;

    public AttackType currentAttackType = AttackType.Melee;

    public Color bulletIndicatorColor;

    private void Update()
    {
        bool enter = false;
        if (currentCooldown > 0)
        {
            enter = true;
            currentCooldown -= Time.deltaTime;
        }
        if (enter)
        {
            if (currentCooldown <= 0)
            {
                bulletIndicator.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, bulletIndicatorColor, 1.5f);
            }
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (currentCooldown > 0) return;
        if (!context.started) return;
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
        bulletIndicator.GetComponent<SpriteRenderer>().color = Color.Lerp(bulletIndicatorColor, Color.white, 1f);
        rb.AddForce(bulletIndicator.transform.up * 10, ForceMode2D.Impulse);
        currentCooldown = cooldown;
    }

    private void Attack_performed(InputAction.CallbackContext obj)
    {
        swordCollider.enabled = true;
        currentCooldown = cooldown;
        bulletIndicator.GetComponent<SpriteRenderer>().color = Color.Lerp(bulletIndicatorColor, Color.white, 1f);
        Invoke("DisableSwordCollider", 0.2f);
    }

    private void DisableSwordCollider()
    {
        swordCollider.enabled = false;
    }
}
