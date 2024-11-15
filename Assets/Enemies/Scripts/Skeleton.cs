using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    private void Start()
    {
        // Valores del esqueleto
        health = 100;
        walkSpeed = 2f;
        runSpeed = 1.5f;
        detectionRange = 5;
        damageGenerate = 5;
        distanceAttack = 1.5f;

        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        animator.SetFloat("Health", health);
    }
}