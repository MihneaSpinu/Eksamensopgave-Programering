using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public void UpgradeHealth()
    {
        PlayerStats playerStats = FindAnyObjectByType<PlayerStats>();
        playerStats.maxHealth += 10;
        playerStats.health = playerStats.maxHealth;
    }

    public void UpgradeDamage()
    {
        PlayerStats playerStats = FindAnyObjectByType<PlayerStats>();
        playerStats.damage += 5;
    }

    public void UpgradeSpeed()
    {
        PlayerStats playerStats = FindAnyObjectByType<PlayerStats>();
        playerStats.movementSpeed += 1;
    }

    public void UpgradeCooldown()
    {
        PlayerStats playerStats = FindAnyObjectByType<PlayerStats>();
        playerStats.shootCooldown -= 0.5f;
    }

    public void UpgradeAll()
    {
        UpgradeHealth();
        UpgradeDamage();
        UpgradeSpeed();
        UpgradeCooldown();
    }
    
}
