using UnityEngine;

public class Recolectable : MonoBehaviour, IInteractable
{
    // Nombre del objeto (se asignar� autom�ticamente en Start)
    [SerializeField] private string itemName;

    // Estado de recolecci�n
    private bool isCollected = false;

    private void Start()
    {
        // Asignar el nombre del objeto al itemName si no ha sido asignado manualmente
        if (string.IsNullOrEmpty(itemName))
        {
            itemName = gameObject.name;
        }
    }

    public void Interact(PlayerBehaviour player)
    {
        // Si ya fue recolectado, no hacer nada
        if (isCollected) return;

        // A�adir el objeto al inventario del jugador
        player.inventoryManager.AddItem(itemName);

        // Marcar como recolectado y destruir el objeto
        isCollected = true;
        Destroy(gameObject);
    }
}
