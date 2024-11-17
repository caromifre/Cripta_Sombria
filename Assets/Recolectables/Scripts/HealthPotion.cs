using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : IItem
{
    public void Use(ref float health, float maxHealth, Dictionary<string, int> inventory)
    {
        // Lógica para usar la botella de salud
        inventory["Bottle_Health"]--;
        float healthIncrease = maxHealth * 0.25f;
        health = Mathf.Min(health + healthIncrease, maxHealth);

        if (inventory["Bottle_Health"] == 0)
        {
            inventory.Remove("Bottle_Health");
        }
    }
}
