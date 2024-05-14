using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public void UpgradeHealth()
    {
        if (FindObjectOfType<PlayerStats>().upgradePoints > 0)
        {
            FindObjectOfType<PlayerStats>().upgradePoints--;
            FindObjectOfType<PlayerStats>().maxHealth += 10;
            FindObjectOfType<PlayerStats>().health = FindObjectOfType<PlayerStats>().maxHealth;
        }
    }

    public void UpgradeSpeed()
    {
        if (FindObjectOfType<PlayerStats>().upgradePoints > 0)
        {
            FindObjectOfType<PlayerStats>().upgradePoints--;
            FindObjectOfType<PlayerStats>().movementSpeed += 1;
        }
    }

    public void UpgradeCooldown()
    {
        if (FindObjectOfType<PlayerStats>().upgradePoints > 0)
        {
            FindObjectOfType<PlayerStats>().upgradePoints--;
            FindObjectOfType<PlayerStats>().shootCooldown -= 0.5f;
        }
    }

    public void UpgradeDamage()
    {
        if (FindObjectOfType<PlayerStats>().upgradePoints > 0)
        {
            FindObjectOfType<PlayerStats>().upgradePoints--;
            FindObjectOfType<PlayerStats>().damage += 5;
        }
    }
}