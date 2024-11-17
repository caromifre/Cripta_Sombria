using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseManager
{
    public void UseItem(IItem item, float health, float maxHealth, Dictionary<string, int> inventory)
    {
        item.Use(ref health, maxHealth, inventory);
    }
}

