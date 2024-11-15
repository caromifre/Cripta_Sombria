using UnityEngine;

public class Recolectable : MonoBehaviour
{
    private string itemName;

    private void Awake()
    {
        // Asigna autom�ticamente el nombre del GameObject al nombre del �tem
        itemName = gameObject.name;
    }

    // M�todo para devolver el nombre del �tem
    public string GetItemName()
    {
        return itemName;
    }
}