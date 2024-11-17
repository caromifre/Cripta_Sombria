using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IItem
{
    public void Use(ref float health, float maxHealth, Dictionary<string, int> inventory);

}

