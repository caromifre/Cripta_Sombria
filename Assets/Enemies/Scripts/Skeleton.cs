using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    [SerializeField] float _health = 100;
    [SerializeField] float _speed = 2f;
    [SerializeField] float _sprintSpeed = 1.5f;
    [SerializeField] float _detectionRange = 5f;
    [SerializeField] float _damageGenerate = 10f;
    [SerializeField] float _distanceAttack = 1.5f;
    private void Start()
    {
        // Valores del esqueleto
        health = _health;
        speed = 2f;
        sprintSpeed = 1.5f;
        detectionRange = 5f;
        damageGenerate = 10f;
        distanceAttack = 1.5f;

        player = GameObject.Find("Player");
        _anim.SetFloat("Health", health);
    }
}