using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Enemy
{
    [SerializeField] float _healt = 250;
    private void Start()
    {
        // Valores del orco
        health = _healt;
        walkSpeed = 1;
        runSpeed = 2;
        detectionRange = 10;
        damageGenerate = 20;
        distanceAttack = 1.5f;

        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        animator.SetFloat("Health", health);
    }
}
