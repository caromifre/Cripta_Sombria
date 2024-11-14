using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float health { get; protected set; }
    public float damageGenerate = 10;
    Game_manager _controler;
    protected Animator _anim;

    public void Awake()
    {
        _controler = Game_manager.Instance;
        health = 500;
        //actualizar la vida en el game_manager
        _controler._tot_vida = health;
        _anim = GetComponent<Animator>();
        _anim.SetFloat("Health", health);
    }


    // Recibe dano
    public void TakeDamage(float damage)
    {
        if (!Input.GetButton("Fire2"))
            Debug.Log(health);
            health -= damage;
            _anim.SetFloat("Health", health);
            //actualizar la vida en el game_manager
            _controler._tot_vida = health;
    }
}
