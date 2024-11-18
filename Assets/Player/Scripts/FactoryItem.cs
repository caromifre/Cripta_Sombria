using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemFactory
{
    public static IItem CreateItem(string itemTag)
    {
        switch (itemTag)
        {
            case "Bottle_Health":
                return new HealthPotion();
            default:
                return null;
        }
    }
}
