using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    private void Start()
    {
        // Valores del esqueleto
        health = 10f;
        speed = 2f;
        sprintSpeed = 1.5f;
        detectionRange = 5f;
        damageGenerate = 10f;
        distanceAttack = 1.5f;

        player = GameObject.Find("Player");
        _anim.SetFloat("Health", health);
    }
}