using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;

    public void TakeDamage(int _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            Debug.Log("Die");
        }
        else
        {
            Debug.Log("Player took " + _damage + " damage, current health " + health);
        }
    }
}
