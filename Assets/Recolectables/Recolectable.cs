using UnityEngine;

public class Recolectable : MonoBehaviour, IInteractable
{
    [SerializeField] private string itemName; // Nombre del objeto

    private bool isCollected = false;

    // Implementación correcta del método Interact
    public void Interact(PlayerBehaviour player)
    {
        if (isCollected) return;

        // Añadir el objeto al inventario del jugador
        player.inventoryManager.AddItem(itemName);

        // Marcar como recolectado y destruir el objeto
        isCollected = true;
        Destroy(gameObject);
    }
}