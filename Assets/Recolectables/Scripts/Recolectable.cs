using UnityEngine;

public class Recolectable : MonoBehaviour, IInteractable
{
    [SerializeField] private string itemName; // Nombre del objeto

    private bool isCollected = false;

    // Implementaci�n correcta del m�todo Interact
    public void Interact(PlayerBehaviour player)
    {
        if (isCollected) return;

        // A�adir el objeto al inventario del jugador
        player.inventoryManager.AddItem(itemName);

        // Marcar como recolectado y destruir el objeto
        isCollected = true;
        Destroy(gameObject);
    }
}