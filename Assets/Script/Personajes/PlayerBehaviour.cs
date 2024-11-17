using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float maxHealth;
    public float health { get; protected set; }
    public float damageGenerate = 10;
    protected Animator _anim;
    [SerializeField] private float pickupRange = 3f; // Rango para recoger el ítem
    [SerializeField] private Transform playerTransform; // Referencia al transform del Player
    // Diccionario para almacenar el inventario (nombre del ítem y cantidad)
    private Dictionary<string, int> inventory = new Dictionary<string, int>();
    [SerializeField] GameObject _activar_portal;
    Game_manager _controler;        
      
        
    public void Awake()
    {   
        
        health = 500f;
        maxHealth = health;
        

        _anim = GetComponent<Animator>();
        _anim.SetFloat("Health", health);
        // Inicializamos el inventario vacío
        inventory = new Dictionary<string, int>();
    }
    private void Start()
    {
        //obtner insancia del gamemanagaer
        _controler = Game_manager.Instance;
        //actualizar la vida en el game_manager
        _controler._tot_vida = health;
    }
    private void Update()
    {
        // Verificar si se hizo clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            TryPickUpItem();
            Debug.Log("!!!!!!!!!!!!!!!!!!hizo click");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            UseHealthBottle();
        }

        /*if (Game_manager.Instance._Jefe_muerto && !_activar_portal.GetComponent<Light>().enabled) { 
            _activar_portal.GetComponent<Light>().enabled = true;
        }*/

    }
    private void UseHealthBottle()
    {
        string itemName = "Bottle_Health";

        // Verificar si el diccionario tiene el ítem y que la cantidad sea mayor a 0
        if (inventory.ContainsKey(itemName) && inventory[itemName] > 0)
        {
            // Restar una botella del inventario
            inventory[itemName]--;

            // Evitar que se supere el máximo de salud
            float healthIncrease = maxHealth * 0.25f;
            health = Mathf.Min(health + healthIncrease, maxHealth);

            Debug.Log($"Usaste una Bottle_Health. Salud actual: {health}");

            // Si se agotan las botellas, eliminar la entrada del diccionario (opcional)
            if (inventory[itemName] == 0)
            {
                inventory.Remove(itemName);
            }
        }
        else
        {
            Debug.Log(inventory.ContainsKey(itemName));
        }
    }
    // Método para intentar recoger el ítem
    private void TryPickUpItem()
    {
        // Detectar el objeto al que se hace clic
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Si el raycast detecta un objeto
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Default", "TransparentFX", "Water", "UI")))
        {
            //Debug.Log($"Impacto con objeto: {hit.collider.gameObject.name}");
            Recolectable item = hit.collider.GetComponentInParent<Recolectable>();

           /* Debug.Log("colisiono");
            Debug.Log(item);*/

            // Si el objeto clickeado tiene el componente Item
            if (item != null)
            {

                Debug.Log("encontro un itemm");
                // Calcular la distancia al jugador
                float distance = Vector3.Distance(playerTransform.position, hit.transform.position);

                // Si el ítem está dentro del rango de recogida
                if (distance <= pickupRange)
                {
                    PickUpItem(item);
                }
                else
                {
                    Debug.Log("El ítem está demasiado lejos.");
                }
            }
        }
    }

    // Método para recoger el ítem
    private void PickUpItem(Recolectable item)
    {
        string itemName = item.GetItemName();

        // Si el ítem ya está en el inventario, aumentar su cantidad
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName]++;
        }
        else
        {
            // Si el ítem no está en el inventario, añadirlo con cantidad 1
            inventory[itemName] = 1;
        }

        Debug.Log($"Has recogido: {itemName}. Total: {inventory[itemName]}");

        // Destruir el ítem una vez recogido
        Destroy(item.gameObject);
    }

    // Método para obtener la cantidad de un ítem específico
    public int GetItemCount(string itemName)
    {
        // Devuelve la cantidad de ítems si existe en el inventario, de lo contrario, devuelve 0
        return inventory.ContainsKey(itemName) ? inventory[itemName] : 0;
    }
    // Recibe dano
    public void TakeDamage(float damage)
    {
        if (!Input.GetButton("Fire2"))
        {
            health -= damage;
            _controler._tot_vida = health;
            _anim.SetFloat("Health", health);
        }
            
    }

}
