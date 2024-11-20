using System.Collections.Generic;
using UnityEngine;
using static Constantes_celda;

public class HealthPotion : IItem
{
    public void Use(ref float health, float maxHealth, Dictionary<string, int> inventory)
    {
        // Lógica para usar la botella de salud
        inventory[_POCION_VIDA]--;
        float healthIncrease = maxHealth * 0.25f;
        health = Mathf.Min(health + healthIncrease, maxHealth);

        if (inventory[_POCION_VIDA] == 0)
        {
            inventory.Remove(_POCION_VIDA);
        }
    }
}
