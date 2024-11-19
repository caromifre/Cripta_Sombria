using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    [SerializeField] float _health = 50;
    

    private void Start()
    {
        // Valores de la araña
        health = _health;
        speed = 1.8f;
        sprintSpeed = 2f;
        detectionRange = 7f;
        damageGenerate = 5f;
        distanceAttack = 0.8f;

        player = GameObject.Find("Player");
        _anim.SetFloat("Health", health);
        
    }
    /*void update() {
        if (health <= 0) {
            _drop_Colectables.soltar_Item();
        }
    }*/

}
