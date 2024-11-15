using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float health { get; protected set; }
    public float damageGenerate = 10;
    Game_manager _controler;
    protected Animator _anim;

    public void Awake()
    {
        
        health = 1000;
        //actualizar la vida en el game_manager
        
        _anim = GetComponent<Animator>();
        _anim.SetFloat("Health", health);
    }

    private void Start()
    {
        _controler = Game_manager.Instance;
        _controler._tot_vida = health;
    }
    // Recibe dano
    public void TakeDamage(float damage)
    {
        if (!Input.GetButton("Fire2")) health -= damage;
        
        //actualizar la vida en el game_manager
        _controler._tot_vida = health;
        _anim.SetFloat("Health", health);
            
            
        
        if (health <= 0) {
            //_controler.mostrar_menu_muerte();
        }
    }
    
}
