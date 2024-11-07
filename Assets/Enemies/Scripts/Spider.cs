using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private void Start()
    {
        // Valores de la ara�a
        health = 50;
        walkSpeed = 3;
        runSpeed = 5;
        detectionRange = 15;
        damageGenerate = 5;

        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        animator.SetFloat("Health", health);
    }
}
