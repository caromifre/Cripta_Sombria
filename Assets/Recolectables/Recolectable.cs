using UnityEngine;

public class Recolectable : MonoBehaviour
{
    private string itemName;

    private void Awake()
    {
        // Asigna automáticamente el nombre del GameObject al nombre del ítem
        itemName = gameObject.name;
    }

    // Método para devolver el nombre del ítem
    public string GetItemName()
    {
        return itemName;
    }
}