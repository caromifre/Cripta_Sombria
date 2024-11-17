using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : Character
{
    // Caracteristicas
    public float interactRange = 1.5f; // Rango para recoger el item

    // Rotacion del personaje al tomar un item, no puede ser mayor a cero porque deja de rotar
    public float currentVelocityItem = 0f;
    public float smoothTimeItem = 0f;

    // Inventario
    public InventoryManager inventoryManager;

    // Consumibles
    private ItemUseManager itemUseManager;

    // Camara que seguira al jugador
    protected FollowCamera cameraScript;

    // Game manager
    //Game_manager _controler;

    public void Start()
    {
        // Camara del jugador
        cameraScript = Camera.main.GetComponent<FollowCamera>();

        // Inventario
        inventoryManager = new InventoryManager();
        itemUseManager = new ItemUseManager();

        // Vida del player
        health = 10f;
        maxHealth = health;
        _anim.SetFloat("Health", health);

        // Obtner insancia del gamemanagaer 
        _controler = Game_manager.Instance;

        // Actualizar la vida en el game_manager
        _controler._tot_vida = health;

        // Dano que genera y rango
        damageGenerate = 10f; // Esto se deberia modificar si integramos diferentes armas
        distanceAttack = 1.8f;

        // Velocidad de movimiento del jugador en el mapa
        speed = 2f;
        sprintSpeed = 3f;
    }

    // Metodo para usar la pocion de vida
    public void UseHealthPotion()
    {
        if (inventoryManager.UseItem("Bottle_Health", health, maxHealth))
        {
            Debug.Log("Usaste una poción de salud.");
        }
    }
}
