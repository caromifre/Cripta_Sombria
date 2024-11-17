using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    [SerializeField] float _healt=100;
    private void Start()
    {
        // Valores del esqueleto
        health = _healt;
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