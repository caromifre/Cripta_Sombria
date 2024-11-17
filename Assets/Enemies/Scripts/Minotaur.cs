using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Enemy
{
    private void Start()
    {
        // Valores del orco
        health = 250f;
        speed = 1f;
        sprintSpeed = 2f;
        detectionRange = 10f;
        damageGenerate = 20f;
        distanceAttack = 1.5f;

        player = GameObject.Find("Player");
        _anim.SetFloat("Health", health);
    }
}
