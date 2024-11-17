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
            // Aqu� puedes agregar m�s �tems en el futuro
            default:
                return null;
        }
    }
}
