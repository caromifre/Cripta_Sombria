using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    private void Start()
    {
        // Valores del esqueleto
        health = 100;
        walkSpeed = 2;
        runSpeed = 4;
        detectionRange = 10;
        damageGenerate = 10;
        distanceAttack = 1.5f;

        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        animator.SetFloat("Health", health);
    }
}