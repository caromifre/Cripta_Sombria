using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    [SerializeField] float _health = 50;
    [SerializeField] float _speed = 1.8f;
    [SerializeField] float _sprintSpeed = 2.5f;
    [SerializeField] float _detectionRange = 7f;
    [SerializeField] float _damageGenerate = 20f;
    [SerializeField] float _distanceAttack = 0.8f;

    private void Start()
    {
        // Valores de la araña
        health = _health;
        speed = _speed;
        sprintSpeed = _sprintSpeed;
        detectionRange = _detectionRange;
        damageGenerate = _damageGenerate;
        distanceAttack = _distanceAttack;

        player = GameObject.Find("Player");
        _anim.SetFloat("Health", health);
        
    }
    /*void update() {
        if (health <= 0) {
            _drop_Colectables.soltar_Item();
        }
    }*/

}
