using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Enemy
{
    [SerializeField] float _health = 250;
    private void Start()
    {
        // Valores del orco
        health = _health;
        speed = 1f;
        sprintSpeed = 2f;
        detectionRange = 10f;
        damageGenerate = 20f;
        distanceAttack = 1.5f;

        player = GameObject.Find("Player");
        _anim.SetFloat("Health", health);
    }
}
