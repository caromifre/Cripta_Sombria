using System.Collections.Generic;
using UnityEngine;
using static Constantes_celda;
public class InventoryManager
{
    private Dictionary<string, int> inventory;

    public InventoryManager()
    {
        inventory = new Dictionary<string, int>();
    }

    // Metodo para agregar un item al inventario
    public void AddItem(string itemTag)
    {
        if (inventory.ContainsKey(itemTag))
        {
            inventory[itemTag]++;

        }
        else
        {
            inventory[itemTag] = 1;
        }
        Game_manager.Instance.actualizar_pociones(itemTag, inventory[itemTag]);

        Debug.Log($"Has recogido: {itemTag}. Total: {Game_manager.Instance.obtener_cant_pociones(itemTag)}");
    }


    // Metodo para usar un item del inventario
    public bool UseItem(string itemTag, float health, float maxHealth)
    {
        if (inventory.ContainsKey(itemTag) && inventory[itemTag] > 0)
        {
            IItem item = ItemFactory.CreateItem(itemTag); // Creación del ítem
            item.Use(ref health, maxHealth, inventory);  // Uso del ítem
            //actualizar invenario
            Game_manager.Instance.actualizar_pociones(itemTag, inventory.ContainsKey(itemTag) ? inventory[itemTag] : 0);
            return true;   
        }
        
        Debug.Log($"No tienes {itemTag} o la cantidad es 0.");
        return false;
    }

    // Metodo para obtener la cantidad de un item especifico
    public int GetItemCount(string itemTag)
    {
        return inventory.ContainsKey(itemTag) ? inventory[itemTag] : 0;
    }

    // Metodo para remover un item (cuando se agota la cantidad)
    public void RemoveItem(string itemTag)
    {
        if (inventory.ContainsKey(itemTag) && inventory[itemTag] <= 0)
        {
            inventory.Remove(itemTag);
        }
    }

    public void agregar_desde_GM() {
        //cargar inventario dese el gamemanager
        inventory[_POCION_VIDA]=Game_manager.Instance.obtener_cant_pociones(_POCION_VIDA);
    }
}

