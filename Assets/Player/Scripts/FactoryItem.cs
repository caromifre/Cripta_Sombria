using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constantes_celda;

public static class ItemFactory
{
    public static IItem CreateItem(string itemTag)
    {
        switch (itemTag)
        {
            case _POCION_VIDA:
                return new HealthPotion();
            default:
                return null;
        }
    }
}
