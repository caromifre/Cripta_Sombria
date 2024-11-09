using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Enemy
{
    private void Start()
    {
        // Valores del orco
        health = 250;
        walkSpeed = 1;
        runSpeed = 2;
        detectionRange = 10;
        damageGenerate = 20;

        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        animator.SetFloat("Health", health);
    }
}
